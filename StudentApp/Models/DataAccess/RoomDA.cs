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
    public class RoomDA
    {
        public bool InsertRoom(int roomID, int roomNumber, int dormID)
        {
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[InsertRoom]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RoomID", roomID);
                    cmd.Parameters.AddWithValue("@RoomNumber", roomNumber);
                    cmd.Parameters.AddWithValue("@DormID", dormID);

                    cmd.ExecuteNonQuery();

                    return true; // Întoarce true dacă inserarea a fost reușită
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                    return false; // Întoarce false dacă a apărut o eroare în timpul inserării
                }
            }
        }
        public bool UpdateRoom(int roomID, int roomNumber, int dormID)
        {
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[UpdateRoom]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RoomID", roomID);
                    cmd.Parameters.AddWithValue("@RoomNumber", roomNumber);
                    cmd.Parameters.AddWithValue("@DormID", dormID);

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
        public bool DeleteRoom(int roomID)
        {
            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[DeleteRoom]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RoomID", roomID);

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
        public List<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();

            using (SqlConnection connection = DatabaseManager.Connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[GetAllRooms]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Room room = new Room
                        {
                            RoomID = Convert.ToInt32(reader["RoomID"]),
                            RoomNumber = Convert.ToInt32(reader["RoomNumber"]),
                            DormID = Convert.ToInt32(reader["DormID"])
                        };
                        rooms.Add(room);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
            }

            return rooms;
        }
    }
    
}
