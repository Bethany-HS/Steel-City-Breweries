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
    public class BrewerController : ControllerBase
    {
        private readonly IBrewerDAO brewerDAO;

        public BrewerController(IBrewerDAO _brewerDAO)
        {
            brewerDAO = _brewerDAO;
        }

        [HttpPost]
        public ActionResult<Brewer> AddBreweryReview(Brewer brewer)
        {
            Brewer newBrewer = brewerDAO.AddBrewer(brewer);
            return Created($"/brewer/{newBrewer}", newBrewer);

        }
    }
}
