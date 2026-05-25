using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Entities
{
    public class WorkoutPlan
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public List<WorkoutPlanExercise> WorkoutPlanExercise { get; set; } = new List<WorkoutPlanExercise>();
    }
}
