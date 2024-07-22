using RutinApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RutinApp.Controllers
{
    public class ExerciseController
    {
        private readonly string connectionString;

        public ExerciseController()
        {
            connectionString = DatabaseHelper.GetConnectionString();
        }

        public async Task<List<Exercise>> GetCategoryExercises(int id)
        {
            var exerciseList = new List<Exercise>();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "SELECT ID, Description, CategoryID, Image, Active FROM exercises WHERE CategoryID = @categoryID";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@categoryID", id);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var exercise = new Exercise
                                {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    Description = reader["Description"].ToString(),
                                    CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                    Image = reader["Image"].ToString(),
                                    Active = Convert.ToBoolean(reader["Active"])
                                };

                                exerciseList.Add(exercise);
                            }
                        }
                    }
                }

                return exerciseList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo obtener los ejercicios de la categoría. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<Exercise> GetExercise(int id)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "SELECT ID, Description, CategoryID, Image, Active FROM exercises WHERE ID = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                var exercise = new Exercise
                                {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    Description = reader["Description"].ToString(),
                                    CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                    Image = reader["Image"].ToString(),
                                    Active = Convert.ToBoolean(reader["Active"])
                                };

                                return exercise;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo obtener el ejercicio. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> UpdateExercise(Exercise exercise)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "UPDATE exercises SET Description = @description, CategoryID = @categoryID, Image = @image, LastUpdated = datetime('now'), Active = @active WHERE ID = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@description", exercise.Description);
                        cmd.Parameters.AddWithValue("@categoryID", exercise.CategoryID);
                        cmd.Parameters.AddWithValue("@image", exercise.Image);
                        cmd.Parameters.AddWithValue("@active", exercise.Active);
                        cmd.Parameters.AddWithValue("@id", exercise.ID);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar el ejercicio. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task<bool> InsertExercise(Exercise exercise)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "INSERT INTO exercises (Description, CategoryID, Image, LastUpdated, Active) VALUES (@description, @categoryID, @image, datetime('now'), @active)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@description", exercise.Description);
                        cmd.Parameters.AddWithValue("@categoryID", exercise.CategoryID);
                        cmd.Parameters.AddWithValue("@image", exercise.Image);
                        cmd.Parameters.AddWithValue("@active", exercise.Active);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar el ejercicio. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task<bool> DeleteExercise(int id)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "DELETE FROM exercises WHERE ID = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el ejercicio. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
