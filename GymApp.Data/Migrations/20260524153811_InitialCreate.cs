using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyParts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodyPartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_BodyParts_BodyPartId",
                        column: x => x.BodyPartId,
                        principalTable: "BodyParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutPlans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutPlanExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    WorkoutPlanId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPlanExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutPlanExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutPlanExercises_WorkoutPlans_WorkoutPlanId",
                        column: x => x.WorkoutPlanId,
                        principalTable: "WorkoutPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WorkoutPlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutSessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutSessions_WorkoutPlans_WorkoutPlanId",
                        column: x => x.WorkoutPlanId,
                        principalTable: "WorkoutPlans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExercisesLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetNumber = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    WeightUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkoutSessionId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisesLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExercisesLog_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExercisesLog_WorkoutSessions_WorkoutSessionId",
                        column: x => x.WorkoutSessionId,
                        principalTable: "WorkoutSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BodyParts",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Chest" },
                    { 2, "Back" },
                    { 3, "Legs" },
                    { 4, "Shoulders" },
                    { 5, "Arms" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "BodyPartId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Barbell chest press on a flat bench.", "Bench Press" },
                    { 2, 1, "Dumbbell press on an incline bench.", "Incline Dumbbell Press" },
                    { 3, 1, "Bodyweight push-ups on the floor.", "Push-Ups" },
                    { 4, 1, "High-to-low chest fly using cables.", "Cable Crossover" },
                    { 5, 1, "Flat bench chest flyes with dumbbells.", "Dumbbell Flyes" },
                    { 6, 1, "Barbell press on a decline bench.", "Decline Barbell Press" },
                    { 7, 1, "Seated chest press using a machine.", "Machine Chest Press" },
                    { 8, 1, "Seated chest fly using the pec deck machine.", "Pec Deck Fly" },
                    { 9, 1, "Bodyweight dips leaning forward to target chest.", "Chest Dips" },
                    { 10, 1, "Lying dumbbell pullover for lower chest.", "Dumbbell Pullover" },
                    { 11, 2, "Overhand grip bodyweight pull-ups.", "Pull-Up" },
                    { 12, 2, "Bent-over barbell row.", "Barbell Row" },
                    { 13, 2, "Wide-grip cable pulldown.", "Lat Pulldown" },
                    { 14, 2, "Conventional barbell deadlift.", "Deadlift" },
                    { 15, 2, "Close-grip seated row with cables.", "Seated Cable Row" },
                    { 16, 2, "Heavy T-Bar rowing machine or landmine.", "T-Bar Row" },
                    { 17, 2, "Bent-over row using one arm supported by a bench.", "Single-Arm Dumbbell Row" },
                    { 18, 2, "Cable pulldown keeping arms straight to isolate lats.", "Straight-Arm Pulldown" },
                    { 19, 2, "Rope face pulls targeting upper back.", "Face Pulls" },
                    { 20, 2, "Hyperextensions for the lower back.", "Back Extension" },
                    { 21, 3, "Traditional barbell back squat.", "Squat" },
                    { 22, 3, "Seated machine leg extension.", "Leg Extension" },
                    { 23, 3, "Machine seated leg press.", "Leg Press" },
                    { 24, 3, "Straight-leg barbell RDL for hamstrings.", "Romanian Deadlift" },
                    { 25, 3, "Machine lying leg curl for hamstrings.", "Lying Leg Curl" },
                    { 26, 3, "Dumbbell walking lunges.", "Walking Lunges" },
                    { 27, 3, "Standing barbell or machine calf raises.", "Calf Raises" },
                    { 28, 3, "Single-leg squat with rear foot elevated.", "Bulgarian Split Squat" },
                    { 29, 3, "Machine hack squat.", "Hack Squat" },
                    { 30, 3, "Barbell hip thrusts/glute bridges.", "Glute Bridge" },
                    { 31, 4, "Standing strict barbell military press.", "Overhead Press" },
                    { 32, 4, "Standing dumbbell lateral raises.", "Lateral Raise" },
                    { 33, 4, "Dumbbell front raises for anterior delts.", "Front Raise" },
                    { 34, 4, "Seated rotating dumbbell press.", "Arnold Press" },
                    { 35, 4, "Machine flyes for rear deltoids.", "Reverse Pec Deck" },
                    { 36, 4, "Barbell upright row.", "Upright Row" },
                    { 37, 4, "Single-arm lateral raise using a low cable.", "Cable Lateral Raise" },
                    { 38, 4, "Overhead press with slight leg drive.", "Push Press" },
                    { 39, 4, "Seated machine overhead press.", "Machine Shoulder Press" },
                    { 40, 4, "Heavy dumbbell shrugs for traps.", "Dumbbell Shrugs" },
                    { 41, 5, "Standing straight barbell bicep curl.", "Barbell Bicep Curl" },
                    { 42, 5, "Cable rope pushdown for triceps.", "Triceps Pushdown" },
                    { 43, 5, "Dumbbell curl with neutral grip.", "Hammer Curl" },
                    { 44, 5, "Dumbbell or cable overhead extension.", "Overhead Triceps Extension" },
                    { 45, 5, "EZ-Bar bicep curl on a preacher bench.", "Preacher Curl" },
                    { 46, 5, "Lying EZ-Bar triceps extensions.", "Skull Crushers" },
                    { 47, 5, "Seated single-arm dumbbell bicep curl.", "Concentration Curl" },
                    { 48, 5, "Triceps dips using a flat bench.", "Bench Dips" },
                    { 49, 5, "Standing straight-bar cable curl.", "Cable Bicep Curl" },
                    { 50, 5, "Barbell bench press with a narrow grip for triceps.", "Close-Grip Bench Press" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_BodyPartId",
                table: "Exercises",
                column: "BodyPartId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisesLog_ExerciseId",
                table: "ExercisesLog",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisesLog_WorkoutSessionId",
                table: "ExercisesLog",
                column: "WorkoutSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlanExercises_ExerciseId",
                table: "WorkoutPlanExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlanExercises_WorkoutPlanId",
                table: "WorkoutPlanExercises",
                column: "WorkoutPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlans_UserId",
                table: "WorkoutPlans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_UserId",
                table: "WorkoutSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_WorkoutPlanId",
                table: "WorkoutSessions",
                column: "WorkoutPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExercisesLog");

            migrationBuilder.DropTable(
                name: "WorkoutPlanExercises");

            migrationBuilder.DropTable(
                name: "WorkoutSessions");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "WorkoutPlans");

            migrationBuilder.DropTable(
                name: "BodyParts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
