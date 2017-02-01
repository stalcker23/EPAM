using Epam.Forums.DalContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Forums.Entities;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Epam.Forums.DBDal
{
    public class DBForumDao : IForumDao
    {
        private static string connectionStr;

        static DBForumDao()
        {
            connectionStr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        }
        public bool AddForum(Forum forum)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "AddForum";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", forum.Name);
                cmd.Parameters.AddWithValue("@description", forum.Description);
                cmd.Parameters.AddWithValue("@createDate", forum.CreateDate);
                cmd.Parameters.AddWithValue("@userLogin", forum.UserLogin);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool ContainsForum(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "ContainsForum";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();

                return reader.Read();
            }
        }

        public int CountOfTopics(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "CountOfTopics";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@id", id);              
                
                connection.Open();

                int result = (int)cmd.ExecuteScalar();
                return result;
            }
        }

        public bool EditForum(int id, string name, string description)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UpdateForum";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", description);


                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public IEnumerable<Forum> GetAllForums()
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetAllForums";
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int Id = (int)reader["Id"];
                    string name = (string)reader["Name"];
                    DateTime createDate = (DateTime)reader["CreateDate"];
                    string description = (string)reader["Description"];
                    string userLogin = (string)reader["Login"];
                    yield return new Forum { ID = Id, Name = name, CreateDate = createDate, Description = description, UserLogin = userLogin };
                }
            }
        }

        public Forum GetForumByID(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetForumByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();
                Forum forum = null;

                while (reader.Read())
                {
                    int Id = (int)reader["Id"];
                    string name = (string)reader["Name"];
                    DateTime createDate = (DateTime)reader["CreateDate"];
                    string description = (string)reader["Description"];
                    string userLogin = (string)reader["Login"];
                    forum = new Forum { ID = Id, Name = name, CreateDate = createDate, Description = description, UserLogin = userLogin };
                }
                return forum;
            }
        }

        public Forum GetForumByName(string forumName)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetForumByName";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", forumName);
                connection.Open();

                var reader = cmd.ExecuteReader();
                Forum forum = null;

                while (reader.Read())
                {
                    int Id = (int)reader["Id"];
                    string name = (string)reader["Name"];
                    DateTime createDate = (DateTime)reader["CreateDate"];
                    string description = (string)reader["Description"];
                    string userLogin = (string)reader["Login"];
                    forum = new Forum { ID = Id, Name = name, CreateDate = createDate, Description = description, UserLogin = userLogin };
                }
                return forum;
            }
        }

        public IEnumerable<Topic> GetTopicsByForumId(int id)
        {
      
           using (var connection = new SqlConnection(connectionStr))
           {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetTopicsByForumId";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                DateTime nullDate = DateTime.MinValue;
                while (reader.Read())
                {
                    int Id = (int)reader["Id"];
                    string title = (string)reader["Title"];
                    string userLogin = (string)reader["Login"];
                    string forumName = (string)reader["Name"];
                    DateTime createDate = (DateTime)reader["CreateDate"];
                    DateTime? modifyDate = reader["ModifyDate"] is DBNull ? null : (DateTime?)reader["ModifyDate"];
                    DateTime? lockDate = reader["LockDate"] is DBNull ? null : (DateTime?)reader["LockDate"];
                    string description = (string)reader["Description"];
                    bool isPublic = (bool)reader["IsPublic"];
                     

                    yield return new Topic { ID = Id, CreateDate = createDate, Description = description, UserLogin = userLogin, Title = title, ForumName=forumName, IsPublic = isPublic, LockDate = lockDate, ModifyDate = modifyDate };
                }
            }
        }

        public bool RemoveForum(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "RemoveForum";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();

                return reader.Read();
            }
        }

    }
}
