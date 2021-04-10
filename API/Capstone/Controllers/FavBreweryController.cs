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
    public class FavBreweryController : ControllerBase
    {
        private readonly IFavBreweriesDAO favBreweryDAO;

        public FavBreweryController(IFavBreweriesDAO _favBreweryDAO)
        {
            favBreweryDAO = _favBreweryDAO;
        }

        [HttpGet("{id}")]
        public ActionResult<List<FavBreweries>> GetFavoriteBreweries(int id)
        {
            List<FavBreweries> favsList = favBreweryDAO.GetFavoriteBreweries(id);
            if (favsList != null)
            {
                return Ok(favsList);
            }
            else
            {
                return NotFound("Reviews not found");
            }
            
        }

        [HttpDelete("{id}")]
        public ActionResult<FavBreweries> DeleteFav(int id)
        {
            FavBreweries favBreweries = favBreweryDAO.GetFav(id);
            if (favBreweries == null)
            {
                return NotFound("Id does not exist");
            }
            favBreweryDAO.DeleteFav(id);
            return NoContent();
        }


    }
}
