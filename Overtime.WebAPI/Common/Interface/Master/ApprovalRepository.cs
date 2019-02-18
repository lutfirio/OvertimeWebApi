using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;
using DataAccess.Context;

namespace Common.Interface.Master
{
    public class ApprovalRepository : IApprovalRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        public List<Approval> Get()
        {
            var get = myContext.Approvals.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Approval Get(int? Id)
        {
            Approval approval = myContext.Approvals.Where(x => x.Id == Id).SingleOrDefault();
            return approval;
        }

        public bool Insert(ApprovalParam approvalParam)
        {
            var result = 0;
            var approval = new Approval();
            approval.Approval_Status = approvalParam.Approval_Status;
            myContext.Approvals.Add(approval);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(int? Id, ApprovalParam approvalParam)
        {
            var result = 0;
            var get = Get(Id);
            get.Approval_Status = approvalParam.Approval_Status;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
