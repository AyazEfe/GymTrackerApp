using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Entities
{
    public class ExerciseLog
    {
        public int Id { get; set; }
        public int SetNumber { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }
        public string WeightUnit { get; set; } = "KG";
        public int WorkoutSessionId { get; set; }
        public WorkoutSession WorkoutSession { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
