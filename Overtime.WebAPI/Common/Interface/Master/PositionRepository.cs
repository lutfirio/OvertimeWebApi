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
    public class PositionRepository : IPositionRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        public bool Delete(int? Id)
        {
            var result = 0;
            Position position = Get(Id);
            position.IsDelete = true;
            position.DeleteDate = DateTimeOffset.Now.LocalDateTime;
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

        public List<Position> Get()
        {
            var get = myContext.Positions.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Position Get(int? Id)
        {
            Position position = myContext.Positions.Where(x => x.Id == Id).SingleOrDefault();
            return position;
        }

        public bool Insert(PositionParam positionParam)
        {
            var result = 0;
            var position = new Position();
            position.Name = positionParam.Name;
            position.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Positions.Add(position);
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

        public bool Update(int? Id, PositionParam positionParam)
        {
            var result = 0;
            var get = Get(Id);
            get.Name = positionParam.Name;
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
