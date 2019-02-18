using Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Approval : BaseModel
    {                
        public string Reason { get; set; }
        public string Approval_Status { get; set; }
        public virtual Employee Employees { get; set; }
        public virtual Overtime Overtimes { get; set; }
    }
}
