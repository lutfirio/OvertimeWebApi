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
    public class ProvinceController : ApiController
    {
        private readonly IProvinceService _provinceService;

        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }
        // GET: api/Province
        public IEnumerable<Province> Get()
        {
            return _provinceService.Get();
        }

        // GET: api/Province/5
        public Province Get(int id)
        {
            var get = _provinceService.Get(id);
            return get;
        }

        // POST: api/Province
        [HttpPost]
        public void Post(ProvinceParam provinceParam)
        {
            _provinceService.Insert(provinceParam);
        }

        // PUT: api/Province/5
        public void Put(int id, ProvinceParam provinceParam)
        {
            _provinceService.Update(id, provinceParam);
        }

        // DELETE: api/Province/5
        public void Delete(int id)
        {
            _provinceService.Delete(id);
        }
    }
}
