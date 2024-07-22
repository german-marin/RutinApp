using System.ComponentModel.DataAnnotations;
namespace RutinApp.Models
{
    public class User
    {       
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Logo { get; set; }
        public string Notes { get; set; }
        public int Days { get; set; }
               
        public User(string username, string password)
        {
            Username = username;
            Password = password;           
        }

        public User(int id, string logo, string notes, int days) 
        {
            Id = id;
            Logo = logo;
            Notes = notes;
            Days = days;
        }
        // Constructor vacío para otras operaciones 
        public User() { }
    }
}
