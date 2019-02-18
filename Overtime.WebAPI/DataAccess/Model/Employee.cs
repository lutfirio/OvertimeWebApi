using Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Employee : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }          
        public string Postal_Code { get; set; }
        public int Salary { get; set; }
        public string Phone { get; set; }        
        public string Question { get; set; }
        public string Answer { get; set; }

        public virtual Village Villages { get; set; }
        public virtual Position Positions { get; set; }
        public int  Managers_Id { get; set; }

    }
}
