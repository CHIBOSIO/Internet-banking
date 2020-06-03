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
    public class UtenzeController : ApiController
    {
		string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=banking;";

		private List<UtenzeModel> _lstUtenze;
		private UtenzeModel _c;

		[HttpGet]
		public IHttpActionResult GetUtenze(string par1)
		{
			_lstUtenze = new List<UtenzeModel>();
			string query = "SELECT * FROM utenze_domiciliate WHERE IBAN_conto='" + par1 + "';";
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
						_c = new UtenzeModel();
						_c.id_utenza = Convert.ToInt32(dr["id_utenza"]);
						_c.data_attivazione = dr["data_attivazione"].ToString();
						_c.azienda = dr["azienda"].ToString();
						_c.IBAN_creditore = dr["IBAN_creditore"].ToString();
						_c.stato = dr["stato"].ToString();
						_c.IBAN_conto =dr["IBAN_conto"].ToString();

						_lstUtenze.Add(_c);



					}
				}



				databaseConnection.Close();
			}
			catch (Exception ex)
			{

			}

			return Json(_lstUtenze);
		}
		// GET: api/Utenze
		public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Utenze/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Utenze
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Utenze/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Utenze/5
        public void Delete(int id)
        {
        }
    }
}
