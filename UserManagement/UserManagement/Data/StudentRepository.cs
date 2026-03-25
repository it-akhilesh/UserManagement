using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UserManagement.Models.Dto;
using UserManagement.Models.Responses;
using UserManagement.Models.stu;

namespace UserManagement.Data
{
    public class StudentRepository : IStudentRepository
    {
        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();
            var connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Name, Address, MobileNo, fileName FROM Students";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var student = new Student
                            {
                                Name = reader["Name"].ToString(),
                                Address = reader["Address"].ToString(),
                                MobileNo = reader["MobileNo"].ToString(),
                                fileName = reader["fileName"] != DBNull.Value ? reader["fileName"].ToString() : null
                            };
                            students.Add(student);
                        }
                    }
                }
            }
            return students;
        }

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