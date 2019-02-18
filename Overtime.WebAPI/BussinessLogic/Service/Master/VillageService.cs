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
    public class VillageService : IVillageService
    {
        private readonly IVillageRepository _villageRepository;
        public VillageService(IVillageRepository villageRepository)
        {
            _villageRepository = villageRepository;
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
                status = _villageRepository.Delete(Id);
                Console.WriteLine("Success");
            }
            return status;
        }

        public List<Village> Get()
        {
            return _villageRepository.Get();
        }

        public Village Get(int? Id)
        {
            var getVillagetId = _villageRepository.Get(Id);
            if (Id == null)
            {
                Console.WriteLine("Insert Id");
                Console.Read();
            }
            return getVillagetId;
        }

        public bool Insert(VillageParam villageParam)
        {
            if (villageParam == null)
            {
                Console.WriteLine("Insert Name");
                Console.Read();
            }
            else
            {
                status = _villageRepository.Insert(villageParam);
                Console.WriteLine("Success");
            }
            return status;
        }

        public bool Update(int? Id, VillageParam villageParam)
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
                status = _villageRepository.Update(Id, villageParam);
                Console.WriteLine("update Success");
            }
            return status;
        }
    }
}
