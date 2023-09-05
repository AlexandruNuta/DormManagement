using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Models.Entity
{
    public class Dorm : INotifyPropertyChanged
    {
        private int _dormID;
        public int DormID
        {
            get { return _dormID; }
            set
            {
                if (_dormID != value)
                {
                    _dormID = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _dormNumber;
        public int DormNumber
        {
            get { return _dormNumber; }
            set
            {
                if (_dormNumber != value)
                {
                    _dormNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal _dormFee;
        public decimal DormFee
        {
            get { return _dormFee; }
            set
            {
                if (_dormFee != value)
                {
                    _dormFee = value;
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
