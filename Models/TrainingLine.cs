using RutinApp.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutinApp.Models
{
    public class TrainingLine
    {
        public int ID { get; set; }
        public int ExerciseID { get; set; }
        public int TrainingID { get; set; }
        public string Sets { get; set; }
        public string Repetitions { get; set; }
        public string Weight { get; set; }
        public string Recovery { get; set; }
        public string Others { get; set; }
        public string Notes { get; set; } 
        public string Grip { get; set; }

        public TrainingLine(int iD, int idExercise, int idTraining, string series, string repetition, string weight, string recovery, string others, string notes, string grip)
        {
            ID = iD;
            ExerciseID = idExercise;
            TrainingID = idTraining;
            Sets = series;
            Repetitions = repetition;
            Weight = weight;
            Recovery = recovery;
            Others = others;
            Notes = notes;    
            Grip = grip;
        }

    }
}
