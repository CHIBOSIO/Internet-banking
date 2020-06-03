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
		string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=banking;";

		private List<TrasferimentoModel> _lstTrasf;
		private TrasferimentoModel _a;
		// GET: api/Trasferimento
		[HttpPost]
		public string insertTrasferimento([FromBody]TrasferimentoModel a)
		{

			string query = "INSERT INTO trasferimento_denaro (importo,data_trasferimento,IBAN_destinatario,causale,IBAN_conto,id_benificiario) VALUES (" + a.importo + ", '" + a.data_trasferimento + "', '" + a.IBAN_destinatario + "', '" + a.causale + "', '" + a.IBAN_conto + "', " + a.id_benificiario + ")";

			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
			commandDatabase.CommandTimeout = 60;

			try
			{
				databaseConnection.Open();
				MySqlDataReader myReader = commandDatabase.ExecuteReader();
				databaseConnection.Close();
				return "OK";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}

		}

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
