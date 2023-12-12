using RutinApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutinApp.Models
{
    public class TrainingLine
    {
        public int ID { get; set; }
        public int IdExercise { get; set; }
        public int IdTraining { get; set; }
        public string Series { get; set; }
        public string Repetition { get; set; }
        public string Weight { get; set; }
        public string Recovery { get; set; }
        public string Others { get; set; }
        public string Notes { get; set; }

        public TrainingLine(int iD, int idExercise, int idTraining, string series, string repetition, string weight, string recovery, string others, string notes)
        {
            ID = iD;
            IdExercise = idExercise;
            IdTraining = idTraining;
            Series = series;
            Repetition = repetition;
            Weight = weight;
            Recovery = recovery;
            Others = others;
            Notes = notes;
        }        

    }
}
