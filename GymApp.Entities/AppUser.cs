using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GymApp.Entities
{
    public class AppUser : IdentityUser
    {
        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<WorkoutPlan> WorkoutPlans { get; set; } = new List<WorkoutPlan>();
        public List<WorkoutSession> WorkoutSessions { get; set; } = new List<WorkoutSession>();
    }
}
