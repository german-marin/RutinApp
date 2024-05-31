using RutinApp.Controllers;

namespace RutinApp.Models
{
    public class Training
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CustomerID { get; set; }
        public string Notes { get; set; }
        public string Days { get; set; }

        public Training(int id, string description, DateTime startDate, DateTime endDate, int idClient, string notes, string days)
        {
            ID = id;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            CustomerID = idClient;
            Notes = notes;
            Days = days;
        }
    }
}
