using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class BrewerySqlDAO : IBreweryDAO
    {
        private readonly string connectionString;

        public BrewerySqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Brewery GetBrewery(int id)
        {
            Brewery returnBrewery = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT brewery_id, name, brewer_id, street_address1, street_address2, city, state, zip, phone, history, isActive FROM breweries WHERE brewery_id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        returnBrewery = GetBreweryFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnBrewery;
        }

        public List<Brewery> GetBreweries()
        {
            List<Brewery> breweryList = new List<Brewery>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from breweries", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Brewery currentBrewery = GetBreweryFromReader(reader);
                        breweryList.Add(currentBrewery);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return breweryList;

        }

        public Brewery AddBrewery(Brewery brewery)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO breweries (name, street_address1, street_address2, city, state, zip, phone, history, isActive) VALUES (@name, @street_address1, @street_address2, @city, @state, @zip, @phone, @history, @isActive)", conn);
                    cmd.Parameters.AddWithValue("@name", brewery.Name);
                    cmd.Parameters.AddWithValue("@street_address1", brewery.StreetAddress1);
                    cmd.Parameters.AddWithValue("@street_address2", brewery.StreetAddress2);
                    cmd.Parameters.AddWithValue("@city", brewery.City);
                    cmd.Parameters.AddWithValue("@state", brewery.State);
                    cmd.Parameters.AddWithValue("@zip", brewery.Zip);
                    cmd.Parameters.AddWithValue("@phone", brewery.Phone);
                    cmd.Parameters.AddWithValue("@history", brewery.History);
                    cmd.Parameters.AddWithValue("@isActive", brewery.IsActive);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return brewery;
        }

        private Brewery GetBreweryFromReader(SqlDataReader reader)
        {
            Brewery brewery = new Brewery()
            {
                BreweryId = Convert.ToInt32(reader["brewery_id"]),
                Name = Convert.ToString(reader["name"]),
                BrewerId = Convert.ToInt32(reader["brewer_id"]),
                StreetAddress1 = Convert.ToString(reader["street_address1"]),
                StreetAddress2 = Convert.ToString(reader["street_adress2"]),
                City = Convert.ToString(reader["city"]),
                State = Convert.ToString(reader["state"]),
                Zip = Convert.ToInt32(reader["zip"]),
                Phone = Convert.ToString(reader["phone"]),
                History = Convert.ToString(reader["history"]),
                IsActive = Convert.ToBoolean(reader["isActive"])


            };

            return brewery;
        }
    }
}
