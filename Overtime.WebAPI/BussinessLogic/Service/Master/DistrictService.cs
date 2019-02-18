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
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        public DistrictService(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
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
                status = _districtRepository.Delete(Id);
                Console.WriteLine("Success");
            }
            return status;
        }

        public List<District> Get()
        {
            return _districtRepository.Get();
        }

        public District Get(int? Id)
        {
            var getDistrictId = _districtRepository.Get(Id);
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            return getDistrictId;
        }

        public bool Insert(DistrictParam districtParam)
        {
            if (districtParam == null)
            {
                Console.WriteLine("Insert Name");
                Console.Read();
            }
            else
            {
                status = _districtRepository.Insert(districtParam);
                Console.WriteLine("Success");
            }
            return status;
        }

        public bool Update(int? Id, DistrictParam districtParam)
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
                status = _districtRepository.Update(Id, districtParam);
                Console.WriteLine("update Success");
            }
            return status;
        }
    }
}
