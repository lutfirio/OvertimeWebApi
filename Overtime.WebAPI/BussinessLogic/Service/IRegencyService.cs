using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Service
{
    public interface IRegencyService
    {
        bool Insert(RegencyParam regencyParam);
        bool Update(int? Id, RegencyParam regencyParam);
        bool Delete(int? Id);
        List<Regency> Get();
        Regency Get(int? Id);
    }
}
