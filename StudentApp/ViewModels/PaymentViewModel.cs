using StudentApp.Models.BusinessLogic;
using StudentApp.Models.Entity;
using StudentApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using StudentApp.Models.DataAccess;
using StudentApp.Views;
using StudentApp.Services;



namespace StudentApp.ViewModels
{
    public class PaymentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public StudentBLL _studentBLL = new StudentBLL();
        public PaymentBLL _paymentBLL = new PaymentBLL();

        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();
        private Student _selectedStudent;
        private decimal _amount;
        private DateTime _paymentDate;
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }

        public decimal Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }

        public DateTime PaymentDate
        {
            get { return _paymentDate; }
            set
            {
                _paymentDate = value;
                OnPropertyChanged(nameof(PaymentDate));
            }
        }

        public RelayCommand MakePaymentCommand { get; private set; }

        public PaymentViewModel()
        {
            PaymentDate = DateTime.Now;
            MakePaymentCommand = new RelayCommand(MakePayment);
            LoadStudents();
        }

        private void MakePayment()
        {
            if (SelectedStudent != null && Amount > 0 && PaymentDate != null)
            {
                int studentId = SelectedStudent.StudentId;
                string studentName = SelectedStudent.FirstName;
                decimal paymentAmount = Amount;
                DateTime paymentDate = PaymentDate;

                bool isSuccess = _paymentBLL.InsertPayment(studentId, paymentAmount, paymentDate);

                if (isSuccess)
                {
                    MessageBox.Show("Payment successful");
                    GeneratePaymentReceipt(studentName, paymentAmount, paymentDate);
                    // Refresh data or perform other actions after successful payment
                }
                else
                {
                    MessageBox.Show("Payment failed");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all the payment details");
            }
        }

        private void LoadStudents()
        {
            // Implement the code to fetch employees from your data access layer
            List<Student> students = _studentBLL.GetAllStudents();

            foreach (var employee in students)
            {
                Students.Add(employee);
            }
        }
        
        private void GeneratePaymentReceipt(string studentName, decimal paymentAmount, DateTime paymentDate)
        {
            // Crează o instanță a clasei PdfGenerator și apelează metoda de generare PDF
            PdfGenerator pdfGenerator = new PdfGenerator();
            pdfGenerator.GenerateReceipt(studentName, paymentAmount, paymentDate);
        }


        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
