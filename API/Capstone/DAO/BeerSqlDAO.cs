﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class BeerSqlDAO : IBeerDAO
    {
        private readonly string connectionString;

        public BeerSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Beer GetBeer(int id)
        {
            Beer returnBeer = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT beer_id, brewery_id, beer_type_id, name, abv, description, ingredients FROM beers WHERE beer_id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        returnBeer = GetBeerFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnBeer;
        }

        public List<Beer> GetBeers()
        {
            List<Beer> beerList = new List<Beer>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * from beers");
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Beer currentBeer = GetBeerFromReader(reader);
                        beerList.Add(currentBeer);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return beerList;

        }

        public Beer AddBeer(Beer beer)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO beers (name, abv, brewey_id, beer_type_id, description, ingredients) VALUES (@name, @breweryId, @beerTypeId, @abv, @description, @ingredients)", conn);
                    cmd.Parameters.AddWithValue("@name", beer.Name);
                    cmd.Parameters.AddWithValue("@breweryId", beer.BreweryId);
                    cmd.Parameters.AddWithValue("@beerTypeId", beer.BeerTypeId);
                    cmd.Parameters.AddWithValue("@abv", beer.Abv);
                    cmd.Parameters.AddWithValue("@description", beer.Description);
                    cmd.Parameters.AddWithValue("@ingredients", beer.Ingredients);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return beer;
        }

        private Beer GetBeerFromReader(SqlDataReader reader)
            {
                Beer beer = new Beer()
                {
                    BeerId = Convert.ToInt32(reader["beer_id"]),
                    BreweryId = Convert.ToInt32(reader["brewery_id"]),
                    BeerTypeId = Convert.ToInt32(reader["beer_type_id"]),
                    Name = Convert.ToString(reader["name"]),
                    Abv = Convert.ToDecimal(reader["abv"]),
                    Description = Convert.ToString(reader["description"]),
                    Ingredients = Convert.ToString(reader["ingredients"]),
                };

                return beer;
            }
    }
}
