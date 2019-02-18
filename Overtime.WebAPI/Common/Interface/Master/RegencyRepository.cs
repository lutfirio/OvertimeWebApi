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
    public class RegencyRepository : IRegencyRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        public bool Delete(int? Id)
        {
            var result = 0;
            Regency regency = Get(Id);
            regency.IsDelete = true;
            regency.DeleteDate = DateTimeOffset.Now.LocalDateTime;
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

        public List<Regency> Get()
        {
            var get = myContext.Regencies.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Regency Get(int? Id)
        {
            Regency regency = myContext.Regencies.Where(x => x.Id == Id).SingleOrDefault();
            return regency;
        }

        public bool Insert(RegencyParam regencyParam)
        {
            var result = 0;
            var regency = new Regency();
            regency.Name = regencyParam.Name;            
            regency.Provinces = myContext.Provinces.Find(regencyParam.Provinces);
            regency.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Regencies.Add(regency);
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

        public bool Update(int? Id, RegencyParam regencyParam)
        {
            var result = 0;
            var get = Get(Id);
            get.Name = regencyParam.Name;
            get.Provinces = myContext.Provinces.Find(regencyParam.Provinces);           
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
