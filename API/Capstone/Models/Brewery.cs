using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Brewery
    {
        public int BreweryId { get; set; }
        public string Name { get; set; }
        public int BrewerId { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int zip { get; set; }
        public string phone { get; set; }
        public string History { get; set; }
        public bool IsActive { get; set; }
    }
}
