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
    public class PaymentDA
    {
        public bool AddPayment(int studentId, decimal paymentAmount, DateTime paymentDate)
        {
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[AddPayment]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@PaymentAmount", paymentAmount);
                    cmd.Parameters.AddWithValue("@PaymentDate", paymentDate);

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
    }
}
