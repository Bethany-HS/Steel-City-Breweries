﻿using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IBreweryReviewDAO
    {
        List<BreweryReview> GetBreweryReviews(int id);
        BreweryReview AddBreweryReview(BreweryReview breweryReview);
    }
}
