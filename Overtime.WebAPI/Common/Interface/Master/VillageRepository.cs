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
    public class VillageRepository : IVillageRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        public bool Delete(int? Id)
        {
            var result = 0;
            Village village = Get(Id);
            village.IsDelete = true;
            village.DeleteDate = DateTimeOffset.Now.LocalDateTime;
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

        public List<Village> Get()
        {
            var get = myContext.Villages.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Village Get(int? Id)
        {
            Village village = myContext.Villages.Where(x => x.Id == Id).SingleOrDefault();
            return village;
        }

        public bool Insert(VillageParam villageParam)
        {
            var result = 0;
            var village = new Village();
            village.Name = villageParam.Name;
            village.Districts = myContext.Districts.Find(villageParam.Districts);
            village.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Villages.Add(village);
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

        public bool Update(int? Id, VillageParam villageParam)
        {
            var result = 0;
            var get = Get(Id);
            get.Name = villageParam.Name;
            get.Districts = myContext.Districts.Find(villageParam.Districts);
            get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
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
