using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentApp.Models.DataAccess;
using StudentApp.Models.Entity;

namespace StudentApp.Models.BusinessLogic
{
    public class DormBLL
    {
        private DormDA dormDA;
        public DormBLL()
            {
            dormDA = new DormDA();
        }

        public List<Dorm> GetAllDorms()
        {
            return dormDA.GetAllDorms();
        }
        public bool InsertDorm(int dormID, int dormNumber, decimal dormFee)
        {
            return dormDA.InsertDorm(dormID, dormNumber, dormFee);
        }
        public bool UpdateDorm(int dormID, int dormNumber, decimal dormFee)
        {
            return dormDA.UpdateDorm(dormID, dormNumber, dormFee);
        }
        public bool DeleteDorm(int dormID)
        {
            return dormDA.DeleteDorm(dormID);
        }

    }
}
