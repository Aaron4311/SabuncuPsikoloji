using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Psychologist : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PsychologistUrl { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
    }
}
