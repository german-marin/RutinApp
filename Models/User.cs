using System.ComponentModel.DataAnnotations;
namespace RutinApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Active { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string SchemaName { get; set; } // Campo para almacenar el esquema de base de datos del cliente

        public User(int id, string username, string password, string role, int active, DateTime? lastUpdated, string schemaName)
        {
            Id = id;
            Username = username;
            Password = password;
            Role = role;
            Active = active;
            LastUpdated = lastUpdated;
            SchemaName = schemaName;
        }
        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Role = "";
            SchemaName = "";
        }
    }
}
