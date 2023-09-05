using StudentApp.Models.DataAccess;
using StudentApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Models.BusinessLogic
{
    public class StudentBLL
    {
        private StudentDA _studentDA;

        public StudentBLL()
        {
            // Poți să inițializezi aici obiectul StudentDA sau să-l injectezi
            _studentDA = new StudentDA();
        }

        public List<Student> GetAllStudents()
        {
            return _studentDA.GetAllStudents();
        }

        public bool DeleteStudent(int studentId)
        {
            return _studentDA.DeleteStudent(studentId);
        }

        public bool UpdateStudent(int studentId, bool hasFee, bool isExempted)
        {
            return _studentDA.UpdateStudent(studentId, hasFee, isExempted);
        }

        public bool InsertStudent(int studentId, string firstName, string lastName, string cnp, int facultyId, bool hasFee, bool isExempted)
        {
            return _studentDA.CreateStudent(studentId, firstName, lastName, cnp, facultyId, hasFee, isExempted);
        }
        
        public bool LinkStudent(int studentId, int roomId)
        {
            return _studentDA.AssignStudentToRoom(studentId, roomId);
        }
        public bool UnLlinkStudent(int studentId)
        {
            return _studentDA.UnassignStudentToRoom(studentId);
        }
    }
}
