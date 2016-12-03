using Epam.UserInfo.DalContracts;
using Epam.UserInfo.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UserInfo.FileDao
{
    public class DataBaseDao : IDBDao
    {
        private static string connectionStr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public IEnumerable<Award> GetAll()
        {
            List<Award> awards = new List<Award>();
            using (var connection = new SqlConnection(connectionStr))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM [dbo].[Award]";
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    string title = (string)reader["Title"];
                    awards.Add(new Award(id, title));
                }
            }
            return awards;
        }
    }
}