﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class BreweryReview
    {
        public int BreweryRatingId { get; set; }
        public int BreweryId { get; set; }
        public int BreweryRating { get; set; }
        public string Review { get; set; }
    }
}
