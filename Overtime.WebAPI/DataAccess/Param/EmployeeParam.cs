using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Param
{
    public class EmployeeParam
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }
        public int Villages { get; set; }        
        public string Postal_Code { get; set; }
        public int Salary { get; set; }
        public string Phone { get; set; }
        public int Positions { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int? Managers_Id { get; set; }
    }
}
