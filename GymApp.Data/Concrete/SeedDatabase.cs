using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Data.Concrete
{
    public class SeedDatabase
    {
        public static void Seed(AppDbContext context)
        {
            if(context.Database.GetPendingMigrations().Count() == 0)
            {
                if(context.BodyParts.Count() == 0)
                {
                    context.BodyParts.AddRange(
                        new BodyPart { Name = "Chest" },
                        new BodyPart { Name = "Back" },
                        new BodyPart { Name = "Legs" },
                        new BodyPart { Name = "Arms" },
                        new BodyPart { Name = "Shoulders" },
                        new BodyPart { Name = "Core" }
                    );
                }
                context.SaveChanges();
            }
        }
    }
}
