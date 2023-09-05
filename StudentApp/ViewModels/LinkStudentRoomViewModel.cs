using StudentApp.Commands;
using StudentApp.Models.BusinessLogic;
using StudentApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentApp.ViewModels
{
    public class LinkStudentRoomViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();
        public ObservableCollection<Room> Rooms { get; set; } = new ObservableCollection<Room>();
        public StudentBLL studentBLL = new StudentBLL();
        public RoomBLL roomBLL = new RoomBLL();

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }

        private Room _selectedRoom;
        public Room SelectedRoom
        {
            get { return _selectedRoom; }
            set
            {
                _selectedRoom = value;
                OnPropertyChanged(nameof(SelectedRoom));
            }
        }

        public ICommand LinkStudentToRoomCommand { get; }
        public ICommand UnLinkStudentToRoomCommand { get; }

        public LinkStudentRoomViewModel()
        {
            LinkStudentToRoomCommand = new RelayCommand(LinkStudentToRoom);
            UnLinkStudentToRoomCommand = new RelayCommand(UnassigneStudentToRoom);
            LoadStudents();
            LoadRooms();
        }


        private void LinkStudentToRoom()
        {
            if (SelectedStudent != null && SelectedRoom != null)
            {
                bool isSuccess = studentBLL.LinkStudent(SelectedStudent.StudentId, SelectedRoom.RoomNumber);

                if (isSuccess)
                {
                    MessageBox.Show("Student room updated successfully");
                }
                else
                {
                    MessageBox.Show("Error occurred while updating the student room");
                }
            }
        }
        
        private void UnassigneStudentToRoom()
        {
            if (SelectedStudent != null)
            {
                bool isSuccess = studentBLL.UnLlinkStudent(SelectedStudent.StudentId);

                if (isSuccess)
                {
                    MessageBox.Show("Student room updated successfully");
                }
                else
                {
                    MessageBox.Show("Error occurred while updating the student room");
                }
            }
        }
        public void LoadStudents()
        {
           List<Student>students = studentBLL.GetAllStudents();
            foreach (var student in students)
            {
                Students.Add(student);
            }
        }
        public void LoadRooms()
        {
            List<Room> rooms = roomBLL.GetAllRooms();
            foreach (var room in rooms)
            {
                Rooms.Add(room);
            }
        }
    }
}
