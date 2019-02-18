using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Param
{
    public class ApprovalParam
    {
        public int Id { get; set; }        
        public string Reason { get; set; }
        public string Approval_Status { get; set; }
        public int Employees { get; set; }
        public int Overtimes { get; set; }
    }
}
