using Newtonsoft.Json;
using RutinApp.Models;

namespace RutinApp.Controllers
{
    public class CategoryController
    {
        private HttpClient client;

        public CategoryController()
        {
            client = new HttpClient();
        }

        public async Task<List<Category>> GetMuscleGroupCategories(int id)
        {
            try
            {

                HttpResponseMessage response = await client.GetAsync("https://localhost:7137/api/Category?id=" + id);
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();

                List<Category> categoryList = JsonConvert.DeserializeObject<List<Category>>(responseJson);

                return categoryList;

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
