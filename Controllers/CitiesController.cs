using Newtonsoft.Json;
using RutinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RutinApp.Controllers
{
    public class CitiesController
    {
        private HttpClient client;

        public CitiesController()
        { 
            client =new HttpClient();
        }

        //public async Task<Cities> GetCities()
        public async Task<List<City>> GetCities()
        {
            try
            {
                //Cities cities = new Cities();
                
                HttpResponseMessage response = await client.GetAsync("https://localhost:7137/api/Cities");
                //Usa esta llamada para probar solo 1 retorno
               //HttpResponseMessage response = await client.GetAsync("https://localhost:7137/api/Cities/2");

                response.EnsureSuccessStatusCode();
                string responseJson = await response.Content.ReadAsStringAsync();

                //apaño provisional hasta entender como serializar correctamente los Json
                if (responseJson[0] is not '[')
                {
                    responseJson = "[" + responseJson + "]";
                }
                List<City> citiesList = JsonConvert.DeserializeObject<List<City>>(responseJson);

                //cities = JsonConvert.DeserializeObject<Cities>("{" + responseJson + "}");
                //cities = JsonConvert.DeserializeObject<Cities>("{\"results\": [" + responseJson + "]}");
                //cities = JsonConvert.DeserializeObject<Cities>("{\"results\": " + responseJson + "}");
                
                //cities = JsonConvert.DeserializeObject<Cities>(responseJson);
                //return cities;

                return citiesList;

            }
            catch (Exception)
            {
                //mirar como controlar esta excepción correctamente
                return null;
            }
           
        }

    }
}
