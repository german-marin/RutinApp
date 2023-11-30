using Newtonsoft.Json;
using RutinApp.Models;

namespace RutinApp.Controllers
{
    public class MuscleGroupController
    {
        private HttpClient client;

        public  MuscleGroupController()
        {
            client = new HttpClient();
        }
                
        public async Task<List<MuscleGroup>> GetAllMuscleGroup()
        {
            try
            {        

                HttpResponseMessage response = await client.GetAsync("https://localhost:7137/api/MuscleGroup");
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

    }
}
