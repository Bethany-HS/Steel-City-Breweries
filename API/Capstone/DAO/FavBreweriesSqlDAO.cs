using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class FavBreweriesSqlDAO : IFavBreweriesDAO
    {
        private readonly string connectionString;

        public FavBreweriesSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<FavBreweries> GetFavoriteBreweries(int id)
        {
            List<FavBreweries> favorites = new List<FavBreweries>();
            
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "SELECT brewery_id from users_favBreweries where user_id = @userId";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@userId", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        FavBreweries favBreweries = new FavBreweries();
                        favBreweries.BreweryID = Convert.ToInt32(reader["brewery_id"]);

                        favorites.Add(favBreweries);
                    }

                    return favorites;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public FavBreweries GetFav(int id)
        {
            FavBreweries fav = null;
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlText = "SELECT user_id from user_favBreweries where brewer_id = @brewerId";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@brewerId", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        fav.UserId = Convert.ToInt32(reader["user_id"]);
                    }
                    return fav;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DeleteFav(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "DELETE from users_favBreweries where brewer_id = @brewerId";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@brewrId", id);

                    cmd.ExecuteNonQuery();
                   

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
