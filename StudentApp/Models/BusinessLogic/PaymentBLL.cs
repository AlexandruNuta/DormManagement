using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentApp.Models.DataAccess;

namespace StudentApp.Models.BusinessLogic
{
    public class PaymentBLL
    {
        private PaymentDA _paymentDA;

        public PaymentBLL()
        {
            _paymentDA = new PaymentDA();
        }

        public bool InsertPayment(int studentID,decimal paymentAmount, DateTime paymentDate)
        {
            return _paymentDA.AddPayment(studentID,paymentAmount, paymentDate);
        }

    }
}
