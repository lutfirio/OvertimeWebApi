using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface IDistrictRepository
    {
        bool Insert(DistrictParam districtParam);
        bool Update(int? Id, DistrictParam districtParam);
        bool Delete(int? Id);
        List<District> Get();
        District Get(int? Id);
    }
}
