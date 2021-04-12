using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;


namespace Capstone.DAO
{
    public class BrewerSqlDAO: IBrewerDAO
    {
            private readonly string connectionString;

            public BrewerSqlDAO(string dbConnectionString)
            {
                connectionString = dbConnectionString;
            }
        public Brewer AddBrewer(Brewer brewer)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "INSERT into Brewer (user_id, brewry_id, name) values (@user_id, @brewry_id, @name);";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@user_id", brewer.UserId);
                    cmd.Parameters.AddWithValue("@brewry_id", brewer.BreweryId);
                    cmd.Parameters.AddWithValue("@name", brewer.Name);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {

                throw;
            }
            return brewer;
        }
     }
    
}
