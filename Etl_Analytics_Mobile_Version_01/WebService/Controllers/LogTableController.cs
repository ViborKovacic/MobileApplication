using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.DAL;

namespace WebService.Controllers
{
    public class LogTableController : ApiController
    {
        // GET: api/LogTable
        public object Get()
        {
            GetDataFromDatabase getData = new GetDataFromDatabase();
            return getData.ProcedureGetDataFromLogTable();
        }

        // GET: api/LogTable/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/LogTable
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/LogTable/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LogTable/5
        public void Delete(int id)
        {
        }
    }
}
