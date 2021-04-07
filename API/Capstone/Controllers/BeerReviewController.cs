using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BeerReviewController : ControllerBase
    {
        private readonly IBeerReviewDAO beerReviewDAO;

        public BeerReviewController(IBeerReviewDAO _beerReviewDAO)
        {
            beerReviewDAO = _beerReviewDAO;
        }

        [HttpGet("{id}")]
        public ActionResult<List<BeerReview>> GetBeerReviews(int id)
        {
            List<BeerReview> existingReview = beerReviewDAO.GetBeerReviews(id);
            if (existingReview != null)
            {
                return Ok();
            }
            else
            {
                return NotFound("Reviews not found");
            }
            
        }

        [HttpPost]
        public ActionResult<Beer> AddBeerReview(BeerReview review)
        {
            BeerReview newBeerReview = beerReviewDAO.AddBeerReview(review);
            return Created($"/beerreview/{newBeerReview}", newBeerReview);

        }
    }
}
