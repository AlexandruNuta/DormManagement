using StudentApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using StudentApp.Views;

namespace StudentApp.ViewModels
{
    public class MainViewModel 
    {
        public ICommand OpenStudentCommand { get; }
        public ICommand OpenDormCommand { get; }
        public ICommand OpenLinkCommand { get; }

        public ICommand OpenRoomCommand { get; }
        public ICommand PaymentCommand { get; }

        public MainViewModel()
        {
            OpenStudentCommand = new RelayCommand(OpenStudentWindow);
            OpenDormCommand = new RelayCommand(OpenDormWindow);
            OpenLinkCommand = new RelayCommand(OpenLinkWindow);
            OpenRoomCommand = new RelayCommand(OpenRoomWindow);
            PaymentCommand = new RelayCommand(PaymentWind);
        }

        private void OpenStudentWindow()
        {
            StudentManagementWindow studentManagementWindow = new StudentManagementWindow();
            studentManagementWindow.Show();

        }

        private void OpenDormWindow()
        {
            DormManagementWindow dormManagementWindow = new DormManagementWindow();
            dormManagementWindow.Show();
        }
        
        private void OpenRoomWindow()
        {
            RoomManagementWindow roomManagementWindow = new RoomManagementWindow();
            roomManagementWindow.Show();
        }

        private void OpenLinkWindow()
        {
            LinkStudentRoom linkStudentRoomWindow = new LinkStudentRoom();
            linkStudentRoomWindow.Show();
        }

        private void PaymentWind()
        {
            PaymentWindow paymentWindow = new PaymentWindow();
            paymentWindow.Show();
        }
    }
}
