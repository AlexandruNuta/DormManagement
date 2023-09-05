using StudentApp.Commands;
using StudentApp.Models.DataAccess;
using StudentApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;

using StudentApp.Models.BusinessLogic;

namespace StudentApp.ViewModels
{
    public class DormViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Dorm> _dorms;
        private Dorm _selectedDorm;
        private int _dormId;
        private int _dormNumber;
        private decimal _dormFee;
        public DormBLL dormBLL = new DormBLL();

        public ObservableCollection<Dorm> Dorms
        {
            get { return _dorms; }
            set
            {
                _dorms = value;
                OnPropertyChanged(nameof(Dorms));
            }
        }

        public Dorm SelectedDorm
        {
            get { return _selectedDorm; }
            set
            {
                _selectedDorm = value;
                OnPropertyChanged(nameof(SelectedDorm));
            }
        }

        public int DormId
        {
            get { return _dormId; }
            set
            {
                _dormId = value;
                OnPropertyChanged(nameof(DormId));
            }
        }

        public int DormNumber
        {
            get { return _dormNumber; }
            set
            {
                _dormNumber = value;
                OnPropertyChanged(nameof(DormNumber));
            }
        }

        public decimal DormFee
        {
            get { return _dormFee; }
            set
            {
                _dormFee = value;
                OnPropertyChanged(nameof(DormFee));
            }
        }

        public ICommand AddDormCommand { get; private set; }
        public ICommand EditDormCommand { get; private set; }
        public ICommand DeleteDormCommand { get; private set; }

        public DormViewModel()
        {
            Dorms = new ObservableCollection<Dorm>();
            AddDormCommand = new RelayCommand(AddDorm);
            EditDormCommand = new RelayCommand(EditDorm);
            DeleteDormCommand = new RelayCommand(DeleteDorm);
            LoadDorms();
        }

        private void AddDorm()
        {
            bool isSuccess = dormBLL.InsertDorm(DormId, DormNumber, DormFee);

            if (isSuccess)
            {
                MessageBox.Show("Dorm added successfully");
                Dorms.Clear();
                LoadDorms();
            }
            else
            {
                MessageBox.Show("Error occurred while adding the dorm");
            }
        }

        private void EditDorm()
        {
            if (SelectedDorm != null)
            {
                bool isSuccess = dormBLL.UpdateDorm(SelectedDorm.DormID, DormNumber, DormFee);

                if (isSuccess)
                {
                    MessageBox.Show("Dorm updated successfully");
                    Dorms.Clear();
                    LoadDorms();
                }
                else
                {
                    MessageBox.Show("Error occurred while updating the dorm");
                }
            }
        }

        private void DeleteDorm()
        {
            if (SelectedDorm != null)
            {
                bool isSuccess = dormBLL.DeleteDorm(SelectedDorm.DormID);

                if (isSuccess)
                {
                    MessageBox.Show("Dorm deleted successfully");
                    Dorms.Remove(SelectedDorm);
                    Dorms.Clear();
                    LoadDorms();
                }
                else
                {
                    MessageBox.Show("Error occurred while deleting the dorm");
                }
            }
        }

        private void LoadDorms()
        {
            List<Dorm> dorms = dormBLL.GetAllDorms();
            foreach (var dorm in dorms)
            {
                Dorms.Add(dorm);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
