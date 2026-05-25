using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Entities
{
    public class WorkoutSession
    {
        public int Id { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsCompleted { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int? WorkoutPlanId { get; set; }
        public WorkoutPlan WorkoutPlan { get; set; }
        public List<ExerciseLog> ExerciseLogs { get; set; } = new List<ExerciseLog>();
        public decimal TotalVolume { get; set; }
        public int DurationMinutes { get; set; }
        public DateTime Date { get; set; } = DateTime.Now; 
        public string RoutineName { get; set; }
        public string SessionDetailsJson { get; set; }
    }
}
