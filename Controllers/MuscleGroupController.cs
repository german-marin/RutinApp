using Newtonsoft.Json;
using RutinApp.Models;
using System.Net.Http.Headers;

namespace RutinApp.Controllers
{
    public class MuscleGroupController
    {
        private HttpClient client;

        public  MuscleGroupController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenManager.Token);
        }
                
        public async Task<List<MuscleGroup>> GetAllMuscleGroup()
        {
            try
            {         

                //HttpResponseMessage response = await client.GetAsync("https://localhost:7137/api/MuscleGroup");
                HttpResponseMessage response = await client.GetAsync($"{ApiConfiguration.ApiBaseUrl}/api/MuscleGroup");

                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();
               
                List<MuscleGroup> muscleGroupList = JsonConvert.DeserializeObject<List<MuscleGroup>>(responseJson);                                                

                return muscleGroupList;

            }
            catch (Exception ex)
            {
                //mirar como controlar esta excepción correctamente
                MessageBox.Show("No se pudo obtener la petición. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
        public async Task<MuscleGroup> GetMuscleGroup(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{ApiConfiguration.ApiBaseUrl}/api/MuscleGroup/{id}");
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();

                MuscleGroup muscleGroup = JsonConvert.DeserializeObject<MuscleGroup>(responseJson);

                return muscleGroup;

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo obtener la petición. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

    }
}
