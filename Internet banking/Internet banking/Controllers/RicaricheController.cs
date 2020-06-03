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
    public class RicaricheController : ApiController
    {
		string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=banking;";

		private List<RicaricheModel> _lstRicariche;
		private RicaricheModel _c;

		[HttpGet]
		public IHttpActionResult GetRicariche(int par1)
		{
			_lstRicariche = new List<RicaricheModel>();
			string query = "SELECT * FROM conto_corrente,ricarica_telefonica WHERE conto_corrente.id_cliente=" + par1 + " AND conto_corrente.IBAN_conto=ricarica_telefonica.IBAN_conto";
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
						_c = new RicaricheModel();
						_c.id_ricarica = Convert.ToInt32(dr["id_ricarica"]);
						_c.nr_telefono = dr["nr_telefono"].ToString();
						_c.oeratore = dr["oeratore"].ToString();
						_c.IBAN_operatore = dr["IBAN_operatore"].ToString();
						_c.data_ricarica = dr["data_ricarica"].ToString();
						_c.importo = Convert.ToDouble(dr["importo"]);
						_c.IBAN_conto = dr["IBAN_conto"].ToString();


						_lstRicariche.Add(_c);



					}
				}



				databaseConnection.Close();
			}

			catch (Exception ex)
			{

			}

			return Json(_lstRicariche);
		}
		[HttpPost]
		public string insertRicarica([FromBody]RicaricheModel a)
		{

			string query = "INSERT INTO ricarica_telefonica (nr_telefono, oeratore,data_ricarica,importo,IBAN_operatore,IBAN_conto) VALUES ('" + a.nr_telefono + "', '" + a.oeratore + "', '" + a.data_ricarica + "', " + a.importo + ", '" + a.IBAN_operatore + "', '" + a.IBAN_conto + "')";

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

		// GET: api/Ricariche
		public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Ricariche/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Ricariche
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Ricariche/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Ricariche/5
        public void Delete(int id)
        {
        }
    }
}
