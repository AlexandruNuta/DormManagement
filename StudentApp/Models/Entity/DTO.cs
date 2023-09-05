using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Models.Entity
{
    public class DormDTO
    {
        public int DormNumber { get; set; }
        public decimal DormFee { get; set; }

        public List<RoomDTO> Rooms { get; set; }
    }

    public class RoomDTO
    {
        public int RoomNumber { get; set; }
        public List<Student> Students { get; set; }
    }
    public class FacultyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
