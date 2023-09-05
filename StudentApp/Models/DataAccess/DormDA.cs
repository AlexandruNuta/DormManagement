using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using StudentApp.Models.Entity;

namespace StudentApp.Models.DataAccess
{
    public class DormDA
    {
        public bool InsertDorm(int dormID, int dormNumber, decimal dormFee)
        {
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[InsertDorm]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DormID", dormID);
                    cmd.Parameters.AddWithValue("@DormNumber", dormNumber);
                    cmd.Parameters.AddWithValue("@DormFee", dormFee);

                    cmd.ExecuteNonQuery();

                    return true; // Întoarce true dacă adăugarea a fost reușită
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                    return false; // Întoarce false dacă a apărut o eroare în timpul adăugării
                }
            }
        }
        public List<Dorm> GetAllDorms()
        {
            List<Dorm> dorms = new List<Dorm>();

            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[GetAllDorms]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Dorm dorm = new Dorm
                        {
                            DormID = Convert.ToInt32(reader["DormID"]),
                            DormNumber = Convert.ToInt32(reader["DormNumber"]),
                            DormFee = Convert.ToDecimal(reader["DormFee"])
                        };
                        dorms.Add(dorm);
                    }

                    return dorms;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                    return null;
                }
            }
        }
        public bool UpdateDorm(int dormID, int dormNumber, decimal dormFee)
        {
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[UpdateDorm]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DormID", dormID);
                    cmd.Parameters.AddWithValue("@DormNumber", dormNumber);
                    cmd.Parameters.AddWithValue("@DormFee", dormFee);

                    cmd.ExecuteNonQuery();

                    return true; // Întoarce true dacă actualizarea a fost reușită
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                    return false; // Întoarce false dacă a apărut o eroare în timpul actualizării
                }
            }
        }
        public bool DeleteDorm(int dormID)
        {
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[DeleteDorm]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DormID", dormID);

                    cmd.ExecuteNonQuery();

                    return true; // Întoarce true dacă ștergerea a fost reușită
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                    return false; // Întoarce false dacă a apărut o eroare în timpul ștergerii
                }
            }
        }
    }
}
