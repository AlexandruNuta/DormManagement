using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using StudentApp.Models.Entity;
using StudentApp.Models.BusinessLogic;
using StudentApp.Commands;

namespace StudentApp.ViewModels
{
    public class RoomViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Room> Rooms { get; set; } = new ObservableCollection<Room>();
        private Room _selectedRoom;
        public Room SelectedRoom
        {
            get { return _selectedRoom; }
            set
            {
                if (_selectedRoom != value)
                {
                    _selectedRoom = value;
                    OnPropertyChanged(nameof(SelectedRoom));
                }
            }
        }
        public RoomBLL roomBLL = new RoomBLL();

        private int _roomID;
        public int RoomID
        {
            get { return _roomID; }
            set
            {
                if (_roomID != value)
                {
                    _roomID = value;
                    OnPropertyChanged(nameof(RoomID));
                }
            }
        }

        private int _roomNumber;
        public int RoomNumber
        {
            get { return _roomNumber; }
            set
            {
                if (_roomNumber != value)
                {
                    _roomNumber = value;
                    OnPropertyChanged(nameof(RoomNumber));
                }
            }
        }

        private int _dormID;
        public int DormID
        {
            get { return _dormID; }
            set
            {
                if (_dormID != value)
                {
                    _dormID = value;
                    OnPropertyChanged(nameof(DormID));
                }
            }
        }

        public ICommand AddRoomCommand { get; }
        public ICommand EditRoomCommand { get; }

        public ICommand DeleteRoomCommand { get;}

        public RoomViewModel()
        {
            AddRoomCommand = new RelayCommand(AddRoom);
            EditRoomCommand = new RelayCommand(EditRoom);
            DeleteRoomCommand = new RelayCommand(DeleteRoom);
            LoadRooms();
        }

        private void AddRoom()
        {
            bool isSuccess = roomBLL.InsertRoom(RoomID, RoomNumber, DormID);

            if (isSuccess)
            {
                MessageBox.Show("Room added successfully");
                Rooms.Clear();
                LoadRooms(); // Reîncărcați lista de camere
            }
            else
            {
                MessageBox.Show("Error occurred while adding the room");
            }
        }
        private void EditRoom()
        {
            // Implementați logica pentru editarea camerei selectate
            if (SelectedRoom != null)
            {
                bool isSuccess = roomBLL.UpdateRoom(SelectedRoom.RoomID,RoomNumber, DormID);

                if (isSuccess)
                {
                    MessageBox.Show("Room updated successfully");
                    Rooms.Clear();
                    LoadRooms(); // Reîncărcați lista de camere
                }
                else
                {
                    MessageBox.Show("Error occurred while updating the room");
                }
            }
        }
        private void DeleteRoom()
        {
            // Implementați logica pentru ștergerea camerei selectate
            if (SelectedRoom != null)
            {
                bool isSuccess = roomBLL.DeleteRoom(SelectedRoom.RoomID);

                if (isSuccess)
                {
                    MessageBox.Show("Room deleted successfully");
                    Rooms.Clear();
                    LoadRooms(); // Reîncărcați lista de camere
                }
                else
                {
                    MessageBox.Show("Error occurred while deleting the room");
                }
            }
        }
        public void LoadRooms()
        {
            List<Room> rooms = roomBLL.GetAllRooms();
            foreach (Room room in rooms)
            {
                Rooms.Add(room);
            }
        }
        
    }
}
