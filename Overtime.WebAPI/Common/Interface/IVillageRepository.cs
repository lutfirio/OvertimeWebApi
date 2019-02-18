using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface IVillageRepository
    {
        bool Insert(VillageParam villageParam);
        bool Update(int? Id, VillageParam villageParam);
        bool Delete(int? Id);
        List<Village> Get();
        Village Get(int? Id);
    }
}
