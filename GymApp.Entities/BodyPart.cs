using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Entities
{
    public class BodyPart
    {   
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
