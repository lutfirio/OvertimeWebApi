using BussinessLogic.Service;
using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Overtime.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VillageController : ApiController
    {
        private readonly IVillageService _villageService;
        public VillageController() { }
        public VillageController(IVillageService villageService)
        {
            _villageService = villageService;
        }
        // GET: api/Village
        public IEnumerable<Village> Get()
        {
            return _villageService.Get();
        }

        // GET: api/Village/5
        public Village Get(int id)
        {
            var get = _villageService.Get(id);
            return get;
        }

        // POST: api/Village
        [HttpPost]
        public void Post(VillageParam villageParam)
        {
            _villageService.Insert(villageParam);
        }

        // PUT: api/Village/5
        public void Put(int id, VillageParam villageParam)
        {
            _villageService.Update(id, villageParam);
        }


        // DELETE: api/Village/5
        public void Delete(int id)
        {
            _villageService.Delete(id);
        }
    }
}
