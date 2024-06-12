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


        public User(int id, string username, string password, string role, int active, DateTime? lastUpdated)
        {
            Id = id;
            Username = username;
            Password = password;
            Role = role;
            Active = active;
            LastUpdated = lastUpdated;
        }
        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Role = "";
        }
    }
}
