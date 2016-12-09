using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.DAL;

namespace WebService.Controllers
{
    public class ParametersVariableController : ApiController
    {
        // GET: api/ParametersVariable
        public object Get()
        {
            GetDataFromDatabase getData = new GetDataFromDatabase();
            return getData.ProcedureGetDataFromParametersValue();
        }

        // GET: api/ParametersVariable/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ParametersVariable
        public void Post([FromBody]string value)
        {
            //string userName = "";
            //InsertDataIntoDatabase insertData = new InsertDataIntoDatabase();
            //insertData.ProcedureInsertIntoUserTable(value);
            //userName = user.USER_NAME;
            //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            ////response.Headers.Location = new Uri(Request.RequestUri, String.Format("UserTable/{0}", id));
            //return response;
        }

        // PUT: api/ParametersVariable/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ParametersVariable/5
        public void Delete(int id)
        {
        }
    }
}
