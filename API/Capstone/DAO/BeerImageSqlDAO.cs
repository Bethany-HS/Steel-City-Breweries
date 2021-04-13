using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class BeerImageSqlDAO : IBeerImagesDAO
    {
        private readonly string connectionString;

        public BeerImageSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public BeerImages GetImages(int id)
        {
            BeerImages returnBeerImages = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT beer_img_path FROM beer_images WHERE brewery_id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        returnBeerImages.BeerImgPath = Convert.ToString(reader["beer_img_path"]);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnBeerImages;
        }

    }
}
