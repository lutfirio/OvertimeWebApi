using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Param
{
    public class OvertimeParam
    {
        public int Id { get; set; }
        public DateTimeOffset Check_In { get; set; }
        public DateTimeOffset Check_Out { get; set; }
        public int Overtime_Salary { get; set; }
        public int Difference { get; set; }
        public int Employees { get; set; }
    }
}
