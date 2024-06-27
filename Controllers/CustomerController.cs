using Newtonsoft.Json;
using RutinApp.Models;
using System.Net.Http.Headers;
using System.Text;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace RutinApp.Controllers
{
    internal class CustomerController
    {
        private HttpClient client;

        public CustomerController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenManager.Token);
        }
        public async Task<List<Customer>> GetAllCustomers()
        {
            try
            {               
                HttpResponseMessage response = await client.GetAsync($"{ApiConfiguration.ApiBaseUrl}/api/Customer");

                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();

                List<Customer> customerList = JsonConvert.DeserializeObject<List<Customer>>(responseJson);

                return customerList;
            }
            catch (Exception ex)
            {
                //mirar como controlar esta excepción correctamente
                MessageBox.Show("No se pudo obtener la petición. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public async Task<Customer> GetCustomer(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{ApiConfiguration.ApiBaseUrl}/api/Customer/{id}");
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();

                Customer customer = JsonConvert.DeserializeObject<Customer>(responseJson);

                return customer;

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo obtener la petición. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public async Task<bool> UpdateCustomer(Customer customer)
        {
            try
            {
                string json = JsonConvert.SerializeObject(customer);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync($"{ApiConfiguration.ApiBaseUrl}/api/Customer/{customer.ID}", content);

                if (response.IsSuccessStatusCode)
                {                   
                        return true;                   
                }
                else
                {
                    // Manejar el caso de código de estado de respuesta no exitoso
                    MessageBox.Show($"Error en la solicitud: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("No se pudo realizar la modificación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                // Manejar otros errores
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }         
        public async Task<bool> InsertCustomer(Customer customer)
        {
            try
            {
                // Serializa el objeto customer a formato JSON
                string json = JsonConvert.SerializeObject(customer);

                // Configura el contenido de la solicitud
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // Realiza la solicitud POST               
                HttpResponseMessage response = await client.PostAsync($"{ApiConfiguration.ApiBaseUrl}/api/customer", content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Manejar el caso de código de estado de respuesta no exitoso
                    MessageBox.Show($"Error en la solicitud: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("No se pudo realizar la inserción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                // Manejar otros errores
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }          
        public async Task<bool> DeleteCustomer(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"{ApiConfiguration.ApiBaseUrl}/api/Customer/DeleteCustomer?id={id}");
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Manejar el caso de código de estado de respuesta no exitoso
                    MessageBox.Show($"Error en la solicitud: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("No se pudo realizar la eliminación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                // Manejar otros errores
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
