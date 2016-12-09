using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.DAL;

namespace WebService.Controllers
{
    public class StatsColumnsController : ApiController
    {
        // GET: api/StatsColumns
        public object Get()
        {
            GetDataFromDatabase getData = new GetDataFromDatabase();
            return getData.ProcedureGetDataFromStatColumns();
        }

        // GET: api/StatsColumns/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/StatsColumns
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/StatsColumns/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/StatsColumns/5
        public void Delete(int id)
        {
        }
    }
}
