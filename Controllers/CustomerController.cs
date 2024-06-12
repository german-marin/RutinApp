using Newtonsoft.Json;
using RutinApp.Models;
using System.Net.Http.Headers;

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

    }
}
