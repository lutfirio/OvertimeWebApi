﻿using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Service
{
    public interface IPositionService
    {
        bool Insert(PositionParam positionParam);
        bool Update(int? Id, PositionParam positionParam);
        bool Delete(int? Id);
        List<Position> Get();
        Position Get(int? Id);
    }
}
