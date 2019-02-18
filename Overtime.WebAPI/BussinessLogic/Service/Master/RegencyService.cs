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
    public class RegencyService : IRegencyService
    {
        private readonly IRegencyRepository _regencyRepository;

        public RegencyService(IRegencyRepository regencyRepository)
        {
            _regencyRepository = regencyRepository;
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
                status = _regencyRepository.Delete(Id);
                Console.WriteLine("Success");
            }
            return status;
        }

        public List<Regency> Get()
        {
            return _regencyRepository.Get();
        }

        public Regency Get(int? Id)
        {
            var getRegencyId = _regencyRepository.Get(Id);
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            return getRegencyId;
        }

        public bool Insert(RegencyParam regencyParam)
        {
            if (regencyParam == null)
            {
                Console.WriteLine("Insert Name");
                Console.Read();
            }
            else
            {
                status = _regencyRepository.Insert(regencyParam);
                Console.WriteLine("Success");
            }
            return status;
        }

        public bool Update(int? Id, RegencyParam regencyParam)
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
                status = _regencyRepository.Update(Id, regencyParam);
                Console.WriteLine("update Success");
            }
            return status;
        }
    }
}
