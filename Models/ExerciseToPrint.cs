
namespace RutinApp.Models
{
    public class ExerciseToPrint
    {
        public string Title { get; set; }
        public string Sets { get; set; }
        public string Repetitions { get; set; }
        public string Weight { get; set; }
        public string Recovery { get; set; }
        public string Others { get; set; }
        public string Notes { get; set; }
        public string Image { get; set; }
        public string StartDate {  get; set; }
        public string EndDate { get; set; }
        public string CustomerName {  get; set; }
        public int CustomerID { get; set; }
        public string GeneralNotes {  get; set; }
        public string Days { get; set; }

        public ExerciseToPrint(string title, string sets, string repetition, string weight, string recovery, string others, string notes, string image, string startDate, string endDate, string customerName, int customerID, string generalNotes, string days)
        { 
            Title = title;
            Sets = sets; 
            Repetitions = repetition; 
            Weight = weight;
            Recovery= recovery;
            Others = others;
            Notes = notes;
            Image = image;
            StartDate = startDate;
            EndDate = endDate;
            CustomerName = customerName;
            CustomerID = customerID;
            GeneralNotes = generalNotes;
            Days = days;
        }
    }
}
