using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using Newtonsoft.Json;
using System.Data;
using MySql.Data.MySqlClient;
using Internet_banking.Models;

namespace Internet_banking.Controllers
{
    public class TrasferimentoController : ApiController
    {
        // GET: api/Trasferimento
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Trasferimento/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Trasferimento
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Trasferimento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Trasferimento/5
        public void Delete(int id)
        {
        }
    }
}
