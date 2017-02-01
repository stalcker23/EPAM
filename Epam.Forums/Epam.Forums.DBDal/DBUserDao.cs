using Epam.Forums.DalContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Forums.Entities;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Epam.Forums.DBDal
{
    public class DBUserDao : IUserDao
    {
        private static string connectionStr;

        static DBUserDao()
        {
            connectionStr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        }
        public bool AddUser(User user)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "AddUser";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", user.Login);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@dateOfRegistration", DateTime.Now);
                cmd.Parameters.AddWithValue("@name", user.Name);
                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool CanRegisterUser(string login)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "CanRegisterUser";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", login);
                connection.Open();

                var reader = cmd.ExecuteReader();

                return !reader.Read();
            }
        }

        public bool ChangeUserRole(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "ChangeUserRole";
                cmd.CommandType = CommandType.StoredProcedure;
                User account = GetUserById(id);

                cmd.Parameters.AddWithValue("@id", id);

                if (GetUserRole(account.Login).Equals("Admin"))
                {
                    int countAdmins = 0;
                    string[] allAccountsRoles = GetAllUsersRoles().ToArray();
                    foreach (var item in allAccountsRoles)
                    {
                        if (countAdmins > 1)
                            break;
                        if (item == "Admin")
                        {
                            countAdmins++;
                        }
                        else
                            continue;
                    }
                    if (countAdmins == 1)
                    {
                        throw new InvalidOperationException("Cannot change the last admin's role");
                    }
                    cmd.Parameters.AddWithValue("@roleId", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@roleId", 2);
                }
                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }
        private static IEnumerable<string> GetAllUsersRoles()
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetAllUsersRoles";
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string role = (string)reader["RoleName"];
                    yield return role;
                }
            }
        }
        public bool CheckUser(string login, string password)
        {
            using (var connection = new SqlConnection(connectionStr))
            {

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "CheckUser";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                connection.Open();

                var reader = cmd.ExecuteReader();
                return reader.Read();
            }
        }

        public bool ContainsUser(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "ContainsUser";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();

                return reader.Read();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetAllUsers";
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int Id = (int)reader["Id"];
                    string login = (string)reader["Login"];
                    DateTime dateOfRegistration = (DateTime)reader["DateOfRegistration"];
                    bool isBanned = (bool)reader["IsBanned"];
                    int imageID = (int)reader["ImageID"];
                    yield return new User { Login = login, Id = Id, DateOfRegistration = dateOfRegistration, IsBanned = isBanned, Photo = new Photo(imageID) };
                }
            }
        }

        public User GetUserById(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetUserByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();
                User user = null;

                while (reader.Read())
                {
                    int Id = (int)reader["Id"];
                    string login = (string)reader["Login"];
                    DateTime dateOfRegistration = (DateTime)reader["DateOfRegistration"];
                    bool isBanned = (bool)reader["IsBanned"];
                    string name = (string)reader["Name"];
                    int imageID = (int)reader["ImageID"];
                    user = new User {Name=name, Login = login, Id = Id, Role = GetUserRole(login), DateOfRegistration = dateOfRegistration, IsBanned = isBanned, Photo = new Photo(imageID) };
                }
                return user;
            }
        }
             public User GetUserByLogin(string login)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetUserByLogin";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", login);
                connection.Open();

                var reader = cmd.ExecuteReader();
                User user = null;

                while (reader.Read())
                {
                    int Id = (int)reader["Id"];                   
                    DateTime dateOfRegistration = (DateTime)reader["DateOfRegistration"];
                    bool isBanned = (bool)reader["IsBanned"];
                    int imageID = (int)reader["ImageId"];
                    user = new User { Login = login, Id = Id, Role = GetUserRole(login), DateOfRegistration = dateOfRegistration, IsBanned = isBanned, Photo = new Photo(imageID) };
                }
                return user;
            }
        }

        public string GetUserRole(string login)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "GetUserRole";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", login);
                connection.Open();

                var reader = cmd.ExecuteReader();
                string role = "";
                while (reader.Read())
                {
                    role = (string)reader["RoleName"];
                }
                return role;
            }
        }

        public bool RemoveUser(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "RemoveUser";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();

                return reader.Read();
            }
        }

        public bool UpdateUser(int id, User user)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UpdateUser";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", user.Name);


                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool ChangeUserStatus(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "ChangeUserStatus";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@id", id);


                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }
        

        public bool ChangePassword(string login, string currentPassword, string newPassword)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                if (CheckUser(login, currentPassword))
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "UpdatePassword";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@login",login);
                    cmd.Parameters.AddWithValue("@password", newPassword);


                    connection.Open();

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
                return false;
            }
        }
    }
}
