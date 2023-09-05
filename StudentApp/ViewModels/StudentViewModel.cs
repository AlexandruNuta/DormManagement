using StudentApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentApp.Commands;
using StudentApp.Models.BusinessLogic;
using System.Windows;
using System.Collections.ObjectModel;

namespace StudentApp.ViewModels
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private Student _selectedStudent;
        public StudentBLL studentBLL = new StudentBLL();

        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                if (_selectedStudent != value)
                {
                    _selectedStudent = value;
                    OnPropertyChanged(nameof(SelectedStudent));
                }
            }
        }

        private int _studentId;
        public int StudentId
        {
            get { return _studentId; }
            set
            {
                if (_studentId != value)
                {
                    _studentId = value;
                    OnPropertyChanged(nameof(StudentId));
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
                    OnPropertyChanged(nameof(FirstName));
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
                    OnPropertyChanged(nameof(LastName));
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
                    OnPropertyChanged(nameof(CNP));
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
                    OnPropertyChanged(nameof(FacultyId));
                }
            }
        }

        private bool _hasFees;
        public bool HasFees
        {
            get { return _hasFees; }
            set
            {
                if (_hasFees != value)
                {
                    _hasFees = value;
                    OnPropertyChanged(nameof(HasFees));
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
                    OnPropertyChanged(nameof(IsExempted));
                }
            }
        }

        // Commands for adding, editing, and deleting students
        public RelayCommand AddStudentCommand { get; private set; }
        public RelayCommand EditStudentCommand { get; private set; }
        public RelayCommand DeleteStudentCommand { get; private set; }

        // Constructor
        public StudentViewModel()
        {
            // Initialize your commands here
            AddStudentCommand = new RelayCommand(AddStudent);
            EditStudentCommand = new RelayCommand(EditStudent);
            DeleteStudentCommand = new RelayCommand(DeleteStudent);
            LoadStudents();
        }

        // Implement your methods for adding, editing, and deleting students here

        private void AddStudent()
        {
            bool isSuccess = studentBLL.InsertStudent(StudentId, FirstName, LastName, CNP, FacultyId, HasFees, IsExempted);

            if (isSuccess)
            {
                MessageBox.Show("Student created successfully");
                Students.Clear();
                LoadStudents(); // Refresh the list of employees
            }
            else
            {
                MessageBox.Show("Error occurred while creating the student");
            }
            ClearFields();
        }

        private void DeleteStudent()
        {
            if (SelectedStudent != null)
            {
                bool isSuccess = studentBLL.DeleteStudent(SelectedStudent.StudentId);

                if (isSuccess)
                {
                    MessageBox.Show("Student deleted successfully");
                    Students.Remove(SelectedStudent);
                    Students.Clear();
                    LoadStudents();
                }
                else
                {
                    MessageBox.Show("Error occurred while deleting the student");
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete");
            }
            ClearFields();
        }

        private void EditStudent()
        {
            if (SelectedStudent != null)
            {
                bool isSuccess = studentBLL.UpdateStudent(SelectedStudent.StudentId, SelectedStudent.HasFee, SelectedStudent.IsExempted);

                if (isSuccess)
                {
                    MessageBox.Show("Student updated successfully");
                    Students.Clear();
                    LoadStudents(); // Refresh the list of students
                }
                else
                {
                    MessageBox.Show("Error occurred while updating the student");
                }
            }
            else
            {
                MessageBox.Show("Please select a student to edit");
            }
            ClearFields();
        }

        private void LoadStudents()
        {
            // Implement the code to fetch employees from your data access layer
            List<Student> students = studentBLL.GetAllStudents();

            foreach (var employee in students)
            {
                Students.Add(employee);
            }
        }
        private void ClearFields()
        {
            StudentId = 0;
            FirstName = "";
            LastName = "";
            CNP = "";
            FacultyId = 0;
            HasFees = false;
            IsExempted = false;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
