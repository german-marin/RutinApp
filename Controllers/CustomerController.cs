using RutinApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RutinApp.Controllers
{
    internal class CustomerController
    {
        private readonly string connectionString;

        public CustomerController()
        {
            connectionString = DatabaseHelper.GetConnectionString();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var customerList = new List<Customer>();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "SELECT * FROM customers";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var customer = new Customer
                                {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName1 = reader["LastName1"].ToString(),
                                    LastName2 = reader["LastName2"].ToString(),
                                    BirthDate = reader["BirthDate"] != DBNull.Value ? Convert.ToDateTime(reader["BirthDate"]) : (DateTime?)null,
                                    Gender = reader["Gender"].ToString(),
                                    PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? Convert.ToInt32(reader["PhoneNumber"]) : (int?)null,
                                    Email = reader["Email"].ToString(),
                                    RegistrationDate = reader["RegistrationDate"] != DBNull.Value ? Convert.ToDateTime(reader["RegistrationDate"]) : (DateTime?)null,
                                    UnregistrationDate = reader["UnregistrationDate"] != DBNull.Value ? Convert.ToDateTime(reader["UnregistrationDate"]) : (DateTime?)null,
                                    Notes = reader["Notes"].ToString()
                                };

                                customerList.Add(customer);
                            }
                        }
                    }
                }

                return customerList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo obtener la lista de clientes. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<Customer> GetCustomer(int id)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "SELECT * FROM customers WHERE ID = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                var customer = new Customer
                                {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName1 = reader["LastName1"].ToString(),
                                    LastName2 = reader["LastName2"].ToString(),
                                    BirthDate = reader["BirthDate"] != DBNull.Value ? Convert.ToDateTime(reader["BirthDate"]) : (DateTime?)null,
                                    Gender = reader["Gender"].ToString(),
                                    PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? Convert.ToInt32(reader["PhoneNumber"]) : (int?)null,
                                    Email = reader["Email"].ToString(),
                                    RegistrationDate = reader["RegistrationDate"] != DBNull.Value ? Convert.ToDateTime(reader["RegistrationDate"]) : (DateTime?)null,
                                    UnregistrationDate = reader["UnregistrationDate"] != DBNull.Value ? Convert.ToDateTime(reader["UnregistrationDate"]) : (DateTime?)null,
                                    Notes = reader["Notes"].ToString()
                                };

                                return customer;
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
                MessageBox.Show("No se pudo obtener el cliente. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"UPDATE customers 
                                     SET FirstName = @firstName, LastName1 = @lastName1, LastName2 = @lastName2, 
                                         BirthDate = @birthDate, Gender = @gender, PhoneNumber = @phoneNumber, 
                                         Email = @Email, RegistrationDate = @registrationDate, UnregistrationDate = @unregistrationDate, 
                                         Notes = @notes, LastUpdated = datetime('now') 
                                     WHERE ID = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@firstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@lastName1", customer.LastName1);
                        cmd.Parameters.AddWithValue("@lastName2", customer.LastName2);
                        cmd.Parameters.AddWithValue("@birthDate", customer.BirthDate.HasValue ? (object)customer.BirthDate.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@gender", customer.Gender);
                        cmd.Parameters.AddWithValue("@phoneNumber", customer.PhoneNumber.HasValue ? (object)customer.PhoneNumber.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        cmd.Parameters.AddWithValue("@registrationDate", customer.RegistrationDate.HasValue ? (object)customer.RegistrationDate.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@unregistrationDate", customer.UnregistrationDate.HasValue ? (object)customer.UnregistrationDate.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@notes", customer.Notes);
                        cmd.Parameters.AddWithValue("@id", customer.ID);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar el cliente. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task<bool> InsertCustomer(Customer customer)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"INSERT INTO customers (FirstName, LastName1, LastName2, BirthDate, Gender, 
                                                             PhoneNumber, Email, RegistrationDate, UnregistrationDate, Notes, LastUpdated) 
                                     VALUES (@firstName, @lastName1, @lastName2, @birthDate, @gender, @phoneNumber, 
                                             @Email, @registrationDate, @unregistrationDate, @notes, datetime('now'))";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@firstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@lastName1", customer.LastName1);
                        cmd.Parameters.AddWithValue("@lastName2", customer.LastName2);
                        cmd.Parameters.AddWithValue("@birthDate", customer.BirthDate.HasValue ? (object)customer.BirthDate.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@gender", customer.Gender);
                        cmd.Parameters.AddWithValue("@phoneNumber", customer.PhoneNumber.HasValue ? (object)customer.PhoneNumber.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        cmd.Parameters.AddWithValue("@registrationDate", customer.RegistrationDate.HasValue ? (object)customer.RegistrationDate.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@unregistrationDate", customer.UnregistrationDate.HasValue ? (object)customer.UnregistrationDate.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@notes", customer.Notes);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo insertar el cliente. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "DELETE FROM customers WHERE ID = @id";
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
                MessageBox.Show("No se pudo eliminar el cliente. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
