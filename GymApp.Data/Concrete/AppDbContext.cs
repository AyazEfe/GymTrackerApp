using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GymApp.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace GymApp.Data.Concrete

{
    public class AppDbContext : IdentityDbContext <AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<BodyPart> BodyParts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseLog> ExercisesLog { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<WorkoutPlanExercise> WorkoutPlanExercises { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<SavedSet> SavedSets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BodyPart>().HasData(
                new BodyPart { Id = 1, Name = "Chest" },
                new BodyPart { Id = 2, Name = "Back" },
                new BodyPart { Id = 3, Name = "Legs" },
                new BodyPart { Id = 4, Name = "Shoulders" },
                new BodyPart { Id = 5, Name = "Arms" }
            );
modelBuilder.Entity<Exercise>().HasData(
    new Exercise { Id = 1, Name = "Bench Press", Description = "Barbell chest press on a flat bench.", BodyPartId = 1 },
    new Exercise { Id = 2, Name = "Incline Dumbbell Press", Description = "Dumbbell press on an incline bench.", BodyPartId = 1 },
    new Exercise { Id = 3, Name = "Push-Ups", Description = "Bodyweight push-ups on the floor.", BodyPartId = 1 },
    new Exercise { Id = 4, Name = "Cable Crossover", Description = "High-to-low chest fly using cables.", BodyPartId = 1 },
    new Exercise { Id = 5, Name = "Dumbbell Flyes", Description = "Flat bench chest flyes with dumbbells.", BodyPartId = 1 },
    new Exercise { Id = 6, Name = "Decline Barbell Press", Description = "Barbell press on a decline bench.", BodyPartId = 1 },
    new Exercise { Id = 7, Name = "Machine Chest Press", Description = "Seated chest press using a machine.", BodyPartId = 1 },
    new Exercise { Id = 8, Name = "Pec Deck Fly", Description = "Seated chest fly using the pec deck machine.", BodyPartId = 1 },
    new Exercise { Id = 9, Name = "Chest Dips", Description = "Bodyweight dips leaning forward to target chest.", BodyPartId = 1 },
    new Exercise { Id = 10, Name = "Dumbbell Pullover", Description = "Lying dumbbell pullover for lower chest.", BodyPartId = 1 },

    new Exercise { Id = 11, Name = "Pull-Up", Description = "Overhand grip bodyweight pull-ups.", BodyPartId = 2 },
    new Exercise { Id = 12, Name = "Barbell Row", Description = "Bent-over barbell row.", BodyPartId = 2 },
    new Exercise { Id = 13, Name = "Lat Pulldown", Description = "Wide-grip cable pulldown.", BodyPartId = 2 },
    new Exercise { Id = 14, Name = "Deadlift", Description = "Conventional barbell deadlift.", BodyPartId = 2 },
    new Exercise { Id = 15, Name = "Seated Cable Row", Description = "Close-grip seated row with cables.", BodyPartId = 2 },
    new Exercise { Id = 16, Name = "T-Bar Row", Description = "Heavy T-Bar rowing machine or landmine.", BodyPartId = 2 },
    new Exercise { Id = 17, Name = "Single-Arm Dumbbell Row", Description = "Bent-over row using one arm supported by a bench.", BodyPartId = 2 },
    new Exercise { Id = 18, Name = "Straight-Arm Pulldown", Description = "Cable pulldown keeping arms straight to isolate lats.", BodyPartId = 2 },
    new Exercise { Id = 19, Name = "Face Pulls", Description = "Rope face pulls targeting upper back.", BodyPartId = 2 },
    new Exercise { Id = 20, Name = "Back Extension", Description = "Hyperextensions for the lower back.", BodyPartId = 2 },

    new Exercise { Id = 21, Name = "Squat", Description = "Traditional barbell back squat.", BodyPartId = 3 },
    new Exercise { Id = 22, Name = "Leg Extension", Description = "Seated machine leg extension.", BodyPartId = 3 },
    new Exercise { Id = 23, Name = "Leg Press", Description = "Machine seated leg press.", BodyPartId = 3 },
    new Exercise { Id = 24, Name = "Romanian Deadlift", Description = "Straight-leg barbell RDL for hamstrings.", BodyPartId = 3 },
    new Exercise { Id = 25, Name = "Lying Leg Curl", Description = "Machine lying leg curl for hamstrings.", BodyPartId = 3 },
    new Exercise { Id = 26, Name = "Walking Lunges", Description = "Dumbbell walking lunges.", BodyPartId = 3 },
    new Exercise { Id = 27, Name = "Calf Raises", Description = "Standing barbell or machine calf raises.", BodyPartId = 3 },
    new Exercise { Id = 28, Name = "Bulgarian Split Squat", Description = "Single-leg squat with rear foot elevated.", BodyPartId = 3 },
    new Exercise { Id = 29, Name = "Hack Squat", Description = "Machine hack squat.", BodyPartId = 3 },
    new Exercise { Id = 30, Name = "Glute Bridge", Description = "Barbell hip thrusts/glute bridges.", BodyPartId = 3 },

    new Exercise { Id = 31, Name = "Overhead Press", Description = "Standing strict barbell military press.", BodyPartId = 4 },
    new Exercise { Id = 32, Name = "Lateral Raise", Description = "Standing dumbbell lateral raises.", BodyPartId = 4 },
    new Exercise { Id = 33, Name = "Front Raise", Description = "Dumbbell front raises for anterior delts.", BodyPartId = 4 },
    new Exercise { Id = 34, Name = "Arnold Press", Description = "Seated rotating dumbbell press.", BodyPartId = 4 },
    new Exercise { Id = 35, Name = "Reverse Pec Deck", Description = "Machine flyes for rear deltoids.", BodyPartId = 4 },
    new Exercise { Id = 36, Name = "Upright Row", Description = "Barbell upright row.", BodyPartId = 4 },
    new Exercise { Id = 37, Name = "Cable Lateral Raise", Description = "Single-arm lateral raise using a low cable.", BodyPartId = 4 },
    new Exercise { Id = 38, Name = "Push Press", Description = "Overhead press with slight leg drive.", BodyPartId = 4 },
    new Exercise { Id = 39, Name = "Machine Shoulder Press", Description = "Seated machine overhead press.", BodyPartId = 4 },
    new Exercise { Id = 40, Name = "Dumbbell Shrugs", Description = "Heavy dumbbell shrugs for traps.", BodyPartId = 4 },

    new Exercise { Id = 41, Name = "Barbell Bicep Curl", Description = "Standing straight barbell bicep curl.", BodyPartId = 5 },
    new Exercise { Id = 42, Name = "Triceps Pushdown", Description = "Cable rope pushdown for triceps.", BodyPartId = 5 },
    new Exercise { Id = 43, Name = "Hammer Curl", Description = "Dumbbell curl with neutral grip.", BodyPartId = 5 },
    new Exercise { Id = 44, Name = "Overhead Triceps Extension", Description = "Dumbbell or cable overhead extension.", BodyPartId = 5 },
    new Exercise { Id = 45, Name = "Preacher Curl", Description = "EZ-Bar bicep curl on a preacher bench.", BodyPartId = 5 },
    new Exercise { Id = 46, Name = "Skull Crushers", Description = "Lying EZ-Bar triceps extensions.", BodyPartId = 5 },
    new Exercise { Id = 47, Name = "Concentration Curl", Description = "Seated single-arm dumbbell bicep curl.", BodyPartId = 5 },
    new Exercise { Id = 48, Name = "Bench Dips", Description = "Triceps dips using a flat bench.", BodyPartId = 5 },
    new Exercise { Id = 49, Name = "Cable Bicep Curl", Description = "Standing straight-bar cable curl.", BodyPartId = 5 },
    new Exercise { Id = 50, Name = "Close-Grip Bench Press", Description = "Barbell bench press with a narrow grip for triceps.", BodyPartId = 5 }
);
            
        }
    }
}
