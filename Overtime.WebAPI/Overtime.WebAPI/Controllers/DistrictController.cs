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
    public class DistrictController : ApiController
    {
        private readonly IDistrictService _districtService;
        public DistrictController() { }
        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }
        // GET: api/District
        public IEnumerable<District> Get()
        {
            return _districtService.Get();
        }

        // GET: api/District/5
        public District Get(int id)
        {
            var get = _districtService.Get(id);
            return get;
        }

        // POST: api/District
        [HttpPost]
        public void Post(DistrictParam districtParam)
        {
            _districtService.Insert(districtParam);
        }

        // PUT: api/District/5
        public void Put(int id, DistrictParam districtParam)
        {
            _districtService.Update(id, districtParam);
        }

        // DELETE: api/District/5
        public void Delete(int id)
        {
            _districtService.Delete(id);
        }
    }
}
