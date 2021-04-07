using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class BreweryReviewSqlDAO
    {
        private readonly string connectionString;

        public BreweryReviewSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<BreweryReview> GetBreweryReviews(int id)
        {
            List<BreweryReview> breweryReviews = new List<BreweryReview>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "Select * from brewery_reviews where brewery_id = '@id";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        BreweryReview currentReview = GetBreweryReviewsFromReader(reader);
                        breweryReviews.Add(currentReview);

                    }
                    return breweryReviews;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public BreweryReview AddBreweryReview(BreweryReview review)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlText = "INSERT INTO beer_reviews ('brewery_id', 'rating', 'review') values (@breweryId, @review, @rating)";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@breweryId", review.BreweryId);
                    cmd.Parameters.AddWithValue("@review", review.Review);
                    cmd.Parameters.AddWithValue("@rating", review.BreweryRating);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return review;
        }

        private BreweryReview GetBreweryReviewsFromReader(SqlDataReader reader)
        {
            BreweryReview beerReview = new BreweryReview()
            {
                BreweryReviewId = Convert.ToInt32(reader["brewery_review_id"]),
                BreweryId = Convert.ToInt32(reader["brewery_id"]),                
                Review = Convert.ToString(reader["review"]),
                BreweryRating = Convert.ToInt32(reader["rating"]),
            };
            return beerReview;

        }
    }
}
