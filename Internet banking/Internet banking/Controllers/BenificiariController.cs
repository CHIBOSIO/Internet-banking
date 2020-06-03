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
    public class BenificiariController : ApiController
    {
		string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=banking;";

		private List<BenificiariModel> _lstBene;
		private BenificiariModel _c;

		[HttpGet]
		public IHttpActionResult GetAllBeneficiari(int par1)
		{
			_lstBene = new List<BenificiariModel>();
			string query = "SELECT * FROM benificiario WHERE id_cliente="+par1+";";
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
						_c = new BenificiariModel();
						_c.id_benificiario = Convert.ToInt32(dr["id_benificiario"]);
						_c.nome_cliente = dr["nome_cliente"].ToString();
						_c.cognome_cliente = dr["cognome_cliente"].ToString();
						_c.IBAN_benificiario = dr["IBAN_benificiario"].ToString();
						_c.indirizzo = dr["indirizzo"].ToString();
						_c.citta = dr["citta"].ToString();
						_c.id_cliente = Convert.ToInt32(dr["id_cliente"]);
						_c.id_banca = Convert.ToInt32(dr["id_banca"]);

						_lstBene.Add(_c);



					}
				}



				databaseConnection.Close();
			}
			catch (Exception ex)
			{

			}

			return Json(_lstBene);
		}


		[HttpGet]
		public IHttpActionResult GetBeneficiari(int par1)
		{
			_lstBene = new List<BenificiariModel>();
			string query = "SELECT * FROM benificiario WHERE id_benificiario=" + par1 + ";";
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
						_c = new BenificiariModel();
						_c.id_benificiario = Convert.ToInt32(dr["id_benificiario"]);
						_c.nome_cliente = dr["nome_cliente"].ToString();
						_c.cognome_cliente = dr["cognome_cliente"].ToString();
						_c.IBAN_benificiario = dr["IBAN_benificiario"].ToString();
						_c.indirizzo = dr["indirizzo"].ToString();
						_c.citta = dr["citta"].ToString();
						_c.id_cliente = Convert.ToInt32(dr["id_cliente"]);
						_c.id_banca = Convert.ToInt32(dr["id_banca"]);

						_lstBene.Add(_c);



					}
				}



				databaseConnection.Close();
			}
			catch (Exception ex)
			{

			}

			return Json(_lstBene);
		}

		[HttpPost]
		public string insertBeneficiario([FromBody]BenificiariModel a)
		{
			
			string query = "INSERT INTO benificiario (nome_cliente, cognome_cliente, IBAN_benificiario, id_cliente,id_banca, indirizzo,citta) VALUES ('" + a.nome_cliente + "', '" + a.cognome_cliente + "', '" + a.IBAN_benificiario + "', " + a.id_cliente + ", " + a.id_banca + ", '" + a.indirizzo + "', '" + a.citta + "')";

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
		// GET: api/Benificiari
		public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Benificiari/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Benificiari
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Benificiari/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Benificiari/5
        public void Delete(int id)
        {
        }
    }
}
