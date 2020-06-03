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
    public class TransazioniController : ApiController
    {
		string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=banking;";

		private List<TransazioniModel> _lstTran;
		private TransazioniModel _c;
		[HttpGet]
		public IHttpActionResult GetTransazioni(string par1)
		{
			_lstTran = new List<TransazioniModel>();
			string query = "SELECT * FROM conto_corrente,transazione WHERE  conto_corrente.IBAN_conto='"+par1+ "' AND  conto_corrente.IBAN_conto=transazione.IBAN_conto";
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
						_c = new TransazioniModel();
						_c.id_transazione = Convert.ToInt32(dr["id_transazione"]);
						_c.controparte = dr["controparte"].ToString();
						_c.data_transazione = dr["data_transazione"].ToString();
						_c.entrata_uscita = dr["entrata_uscita"].ToString();
						_c.stato = dr["stato"].ToString();
						_c.importo = Convert.ToDouble(dr["importo"]);
					


						_lstTran.Add(_c);



					}
				}



				databaseConnection.Close();
			}
			catch (Exception ex)
			{

			}

			return Json(_lstTran);
		}

		public IHttpActionResult GetTransazioniLimit(string par1)
		{
			_lstTran = new List<TransazioniModel>();
			string query = "SELECT * FROM conto_corrente,transazione WHERE  conto_corrente.IBAN_conto='" + par1 + "' AND  conto_corrente.IBAN_conto=transazione.IBAN_conto ORDER BY id_transazione DESC LIMIT 4";
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
						_c = new TransazioniModel();
						_c.id_transazione = Convert.ToInt32(dr["id_transazione"]);
						_c.controparte = dr["controparte"].ToString();
						_c.data_transazione = dr["data_transazione"].ToString();
						_c.entrata_uscita = dr["entrata_uscita"].ToString();
						_c.stato = dr["stato"].ToString();
						_c.importo = Convert.ToDouble(dr["importo"]);



						_lstTran.Add(_c);



					}
				}



				databaseConnection.Close();
			}
			catch (Exception ex)
			{

			}

			return Json(_lstTran);
		}
		[HttpPost]
		public string insertTransazioni([FromBody]TransazioniModel a)
		{

			string query = "INSERT INTO transazione(IBAN_mittente,IBAN_creditore,controparte,data_transazione,entrata_uscita,stato,importo,IBAN_conto,id_tipo_transazione) VALUES ('" + a.IBAN_mittente + "', '" + a.IBAN_creditore + "', '" + a.controparte + "', '" + a.data_transazione + "', '" + a.entrata_uscita + "', '" + a.stato + "', " + a.importo + ", '" + a.IBAN_mittente + "', " + a.id_tipo_transazione + ")";

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
		// GET: api/Transazioni
		public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Transazioni/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Transazioni
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Transazioni/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Transazioni/5
        public void Delete(int id)
        {
        }
    }
}
