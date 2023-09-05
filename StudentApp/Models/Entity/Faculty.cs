using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Models.Entity
{
    public class Faculty : INotifyPropertyChanged
    {
        private FacultyDTO _facultyDTO; // Use DormDTO instead of direct properties

        public FacultyDTO FacultyDTO
        {
            get { return _facultyDTO; }
            set
            {
                if (_facultyDTO != value)
                {
                    _facultyDTO = value;
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
