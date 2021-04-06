using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Brewer
    {
        public int BrewerId { get; set; }
        public int UserId { get; set; }
        public int BreweryId { get; set; }
        public string Name { get; set; }
    }
}
