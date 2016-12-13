using Epam.UserInfo.DalContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.UsersInfo.Entities;
using System.Data.SqlClient;
using System.Configuration;

namespace Epam.UserInfo.DBDal
{
    public class DBAwardDao : IAwardDao
    {
        private static string connectionStr;

        static DBAwardDao()
        {
            connectionStr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        }

        public bool Add(Award award)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO db.[Award] (Title) VALUES (@title); SELECT scope_identity()";

                cmd.Parameters.AddWithValue("@title", award.Title);

                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool Contains(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT ID FROM db.[Award] WHERE ID=@id";
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();

                return reader.Read();
            }
        }

        public bool IsAwarded(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT AwardID FROM db.[UsersAwards] WHERE AwardID=@id";
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();

                return reader.Read();
            }
        }

        public IEnumerable<Award> GetAll()
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT Title, ID FROM db.Award";
                connection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int Id = (int)reader["Id"];
                    string title = (string)reader["Title"];
                    yield return new Award { Title = title, Id = Id };
                }
            }
        }

        public bool Update(int id, Award award)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE db.[Award] SET Title=@title WHERE ID=@id";

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@title", award.Title);

                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public Award GetByID(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = " SELECT ID, Title FROM db.[Award] WHERE ID=@id";
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();
                Award award = null;

                while (reader.Read())
                {
                    int Id = (int)reader["Id"];
                    string title = (string)reader["Title"];
                    award = new Award { Title = title, Id = Id };
                }
                return award;
            }
        }

        public bool Remove(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM db.[Award] WHERE ID=@id";
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();

                return reader.Read();
            }
        }

        public IEnumerable<Award> GetAwardsByIDs(int[] IDs)
        {
            for (int i = 0; i < IDs.Length; i++)
            {
                yield return this.GetByID(IDs[i]);
            }
        }

        public int GetMaxId()
        {
            throw new NotImplementedException();
        }
    }

}
