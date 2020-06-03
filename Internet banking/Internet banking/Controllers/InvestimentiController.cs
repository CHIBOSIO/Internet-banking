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
    public class InvestimentiController : ApiController
    {
		string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=banking;";

		private List<InvestimentiModel> _lstInve;
		private InvestimentiModel _c;

		[HttpGet]
		public IHttpActionResult GetInvestimento(string par1)
		{
			_lstInve = new List<InvestimentiModel>();
			string query = "SELECT * FROM investimenti WHERE IBAN_conto='" + par1 + "';";
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
			commandDatabase.CommandTimeout = 60;
			MySqlDataReader dr;
			try
			{

				databaseConnection.Open();
				dr = commandDatabase.ExecuteReader();
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						_c = new InvestimentiModel();
						_c.id_operazione = Convert.ToInt32(dr["id_operazione"]);
						_c.quantita = Convert.ToInt32(dr["quantita"]);
						_c.titolo = dr["titolo"].ToString();
						_c.data_investimento = dr["data_investimento"].ToString();
						_c.IBAN_conto = dr["IBAN_conto"].ToString();
						_c.prezzo = Convert.ToDouble(dr["prezzo"]);

						_lstInve.Add(_c);



					}
				}



				databaseConnection.Close();
			}
			catch (Exception ex)
			{

			}

			return Json(_lstInve);
		}
		// GET: api/Investimenti
		public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Investimenti/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Investimenti
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Investimenti/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Investimenti/5
        public void Delete(int id)
        {
        }
    }
}
