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
    public class DistrictRepository : IDistrictRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        public bool Delete(int? Id)
        {
            var result = 0;
            District district = Get(Id);
            district.IsDelete = true;
            district.DeleteDate = DateTimeOffset.Now.LocalDateTime;
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

        public List<District> Get()
        {
            var get = myContext.Districts.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public District Get(int? Id)
        {
            District district = myContext.Districts.Where(x => x.Id == Id).SingleOrDefault();
            return district;
        }

        public bool Insert(DistrictParam districtParam)
        {
            var result = 0;
            var district = new District();
            district.Name = districtParam.Name;
            district.Regencies = myContext.Regencies.Find(districtParam.Regencies);
            district.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Districts.Add(district);
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

        public bool Update(int? Id, DistrictParam districtParam)
        {
            var result = 0;
            var get = Get(Id);
            get.Name = districtParam.Name;
            get.Regencies = myContext.Regencies.Find(districtParam.Regencies);
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
