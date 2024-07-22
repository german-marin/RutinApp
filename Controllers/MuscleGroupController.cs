using RutinApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RutinApp.Controllers
{
    public class MuscleGroupController
    {
        private readonly string connectionString;

        public MuscleGroupController()
        {
            connectionString = DatabaseHelper.GetConnectionString();
        }

        public async Task<List<MuscleGroup>> GetAllMuscleGroup()
        {
            var muscleGroupList = new List<MuscleGroup>();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "SELECT ID, Description, ImageFront, ImageRear FROM musclegroups";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var muscleGroup = new MuscleGroup
                                {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    Description = reader["Description"].ToString(),
                                    ImageFront = reader["ImageFront"].ToString(),
                                    ImageRear = reader["ImageRear"].ToString()
                                };

                                muscleGroupList.Add(muscleGroup);
                            }
                        }
                    }
                }

                return muscleGroupList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo obtener los grupos musculares. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<MuscleGroup> GetMuscleGroup(int id)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "SELECT ID, Description, ImageFront, ImageRear FROM musclegroups WHERE ID = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                var muscleGroup = new MuscleGroup
                                {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    Description = reader["Description"].ToString(),
                                    ImageFront = reader["ImageFront"].ToString(),
                                    ImageRear = reader["ImageRear"].ToString()
                                };

                                return muscleGroup;
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
                MessageBox.Show("No se pudo obtener el grupo muscular. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
