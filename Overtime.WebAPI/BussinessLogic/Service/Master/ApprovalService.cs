using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;
using Common.Interface;

namespace BussinessLogic.Service.Master
{
    public class ApprovalService : IApprovalService
    {
        private readonly IApprovalRepository _approvalRepository;
        public ApprovalService(IApprovalRepository approvalRepository)
        {
            _approvalRepository = approvalRepository;
        }

        bool status = false;
        public List<Approval> Get()
        {
            return _approvalRepository.Get();
        }

        public Approval Get(int? Id)
        {
            var getApprovalId = _approvalRepository.Get(Id);
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            return getApprovalId;
        }

        public bool Insert(ApprovalParam approvalParam)
        {
            if (approvalParam == null)
            {
                Console.WriteLine("Insert Name");
                Console.Read();
            }
            else
            {
                status = _approvalRepository.Insert(approvalParam);
                Console.WriteLine("Success");
            }
            return status;
        }

        public bool Update(int? Id, ApprovalParam approvalParam)
        {
            throw new NotImplementedException();
        }
    }
}
