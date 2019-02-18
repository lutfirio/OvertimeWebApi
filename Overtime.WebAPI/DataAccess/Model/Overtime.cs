using Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Overtime : BaseModel
    {
        public DateTimeOffset Check_In { get; set; }
        public DateTimeOffset Check_Out { get; set; }
        public int Overtime_Salary { get; set; }
        public int Difference { get; set; }
        public virtual Employee Employees { get; set; }
    }
}
