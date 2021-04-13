using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class BreweryImagesSqlDAO : IBreweryImagesDAO
    {
        private readonly string connectionString;

        public BreweryImagesSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public List<BreweryImages> GetBreweryImages(int id)
        {
            List<BreweryImages> BreweryImages = new List<BreweryImages>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT brewery_img_path FROM brewery_images WHERE brewery_id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        BreweryImages returnBreweryImages = new BreweryImages();
                        returnBreweryImages.BreweryImgPath = Convert.ToString(reader["brewery_img_path"]);

                        BreweryImages.Add(returnBreweryImages);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return BreweryImages;
        }
    }
}
