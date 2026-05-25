using GymApp.Business.Abstract;
using GymApp.Business.Concrete;
using GymApp.Data.Abstract;
using GymApp.Data.Concrete;
using GymApp.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });
            builder.Services.AddScoped<IAppUserDal, EfCoreAppUserDal>();
            builder.Services.AddScoped<IBodyPartDal, EfCoreBodyPartDal>();
            builder.Services.AddScoped<IExerciseDal, EfCoreExerciseDal>();
            builder.Services.AddScoped<IExerciseLogDal, EfCoreExerciseLogDal>();
            builder.Services.AddScoped<IWorkoutPlanDal, EfCoreWorkoutPlanDal>();
            builder.Services.AddScoped<IWorkoutPlanExerciseDal, EfCoreWorkoutPlanExerciseDal>();
            builder.Services.AddScoped<IWorkoutSessionDal, EfCoreWorkoutSessionDal>();
            builder.Services.AddScoped<IAppUserService, AppUserManager>();
            builder.Services.AddScoped<IBodyPartService, BodyPartManager>();
            builder.Services.AddScoped<IExerciseService, ExerciseManager>();
            builder.Services.AddScoped<IExerciseLogService, ExerciseLogManager>();
            builder.Services.AddScoped<IWorkoutPlanService, WorkoutPlanManager>();
            builder.Services.AddScoped<IWorkoutPlanExerciseService, WorkoutPlanExerciseManager>();
            builder.Services.AddScoped<IWorkoutSessionService, WorkoutSessionManager>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
