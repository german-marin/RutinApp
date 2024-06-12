using RutinApp.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http.Headers;

namespace RutinApp.Controllers
{
    public class UserController
    {
        private readonly HttpClient client;

        public UserController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenManager.Token);
        }

        public async Task<AuthenticationResult> Authenticate(User user)
        {
            try
            {
                // Serializa el objeto user a formato JSON
                string json = JsonConvert.SerializeObject(user);

                // Configura el contenido de la solicitud
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"{ApiConfiguration.ApiBaseUrl}/api/User/authenticate", content);

                if (response.IsSuccessStatusCode)
                {
                    string token = await response.Content.ReadAsStringAsync();
                    return new AuthenticationResult
                    {
                        Token = token,
                        IsSuccess = true
                    };
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return new AuthenticationResult
                    {
                        IsSuccess = false,
                        ErrorMessage = "La contraseña es incorrecta. Por favor, inténtelo de nuevo."
                    };
                }
                else
                {
                    return new AuthenticationResult
                    {
                        IsSuccess = false,
                        ErrorMessage = $"Error de inicio de sesión: {response.ReasonPhrase}"
                    };
                }
            }
            catch (Exception ex)
            {
                return new AuthenticationResult
                {
                    IsSuccess = false,
                    ErrorMessage = $"No se pudo autenticar al usuario. \n{ex.Message}"
                };
            }
        }
    }

    public class AuthenticationResult
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
        public string ErrorMessage { get; set; }
    }
}
