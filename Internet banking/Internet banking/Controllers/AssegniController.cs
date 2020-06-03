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
    public class AssegniController : ApiController
    {
		string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=banking;";

		private List<AssegniModel> _lstAssegni;
		private AssegniModel _c;

		[HttpGet]
		public IHttpActionResult GetAssegni(int par1)
		{
			_lstAssegni = new List<AssegniModel>();
			string query = "SELECT * FROM conto_corrente,assegni WHERE conto_corrente.id_cliente=" + par1 + " AND conto_corrente.IBAN_conto=assegni.IBAN_conto";
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
						_c = new AssegniModel();
						_c.id_carnet = Convert.ToInt32(dr["id_carnet"]);
						_c.IBAN_conto = dr["IBAN_conto"].ToString();
						_c.data_emissione = dr["data_emissione"].ToString();


						_lstAssegni.Add(_c);



					}
				}



				databaseConnection.Close();
			}
			catch (Exception ex)
			{

			}

			return Json(_lstAssegni);
		}
		[HttpPost]
		public string insertAssegno([FromBody]AssegniModel a)
		{

			string query = "INSERT INTO assegni (IBAN_conto, data_emissione) VALUES ('" + a.IBAN_conto + "', '" + a.data_emissione + "')";

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
		// GET: api/Assegni
		public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Assegni/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Assegni
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Assegni/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Assegni/5
        public void Delete(int id)
        {
        }
    }
}
