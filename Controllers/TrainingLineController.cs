using Newtonsoft.Json;
using RutinApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RutinApp.Controllers
{
    public class TrainingLineController
    {
        private string connectionString;

        public TrainingLineController()
        {
            connectionString = DatabaseHelper.GetConnectionString();
        }

        public async Task<List<TrainingLine>> GetTrainingLinesOfTraining(int id)
        {
            try
            {
                List<TrainingLine> trainingLines = new List<TrainingLine>();

                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "SELECT * FROM TrainingLines WHERE TrainingID = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var trainingLine = new TrainingLine(
                                    Convert.ToInt32(reader["ID"]),
                                    Convert.ToInt32(reader["ExerciseID"]),
                                    Convert.ToInt32(reader["TrainingID"]),
                                    reader["Sets"].ToString(),
                                    reader["Repetitions"].ToString(),
                                    reader["Weight"].ToString(),
                                    reader["Recovery"].ToString(),
                                    reader["Others"].ToString(),
                                    reader["Notes"].ToString(),
                                    reader["Grip"].ToString()
                                );

                                trainingLines.Add(trainingLine);
                            }
                        }
                    }
                }

                return trainingLines;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo obtener la petición. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> InsertTrainingLine(TrainingLine trainingLine)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"
                        INSERT INTO TrainingLines (ExerciseID, TrainingID, Sets, Repetitions, Weight, Recovery, Others, Notes, LastUpdated, Grip)
                        VALUES (@ExerciseID, @TrainingID, @Sets, @Repetitions, @Weight, @Recovery, @Others, @Notes, datetime('now'), @Grip);
                        SELECT last_insert_rowid();";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ExerciseID", trainingLine.ExerciseID);
                        cmd.Parameters.AddWithValue("@TrainingID", trainingLine.TrainingID);
                        cmd.Parameters.AddWithValue("@Sets", trainingLine.Sets);
                        cmd.Parameters.AddWithValue("@Repetitions", trainingLine.Repetitions);
                        cmd.Parameters.AddWithValue("@Weight", trainingLine.Weight);
                        cmd.Parameters.AddWithValue("@Recovery", trainingLine.Recovery);
                        cmd.Parameters.AddWithValue("@Others", trainingLine.Others);
                        cmd.Parameters.AddWithValue("@Notes", trainingLine.Notes);
                        cmd.Parameters.AddWithValue("@Grip", trainingLine.Grip);

                        // ExecuteScalarAsync to get the last inserted ID
                        int lastInsertID = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                        return lastInsertID > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la inserción. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task<bool> DeleteTrainingLine(int id)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "DELETE FROM TrainingLines WHERE ID = @id";

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
                MessageBox.Show("No se pudo realizar la eliminación. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
