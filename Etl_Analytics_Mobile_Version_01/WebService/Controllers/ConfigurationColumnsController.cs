using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.DAL;

namespace WebService.Controllers
{
    public class ConfigurationColumnsController : ApiController
    {
        // GET: api/ConfigurationColumns
        public object Get()
        {
            GetDataFromDatabase getData = new GetDataFromDatabase();
            return getData.ProcedureGetDataFromConfigurationColumns();
        }

        // GET: api/ConfigurationColumns/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ConfigurationColumns
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ConfigurationColumns/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ConfigurationColumns/5
        public void Delete(int id)
        {
        }
    }
}
