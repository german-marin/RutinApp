﻿using Newtonsoft.Json;
using RutinApp.Models;
using System.Net.Http.Headers;

namespace RutinApp.Controllers
{
    public class CategoryController
    {
        private HttpClient client;

        public CategoryController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenManager.Token);
        }

        public async Task<List<Category>> GetMuscleGroupCategories(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{ApiConfiguration.ApiBaseUrl}/api/Category?id={id}");
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
       
        public async Task<Category> GetCategory(int id)
        {
            try
            {                
                HttpResponseMessage response = await client.GetAsync($"{ApiConfiguration.ApiBaseUrl}/api/Category/{id}");
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();

                Category category = JsonConvert.DeserializeObject<Category>(responseJson);

                return category;

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo obtener la petición. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

    }
}
