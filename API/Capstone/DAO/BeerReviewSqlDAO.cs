using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class BeerReviewSqlDAO : IBeerReviewDAO
    {
        private readonly string connectionString;

        public BeerReviewSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<BeerReview> GetBeerReviews(int id)
        {
            List<BeerReview> beerReviews = new List<BeerReview>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "Select * from beer_reviews where beer_id = '@id";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        BeerReview currentReview = GetBeerReviewsFromReader(reader);
                        beerReviews.Add(currentReview);

                    }
                    return beerReviews;
                }
            }
            catch (Exception)
            {

                throw;
            }     
           
        }
        public BeerReview AddBeerReview(BeerReview review)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlText= "INSERT INTO beer_reviews ('beer_id', 'beerRating', 'beerReview') values (@beerId, @beerRating, @beerReview)";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@beerId", review.BeerId);
                    cmd.Parameters.AddWithValue("@beerRating", review.BeerRating);
                    cmd.Parameters.AddWithValue("@beerReview", review.Review);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return review;
        }

        private BeerReview GetBeerReviewsFromReader(SqlDataReader reader)
        {
            BeerReview beerReview = new BeerReview()
            {
                BeerReviewId = Convert.ToInt32(reader["beerReview_id"]),
                BeerId = Convert.ToInt32(reader["beer_id"]),
                BeerRating = Convert.ToInt32(reader["beerRating"]),
                Review = Convert.ToString(reader["beerReview"])
            };
            return beerReview;

        }
    }
}
