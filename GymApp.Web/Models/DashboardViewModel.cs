namespace GymApp.Web.Models
{
    public class DashboardViewModel
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int CurrentExp { get; set; }
        public int MaxExp { get; set; }

        public int TotalWorkouts { get; set; }
        public int TotalTimeHours { get; set; }
        public decimal TotalVolume { get; set; }
    }
}
