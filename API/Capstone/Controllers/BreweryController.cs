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
    public class BreweryController : ControllerBase
    {
        private readonly IBreweryDAO breweryDAO;

        public BreweryController(IBreweryDAO _breweryDAO)
        {
            breweryDAO = _breweryDAO;
        }

        [HttpGet("{id}")]
        public ActionResult<Brewery> GetBrewery(int id)
        {
            return Ok(breweryDAO.GetBrewery(id));
        }

        [HttpGet]
        public List<Brewery> GetBreweries()
        {
            List<Brewery> breweryList = breweryDAO.GetBreweries();
            return breweryList;
        }

        [HttpPost]
        public ActionResult<Brewery> AddBrewery(Brewery brewery)
        {
            Brewery newBrewery = breweryDAO.AddBrewery(brewery);
            return Created($"/brewery/{newBrewery}", newBrewery);

        }
    }
}
