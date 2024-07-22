using RutinApp.Models;
using System;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using Org.BouncyCastle.Crypto.Generators;

namespace RutinApp.Controllers
{
    public class UserController
    {
        private string connectionString;

        public UserController()
        {
            connectionString = DatabaseHelper.GetConnectionString();
        }

        public async Task<AuthenticationResult> Authenticate(User user)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "SELECT * FROM users WHERE Username = @username";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", user.Username);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                string storedPasswordHash = reader["Password"].ToString();
                                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(user.Password, storedPasswordHash);

                                if (isPasswordValid)
                                {
                                    GlobalVariables.Logo = reader["Logo"].ToString();
                                    GlobalVariables.Notes = reader["Notes"].ToString();
                                    GlobalVariables.Days = reader["Days"] != DBNull.Value ? int.Parse(reader["Days"].ToString()) : 0;
                                    GlobalVariables.Id = int.Parse(reader["Id"].ToString());
                                    return new AuthenticationResult
                                    {
                                        IsSuccess = true
                                    };
                                }
                                else
                                {
                                    return new AuthenticationResult
                                    {
                                        IsSuccess = false,
                                        ErrorMessage = "La contraseña es incorrecta. Por favor, inténtelo de nuevo."
                                    };
                                }
                            }
                            else
                            {
                                return new AuthenticationResult
                                {
                                    IsSuccess = false,
                                    ErrorMessage = "El usuario no existe. Por favor, inténtelo de nuevo."
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new AuthenticationResult
                {
                    IsSuccess = false,
                    ErrorMessage = $"No se pudo autenticar al usuario. \n{ex.Message}"
                };
            }
        }
        public async Task<bool> UpdateUserSettings(User user)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "UPDATE users SET Logo = @logo, Notes = @notes, Days = @days WHERE Id = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@logo", user.Logo);
                        cmd.Parameters.AddWithValue("@notes", user.Notes);
                        cmd.Parameters.AddWithValue("@days", user.Days);
                        cmd.Parameters.AddWithValue("@id", user.Id);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo actualizar la configuración del usuario. \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }

    public class AuthenticationResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
