using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.DAL;

namespace WebService.Controllers
{
    public class StatsTablesController : ApiController
    {
        // GET: api/StatsTables
        public object Get()
        {
            GetDataFromDatabase getData = new GetDataFromDatabase();
            return getData.ProcedureGetDataFromStatTables();
        }

        // GET: api/StatsTables/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/StatsTables
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/StatsTables/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/StatsTables/5
        public void Delete(int id)
        {
        }
    }
}
