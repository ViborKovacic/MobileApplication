using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.DAL;

namespace WebService.Controllers
{
    public class ColumnNameController : ApiController
    {
        // GET: api/ColumnName
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ColumnName/5
        public object Get(string owner, string table_name)
        {
            GetDataFromDatabase getData = new GetDataFromDatabase();
            return getData.ProcedureGetDataFromColumnName(owner, table_name);
        }

        // POST: api/ColumnName
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ColumnName/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ColumnName/5
        public void Delete(int id)
        {
        }
    }
}
