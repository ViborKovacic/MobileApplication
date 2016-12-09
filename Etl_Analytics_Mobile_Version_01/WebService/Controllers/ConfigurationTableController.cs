using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.DAL;

namespace WebService.Controllers
{
    public class ConfigurationTableController : ApiController
    {
        // GET: api/ConfigurationTable
        public object Get()
        {
            GetDataFromDatabase getData = new GetDataFromDatabase();
            return getData.ProcedureGetDataFromConfigurationTables();
        }

        // GET: api/ConfigurationTable/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ConfigurationTable
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ConfigurationTable/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ConfigurationTable/5
        public void Delete(int id)
        {
        }
    }
}
