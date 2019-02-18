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
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        bool status = false;
        public bool Delete(int? Id)
        {
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            else if (Id == ' ')
            {
                Console.WriteLine("Dont Insert Blank Caracter");
                Console.Read();
            }
            else
            {
                status = _positionRepository.Delete(Id);
                Console.WriteLine("Success");
            }
            return status;
        }

        public List<Position> Get()
        {
            return _positionRepository.Get();
        }

        public Position Get(int? Id)
        {
            var getPositionId = _positionRepository.Get(Id);
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            return getPositionId;
        }

        public bool Insert(PositionParam positionParam)
        {
            if (positionParam == null)
            {
                Console.WriteLine("Insert Name");
                Console.Read();
            }
            else
            {
                status = _positionRepository.Insert(positionParam);
                Console.WriteLine("Success");
            }
            return status;
        }

        public bool Update(int? Id, PositionParam positionParam)
        {
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            else if (Id == ' ')
            {
                Console.WriteLine("Dont Insert Blank Caracter");
                Console.Read();
            }
            else
            {
                status = _positionRepository.Update(Id, positionParam);
                Console.WriteLine("update Success");
            }
            return status;
        }
    }
}
