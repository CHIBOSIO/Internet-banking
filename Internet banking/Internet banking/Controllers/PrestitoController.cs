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
    public class PrestitoController : ApiController
    {
		string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=banking;";

		private List<PrestitoModel> _lstPrestito;
		private PrestitoModel _c;

		[HttpGet]
		public IHttpActionResult GetPrestiti(int par1)
		{
			_lstPrestito = new List<PrestitoModel>();
			string query = "SELECT * FROM prestito_mutuo WHERE id_cliente=" + par1 + ";";
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
						_c = new PrestitoModel();
						_c.id_prestito = Convert.ToInt32(dr["id_prestito"]);
						_c.importo = Convert.ToDouble(dr["importo"]);
						_c.data_emissione = dr["data_emissione"].ToString();
						_c.tasso = Convert.ToDouble(dr["tasso"]);
						_c.rata = Convert.ToDouble(dr["rata"]);
						_c.mensilita = Convert.ToInt32(dr["mensilita"]);
						_c.id_cliente = Convert.ToInt32(dr["id_cliente"]);
						_c.data_termine = dr["data_termine"].ToString();
						_c.tipo_prestito = dr["tipo_prestito"].ToString();
						_c.stato = dr["stato"].ToString();
						_c.importo_restituito = Convert.ToDouble(dr["importo_restituito"]);
						_lstPrestito.Add(_c);



					}
				}



				databaseConnection.Close();
			}
			catch (Exception ex)
			{

			}

			return Json(_lstPrestito);
		}
		[HttpGet]
		public IHttpActionResult GetPrestito(int par1)
		{
			_lstPrestito = new List<PrestitoModel>();
			string query = "SELECT * FROM prestito_mutuo WHERE id_prestito=" + par1 + ";";
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
						_c = new PrestitoModel();
						_c.id_prestito = Convert.ToInt32(dr["id_prestito"]);
						_c.importo = Convert.ToDouble(dr["importo"]);
						_c.data_emissione = dr["data_emissione"].ToString();
						_c.tasso = Convert.ToDouble(dr["tasso"]);
						_c.rata = Convert.ToDouble(dr["rata"]);
						_c.mensilita = Convert.ToInt32(dr["mensilita"]);
						_c.id_cliente = Convert.ToInt32(dr["id_cliente"]);
						_c.data_termine = dr["data_termine"].ToString();
						_c.tipo_prestito = dr["tipo_prestito"].ToString();
						_c.stato = dr["stato"].ToString();
						_c.importo_restituito = Convert.ToDouble(dr["importo_restituito"]);
						_lstPrestito.Add(_c);



					}
				}



				databaseConnection.Close();
			}
			catch (Exception ex)
			{

			}

			return Json(_lstPrestito);
		}
		// GET: api/Prestito
		public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Prestito/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Prestito
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Prestito/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Prestito/5
        public void Delete(int id)
        {
        }
    }
}
