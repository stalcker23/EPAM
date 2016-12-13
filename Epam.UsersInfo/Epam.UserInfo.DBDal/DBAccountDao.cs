using Epam.UserInfo.DalContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.UsersInfo.Entities;
using System.Configuration;
using System.Data.SqlClient;

namespace Epam.UserInfo.DBDal
{
    public class DBAccountDao : IAccountDao
    {
        private static string connectionStr;

        static DBAccountDao()
        {
            connectionStr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        }

        public bool Add(Account account)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO db.Account (Login, Password) VALUES (@login, @password); SELECT scope_identity()";
                cmd.Parameters.AddWithValue("@login", account.Login);
                cmd.Parameters.AddWithValue("@password", account.Password);
                connection.Open();
        
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public void SetRole(int ID)
        {
            throw new NotImplementedException();
        }

        public bool CanRegister(string login)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT Login FROM db.Account WHERE Login=@login";
                cmd.Parameters.AddWithValue("@login", login);
                connection.Open();

                var reader = cmd.ExecuteReader();

                return !reader.Read();
            }
        }

        public bool CheckUser(string login, string password)
        {
            using (var connection = new SqlConnection(connectionStr))
            {

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT Login, Password FROM db.Account WHERE (Login=@login) AND  (Password=@password)";
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                connection.Open();

                var reader = cmd.ExecuteReader();
                return reader.Read();
            }
        }
        
        public string GetRole(string login)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = " SELECT RoleName FROM db.Role WHERE ID IN (SELECT RoleID FROM db.Account WHERE Login = @login)";
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
             

        public bool Contains(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT ID FROM db.[Account] WHERE ID=@id";
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();

                return reader.Read();
            }
        }
        private static IEnumerable<string> GetAllAccountsRoles()
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT db.Role.RoleName FROM db.Role INNER JOIN db.Account ON db.Role.ID=db.Account.RoleID";
                connection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string role = (string)reader["RoleName"];                   
                    yield return role;
                }
            }
        }
        public bool ChangeRole(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE db.[Account] SET RoleID=@roleId WHERE ID=@id";

                Account account = GetByID(id);

                cmd.Parameters.AddWithValue("@id", id);

                if (GetRole(account.Login).Equals("Admin"))
                {
                    int countAdmins = 0;
                    string[] allAccountsRoles = GetAllAccountsRoles().ToArray();
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
                    cmd.Parameters.AddWithValue("@roleId", 3);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@roleId", 4);
                }
                connection.Open();

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public Account GetByID(int id)
        {
            using (var connection = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = " SELECT ID, Login, RoleID FROM db.[Account] WHERE ID=@id";
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();

                var reader = cmd.ExecuteReader();
                Account account = null;

                while (reader.Read())
                {
                    int Id = (int)reader["ID"];
                    string login = (string)reader["Login"];                   
                    account = new Account(Id, login, GetRole(login));
                }
                return account;
            }
        }
    }
}
