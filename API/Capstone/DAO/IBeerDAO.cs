using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IBeerDAO
    {
        Beer GetBeer(int id);
        List<Beer> GetBeers();
        //pass in beer object to AddBeer
        Beer AddBeer(Beer beer);
    }
}
