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
                                    GlobalVariables.UserName = user.Username;
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
        public async Task<bool> ChangePassword(string username, string currentPassword, string newPassword, string confirmPassword)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    // Obtén el usuario por el nombre de usuario
                    string query = "SELECT * FROM users WHERE Username = @username";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                string storedPasswordHash = reader["Password"].ToString();

                                // Verifica si la contraseña actual es correcta
                                if (!BCrypt.Net.BCrypt.Verify(currentPassword, storedPasswordHash))
                                {
                                    MessageBox.Show("La contraseña actual es incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }

                                // Verifica si las nuevas contraseñas coinciden
                                if (newPassword != confirmPassword)
                                {
                                    MessageBox.Show("Las nuevas contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }

                                // Hashea la nueva contraseña
                                string newHashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

                                // Actualiza la contraseña en la base de datos
                                query = "UPDATE users SET Password = @newPassword WHERE Username = @username";
                                using (SQLiteCommand updateCmd = new SQLiteCommand(query, conn))
                                {
                                    updateCmd.Parameters.AddWithValue("@newPassword", newHashedPassword);
                                    updateCmd.Parameters.AddWithValue("@username", username);

                                    int rowsAffected = await updateCmd.ExecuteNonQueryAsync();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("La contraseña ha sido cambiada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se pudo cambiar la contraseña. Inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("El usuario no existe. Por favor, inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cambiar la contraseña: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
