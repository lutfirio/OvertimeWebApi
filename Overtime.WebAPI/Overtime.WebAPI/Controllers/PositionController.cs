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
    public class PositionController : ApiController
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }
        // GET: api/Position
        public IEnumerable<Position> Get()
        {
            return _positionService.Get();
        }

        // GET: api/Position/5
        public Position Get(int id)
        {
            var get = _positionService.Get(id);
            return get;
        }

        // POST: api/Position
        [HttpPost]
        public void Post(PositionParam positionParam)
        {
            _positionService.Insert(positionParam);
        }

        // PUT: api/Position/5
        public void Put(int id, PositionParam positionParam)
        {
            _positionService.Update(id, positionParam);
        }

        // DELETE: api/Position/5
        public void Delete(int id)
        {
            _positionService.Delete(id);
        }
    }
}
