using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.DAL;

namespace WebService.Controllers
{
    public class TableNamesController : ApiController
    {
        // GET: api/TableNames
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TableNames/5
        public object Get(string owner)
        {
            GetDataFromDatabase getData = new GetDataFromDatabase();
            return getData.ProcedureGetDataFromTableName(owner);
        }

        // POST: api/TableNames
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TableNames/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TableNames/5
        public void Delete(int id)
        {
        }
    }
}
