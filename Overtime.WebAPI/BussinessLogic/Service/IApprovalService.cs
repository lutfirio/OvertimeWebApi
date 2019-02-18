﻿using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Service
{
    public interface IApprovalService
    {
        bool Insert(ApprovalParam approvalParam);
        bool Update(int? Id, ApprovalParam approvalParam);
        List<Approval> Get();
        Approval Get(int? Id);
    }
}