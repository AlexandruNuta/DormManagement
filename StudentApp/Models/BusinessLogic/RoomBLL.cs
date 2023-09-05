using StudentApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using StudentApp.Models.DataAccess;

namespace StudentApp.Models.BusinessLogic
{
    public class RoomBLL
    {
        private RoomDA _roomDA;

        public RoomBLL()
        {
            _roomDA = new RoomDA();
        }

        public List<Room> GetAllRooms()
        {
            return _roomDA.GetAllRooms();
        }

        public bool InsertRoom(int roomID, int roomNumber, int dormID)
        {
            return _roomDA.InsertRoom(roomID, roomNumber, dormID);
        }

        public bool UpdateRoom(int roomID, int roomNumber, int dormID)
        {
            return _roomDA.UpdateRoom(roomID, roomNumber, dormID);
        }

        public bool DeleteRoom(int roomID)
        {
            return _roomDA.DeleteRoom(roomID);
        }
    }






}
