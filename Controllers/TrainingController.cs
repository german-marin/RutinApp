using RutinApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RutinApp.Controllers
{
    public class TrainingController
    {
        private readonly string connectionString;

        public TrainingController()
        {
            connectionString = DatabaseHelper.GetConnectionString();
        }

        public async Task<int> InsertTraining(Training training)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"INSERT INTO trainings (Description, StartDate, EndDate, CustomerID, Notes, LastUpdate, Days) 
                                     VALUES (@description, @startDate, @endDate, @customerID, @notes, datetime('now'), @days);
                                     SELECT last_insert_rowid();";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@description", training.Description);
                        cmd.Parameters.AddWithValue("@startDate", training.StartDate);
                        cmd.Parameters.AddWithValue("@endDate", training.EndDate);
                        cmd.Parameters.AddWithValue("@customerID", training.CustomerID);
                        cmd.Parameters.AddWithValue("@notes", training.Notes);
                        cmd.Parameters.AddWithValue("@days", training.Days);

                        var lastInsertID = (long)await cmd.ExecuteScalarAsync();
                        return (int)lastInsertID;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la inserción. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public async Task<List<Training>> GetAllTrainings()
        {
            var trainingList = new List<Training>();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "SELECT * FROM trainings";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var training = new Training
                                {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    Description = reader["Description"].ToString(),
                                    StartDate = Convert.ToDateTime(reader["StartDate"]),
                                    EndDate = Convert.ToDateTime(reader["EndDate"]),
                                    CustomerID = Convert.ToInt32(reader["CustomerID"]),
                                    Notes = reader["Notes"].ToString(),
                                    Days = reader["Days"].ToString()
                                };

                                trainingList.Add(training);
                            }
                        }
                    }
                }

                return trainingList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo obtener la lista de entrenamientos. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<Training> GetTraining(int id)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "SELECT * FROM trainings WHERE ID = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                var training = new Training
                                {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    Description = reader["Description"].ToString(),
                                    StartDate = Convert.ToDateTime(reader["StartDate"]),
                                    EndDate = Convert.ToDateTime(reader["EndDate"]),
                                    CustomerID = Convert.ToInt32(reader["CustomerID"]),
                                    Notes = reader["Notes"].ToString(),
                                    Days = reader["Days"].ToString()
                                };

                                return training;
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
                MessageBox.Show("No se pudo obtener el entrenamiento. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> DeleteTraining(int id)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "DELETE FROM trainings WHERE ID = @id";
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
                MessageBox.Show("No se pudo eliminar el entrenamiento. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task<bool> DeleteTrainingAndTrainingLines(int id)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string deleteTrainingLinesQuery = "DELETE FROM traininglines WHERE TrainingID = @id";
                            using (SQLiteCommand deleteTrainingLinesCmd = new SQLiteCommand(deleteTrainingLinesQuery, conn))
                            {
                                deleteTrainingLinesCmd.Parameters.AddWithValue("@id", id);
                                await deleteTrainingLinesCmd.ExecuteNonQueryAsync();
                            }

                            string deleteTrainingQuery = "DELETE FROM trainings WHERE ID = @id";
                            using (SQLiteCommand deleteTrainingCmd = new SQLiteCommand(deleteTrainingQuery, conn))
                            {
                                deleteTrainingCmd.Parameters.AddWithValue("@id", id);
                                await deleteTrainingCmd.ExecuteNonQueryAsync();
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la eliminación. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
