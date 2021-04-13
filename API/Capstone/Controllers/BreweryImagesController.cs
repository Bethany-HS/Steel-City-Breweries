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
    [Route("api/[controller]")]
    [ApiController]
    public class BreweryImagesController : ControllerBase
    {
        private readonly IBreweryImagesDAO breweryImagesDAO;

        public BreweryImagesController(IBreweryImagesDAO _breweryImagesDAO)
        {
            breweryImagesDAO = _breweryImagesDAO;
        }
        [HttpGet]
        public List<BreweryImages> GetBreweryImages(int id)
        {
            List<BreweryImages> breweryImagesList = breweryImagesDAO.GetBreweryImages(id);
            return breweryImagesList;
        }
    }
}
