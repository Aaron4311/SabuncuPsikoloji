using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Service : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ServiceUrl { get; set; }
        public string ShortText { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        
    }
}
