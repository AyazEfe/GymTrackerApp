using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Entities
{
    public class Exercise
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int BodyPartId { get; set; }
        public BodyPart BodyPart { get; set; } //This is the navigation property. It is the bridge between exercise table and bodypart table
    }
}
