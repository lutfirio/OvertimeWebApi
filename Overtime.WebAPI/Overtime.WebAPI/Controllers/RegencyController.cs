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
    public class RegencyController : ApiController
    {
        private readonly IRegencyService _regencyService;
        public RegencyController() { }
        public RegencyController(IRegencyService regencyService)
        {
            _regencyService = regencyService;
        }
        // GET: api/Regency
        public IEnumerable<Regency> Get()
        {
            return _regencyService.Get();
        }

        // GET: api/Regency/5
        public Regency Get(int id)
        {
            var get = _regencyService.Get(id);
            return get;
        }

        // POST: api/Regency
        [HttpPost]
        public void Post(RegencyParam regencyParam)
        {
            _regencyService.Insert(regencyParam);
        }

        // PUT: api/Regency/5
        public void Put(int id, RegencyParam regencyParam)
        {
            _regencyService.Update(id, regencyParam);
        }

        // DELETE: api/Regency/5
        public void Delete(int id)
        {
            _regencyService.Delete(id);
        }
    }
}
