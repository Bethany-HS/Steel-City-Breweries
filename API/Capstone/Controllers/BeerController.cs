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
    public class BeerController : ControllerBase
    {
        private readonly IBeerDAO beerDAO;

        public BeerController(IBeerDAO _beerDAO)
        {
            beerDAO = _beerDAO;
        }

        [HttpGet("{id}")]
        public ActionResult<Beer> GetBeer(int id)
        {
            return Ok(beerDAO.GetBeer(id));
        }

        [HttpGet]
        public List<Beer> GetBeers()
        {
            List<Beer> beerList = beerDAO.GetBeers();
            return beerList;
        }

        [HttpPost]
        public ActionResult<Beer> AddBeer(Beer beer)
        {
            Beer newBeer = beerDAO.AddBeer(beer);
            return Created($"/beer/{newBeer}", newBeer);

        }
    }
}
