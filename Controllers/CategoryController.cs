using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;
using RutinApp.Models;

namespace RutinApp.Controllers
{
    public class CategoryController
    {
        private string connectionString;

        public CategoryController()
        {
            connectionString = DatabaseHelper.GetConnectionString();
        }

        public async Task<List<Category>> GetMuscleGroupCategories(int id)
        {
            try
            {
                List<Category> categoryList = new List<Category>();

                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "SELECT * FROM categories WHERE MuscleGroupID = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                Category category = new Category
                                {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    Description = reader["Description"].ToString(),
                                    MuscleGroupID = Convert.ToInt32(reader["MuscleGroupID"])
                                };
                                categoryList.Add(category);
                            }
                        }
                    }
                }

                return categoryList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo obtener la petición. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<Category> GetCategory(int id)
        {
            try
            {
                Category category = null;

                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "SELECT * FROM categories WHERE ID = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                category = new Category
                                {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    Description = reader["Description"].ToString(),
                                    MuscleGroupID = Convert.ToInt32(reader["MuscleGroupID"])
                                };
                            }
                        }
                    }
                }

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
