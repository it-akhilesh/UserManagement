using System;
using System.Configuration;
using System.Data.SqlClient;
using UserManagement.Models.Dto;

namespace UserManagement.Data
{
    public class SqlUserRepository : IUserRepository
    {
        public UserLoginInfo ValidateCredentials(string userName, string password)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select u.UserName,r.RoleName From Users u inner join UserRole ur ON u.UserId = ur.UserId " +
                "inner join Rolemaster r " +
                "on ur.roleid = r.RoleId Where u.UserName = @UserName And u.Password = @Password";
            SqlCommand command = new SqlCommand(query, connection);
            
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                    var userLoginInfo = new UserLoginInfo
                    {
                        IsValidUser = true,
                        UserName = reader["UserName"].ToString(),
                        RoleName = reader["RoleName"].ToString()
                    };
                    connection.Close();
                    return userLoginInfo;
            }   
            return new UserLoginInfo { IsValidUser = false };
                
            
        }
    }
}
