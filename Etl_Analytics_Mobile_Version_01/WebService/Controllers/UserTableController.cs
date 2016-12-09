using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.DAL;
using WebService.Models;

namespace WebService.Controllers
{
    public class UserTableController : ApiController
    {
        UserTable user = new UserTable();
        // GET: api/UserTable
        public object Get()
        {
            GetDataFromDatabase getData = new GetDataFromDatabase();
            return getData.ProcedureGetDataFromUserTable();
        }

        // GET: api/UserTable/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserTable
        public HttpResponseMessage Post([FromBody]UserTable value)
        {
            string userName = ""; 
            InsertDataIntoDatabase insertData = new InsertDataIntoDatabase();
            insertData.ProcedureInsertIntoUserTable(value);
            userName = user.USER_NAME;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            //response.Headers.Location = new Uri(Request.RequestUri, String.Format("UserTable/{0}", id));
            return response;
        }

        // PUT: api/UserTable/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserTable/5
        public void Delete(int id)
        {
        }
    }
}
