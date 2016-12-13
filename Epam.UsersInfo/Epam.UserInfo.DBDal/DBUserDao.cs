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
    public class DBUserDao : IUserDao
    {
        private static string connectionStr;

        static DBUserDao()
        {
            connectionStr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        }

        public bool Add(User user)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                string[] parts = user.Name.Split('*');
                cmd.CommandText = "INSERT INTO db.[User] (Name, Surname, Patronymic, DateOfBirth) VALUES (@name, @surname, @patronymic, @dateOfBirth); SELECT scope_identity()";

                cmd.Parameters.AddWithValue("@name", parts[0]);
                cmd.Parameters.AddWithValue("@surname", parts[1]);
                cmd.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth);

                if (parts[2] == String.Empty)
                {
                    cmd.Parameters.AddWithValue("@patronymic", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@patronymic", parts[2]);
                }

                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool AddUserAward(int userID, int awardID)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                try
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO db.[UsersAwards] (UserID, AwardID) VALUES (@userID, @awardID); SELECT scope_identity()";

                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@awardID", awardID);
                    connection.Open();

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
                catch
                {
                    throw new InvalidOperationException("User already has the same award!");
                }
            }
        }

        public bool Contains(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT ID FROM db.[User] WHERE ID=@id";
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();

                return reader.Read();
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = " SELECT ID, Name, Surname, Patronymic, DateOfBirth FROM db.[User]";
                connection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int Id = (int)reader["Id"];
                    string patronymic = reader["Patronymic"] is DBNull ? String.Empty : (string)reader["Patronymic"];
                    string name = $"{(string)reader["Name"]} {(string)reader["Surname"]} {patronymic}";
                    DateTime dateOfBirth = (DateTime)reader["DateOfBirth"];
                    yield return new User { Name = name, DateOfBirth = dateOfBirth, Id = Id };
                }
            }
        }
    
        public bool Update(int id, User user)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE db.[User] SET Name=@name, Surname=@surname, Patronymic=@patronymic, DateOfBirth=@dateOfBirth WHERE ID=@id";

                string[] parts = user.Name.Split('*');

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", parts[0]);
                cmd.Parameters.AddWithValue("@surname", parts[1]);
                cmd.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth);

                if (parts[2] == String.Empty)
                {
                    cmd.Parameters.AddWithValue("@patronymic", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@patronymic", parts[2]);
                }
                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public User GetByID(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = " SELECT ID, Name, Surname, Patronymic, DateOfBirth FROM db.[User] WHERE ID=@id";
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();
                User user = null;

                while (reader.Read())
                {
                    int Id = (int)reader["Id"];
                    string patronymic = reader["Patronymic"] is DBNull ? String.Empty : (string)reader["Patronymic"];
                    string name = $"{(string)reader["Name"]} {(string)reader["Surname"]} {patronymic}";
                    DateTime dateOfBirth = (DateTime)reader["DateOfBirth"];
                    user = new User { Name = name, DateOfBirth = dateOfBirth, Id = Id };
                }
                return user;
            }
        }

        public int[] GetUserAwardsIDs(int ID)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                List<int> awardIDs = new List<int>();         
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = " SELECT AwardID FROM db.[UsersAwards] WHERE UserID=@ID";
                cmd.Parameters.AddWithValue("@ID", ID);
                connection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    awardIDs.Add((int)reader["AwardID"]);
                }
                return awardIDs.ToArray();
            }
        }

        public bool Remove(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM db.[User] WHERE ID=@id";
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();

                return reader.Read();
            }
        }
    }
}
