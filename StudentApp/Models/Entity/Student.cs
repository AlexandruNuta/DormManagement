using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Models.Entity
{
    public class Student : INotifyPropertyChanged
    {
        private int _studentId;

        public int StudentId
        {
            get { return _studentId; }
            set
            {
                if (_studentId != value)
                {
                    _studentId = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _cnp;
        public string CNP
        {
            get { return _cnp; }
            set
            {
                if (_cnp != value)
                {
                    _cnp = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _facultyId;
        public int FacultyId
        {
            get { return _facultyId; }
            set
            {
                if (_facultyId != value)
                {
                    _facultyId = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _hasFee;
        public bool HasFee
        {
            get { return _hasFee; }
            set
            {
                if (_hasFee != value)
                {
                    _hasFee = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isExempted;
        public bool IsExempted
        {
            get { return _isExempted; }
            set
            {
                if (_isExempted != value)
                {
                    _isExempted = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
