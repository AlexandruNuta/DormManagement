using StudentApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentApp.Models.DataAccess
{
    public class StudentDA
    {
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[GetAllStudents]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Student student = new Student
                        {
                            StudentId = Convert.ToInt32(reader["StudentId"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            CNP = reader["CNP"].ToString(),
                            FacultyId = Convert.ToInt32(reader["FacultyId"]),
                            HasFee = Convert.ToBoolean(reader["HasFee"]),
                            IsExempted = Convert.ToBoolean(reader["IsExempted"])
                        };
                        students.Add(student);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
            }

            return students;
        }
        public bool DeleteStudent(int studentId)
        {
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[DeleteStudent]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramStudentId = new SqlParameter("@StudentId", SqlDbType.Int);
                    paramStudentId.Value = studentId;
                    cmd.Parameters.Add(paramStudentId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0; // Returns true if at least one row was updated
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                    return false; // Întoarce false dacă a apărut o eroare în timpul ștergerii
                }
            }
        }
        public bool UpdateStudent(int studentId, bool hasFee, bool isExempted)
        {
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[UpdateStudent]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramStudentId = new SqlParameter("@StudentId", SqlDbType.Int);
                    paramStudentId.Value = studentId;
                    cmd.Parameters.Add(paramStudentId);

                    SqlParameter paramHasFee = new SqlParameter("@HasFee", SqlDbType.Bit);
                    paramHasFee.Value = hasFee;
                    cmd.Parameters.Add(paramHasFee);

                    SqlParameter paramIsExempted = new SqlParameter("@IsExempted", SqlDbType.Bit);
                    paramIsExempted.Value = isExempted;
                    cmd.Parameters.Add(paramIsExempted);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0; // Returns true if at least one row was updated
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                    return false;
                }
            }
        }
        public bool CreateStudent(int studentId,string firstName, string lastName, string cnp, int facultyId, bool hasFee, bool isExempted)
        {
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[CreateStudent]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@CNP", cnp);
                    cmd.Parameters.AddWithValue("@FacultyId", facultyId);
                    cmd.Parameters.AddWithValue("@HasFee", hasFee);
                    cmd.Parameters.AddWithValue("@IsExempted", isExempted);

                    cmd.ExecuteNonQuery();

                    return true; // Întoarce true dacă crearea a fost reușită
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                    return false; // Întoarce false dacă a apărut o eroare în timpul creării
                }
            }
        }
        public bool AssignStudentToRoom(int studentId, int roomId)
        {
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[AssignStudentToRoom]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@RoomId", roomId);

                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                    return false;
                }
            }
        }
        public bool UnassignStudentToRoom(int studentId)
        {
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[UnassignStudentFromRoom]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
