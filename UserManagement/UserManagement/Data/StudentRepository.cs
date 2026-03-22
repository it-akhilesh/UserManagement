using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UserManagement.Models.Dto;
using UserManagement.Models.stu;

namespace UserManagement.Data
{
    public class StudentRepository : IStudentRepository
    {
        public bool StudentInsert(StudentRequest student)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Students (Name, Address, Country, State, City, PinCode, MobileNo, Email,fileName,fileType,fileData) " +
                               "VALUES (@Name, @Address, @Country, @State, @City, @PinCode, @MobileNo, @Email,@fileName,@fileType,@fileData)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Address", student.Address);
                    command.Parameters.AddWithValue("@Country", student.Country);
                    command.Parameters.AddWithValue("@State", student.State);
                    command.Parameters.AddWithValue("@City", student.City);
                    command.Parameters.AddWithValue("@PinCode", student.PinCode);
                    command.Parameters.AddWithValue("@MobileNo", student.MobileNo);
                    command.Parameters.AddWithValue("@Email", student.Email);
                    command.Parameters.AddWithValue("@fileName", (object)student.fileName ?? DBNull.Value);
                    command.Parameters.AddWithValue("@fileType", (object)student.fileType ?? DBNull.Value);
                    command.Parameters.AddWithValue("@fileData", (object)student.fileData ?? DBNull.Value);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0; 
                }
            }
        }

        
    }
}