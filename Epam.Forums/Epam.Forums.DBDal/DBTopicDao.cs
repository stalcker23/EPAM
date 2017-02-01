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
    public class DBTopicDao : ITopicDao
    {
        private static string connectionStr;

        static DBTopicDao()
        {
            connectionStr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        }

        public bool AddTopic(Topic topic)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "AddTopic";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userLogin", topic.UserLogin);
                cmd.Parameters.AddWithValue("@title", topic.Title);
                cmd.Parameters.AddWithValue("@createDate", topic.CreateDate);
                cmd.Parameters.AddWithValue("@description", topic.Description);
                cmd.Parameters.AddWithValue("@forumName", topic.ForumName);
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public int CountOfPosts(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "CountOfPosts";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                connection.Open();

                int result = (int)cmd.ExecuteScalar();
                return result;
            }
        }
        public bool ModerateTopic(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "ModerateTopic";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@id", id);


                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }
        public bool EditTopic(int id, string title, string description)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UpdateTopic";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@modifyDate", DateTime.Now);


                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }
        public IEnumerable<Topic> FindTopics(string title, string author,string forum)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "FindTopics";
                cmd.CommandType = CommandType.StoredProcedure;
                if(forum=="All")
                {
                    cmd.Parameters.AddWithValue("@forum", "");
                }
                else
                {
                cmd.Parameters.AddWithValue("@forum", forum);
                }
                cmd.Parameters.AddWithValue("@author", author);
                cmd.Parameters.AddWithValue("@title", title);
                connection.Open();
                var reader = cmd.ExecuteReader();
                DateTime nullDate = DateTime.MinValue;
                while (reader.Read())
                {
                    int Id = (int)reader["Id"];
                    string titleName = (string)reader["Title"];
                    string userLogin = (string)reader["Login"];
                    string forumName = (string)reader["Name"];
                    DateTime createDate = (DateTime)reader["CreateDate"];
                    DateTime? modifyDate = reader["ModifyDate"] is DBNull ? null : (DateTime?)reader["ModifyDate"];
                    DateTime? lockDate = reader["LockDate"] is DBNull ? null : (DateTime?)reader["LockDate"];
                    string description = (string)reader["Description"];
                    bool isPublic = (bool)reader["IsPublic"];


                    yield return new Topic { ID = Id, CreateDate = createDate, Description = description, UserLogin = userLogin, Title = titleName, ForumName = forumName, IsPublic = isPublic, LockDate = lockDate, ModifyDate = modifyDate };
                }
            }
        }
        public int GetForumIdByTopicId(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetForumIdByTopicId";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                int result = -1;
                while (reader.Read())
                {
                    int Id = (int)reader["ForumID"];                    
                    result = Id;
                }
                return result;
            }
        }
      

        public IEnumerable<Post> GetPostsByTopicId(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetPostsByTopicId";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                DateTime nullDate = DateTime.MinValue;
                while (reader.Read())
                {
        
                    int Id = (int)reader["Id"];
                    string userLogin = (string)reader["Login"];                   
                    string topicTitle = (string)reader["Title"];
                    DateTime createDate = (DateTime)reader["CreateDate"];
                    string text = (string)reader["Text"];                  
                    
                    yield return new Post { ID = Id, CreateDate = createDate, UserLogin = userLogin,TopicTitle = topicTitle, Text = text };
                }
            }
        }

        public Topic GetTopicById(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetTopicByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();
                Topic topic = null;

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
                    int imageID = (int)reader["ImageID"];
                    topic = new Topic { ID = Id, CreateDate = createDate, Description = description, UserLogin = userLogin, Title = title, ForumName = forumName, IsPublic = isPublic, LockDate = lockDate, ModifyDate = modifyDate, Photo = new Photo(imageID) };
                }
                return topic;
            }
        }

        public bool RemoveTopic(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "RemoveTopic";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();

                return reader.Read();
            }
        }
    }
}
