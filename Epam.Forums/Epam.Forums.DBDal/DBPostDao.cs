using Epam.Forums.DalContracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Forums.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Epam.Forums.DBDal
{
    public class DBPostDao : IPostDao
    {
        private static string connectionStr;

        static DBPostDao()
        {
            connectionStr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        }

        public bool AddPost(Post post)
        {
            using (var connection = new SqlConnection(connectionStr))
            {

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "AddPost";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userLogin", post.UserLogin);
                cmd.Parameters.AddWithValue("@text", post.Text);
                cmd.Parameters.AddWithValue("@createDate", post.CreateDate);
                cmd.Parameters.AddWithValue("@topicTitle", post.TopicTitle);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool EditPost(int id, string text)
        {

            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UpdatePost";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@text", text);


                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool RemovePost(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "RemovePost";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();

                return reader.Read();
            }
        }
    }
}
