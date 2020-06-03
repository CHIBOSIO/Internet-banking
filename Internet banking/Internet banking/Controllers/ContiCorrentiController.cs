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
    public class ContiCorrentiController : ApiController
    {
		string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=banking;";

		private List<ContiCorrentiModel> _lstConti;
		private ContiCorrentiModel _c;

		[HttpGet]
		public IHttpActionResult GetIban(int par1)
		{
			_lstConti = new List<ContiCorrentiModel>();
			string query = "SELECT * FROM conto_corrente WHERE id_cliente=" + par1 + ";";
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
						_c = new ContiCorrentiModel();
						_c.IBAN_conto = dr["IBAN_conto"].ToString();
						_c.data_apertura = dr["data_apertura"].ToString();
						_c.saldo_conto = Convert.ToDouble(dr["saldo_conto"]);
						_c.id_cliente = Convert.ToInt32(dr["id_cliente"]);


						_lstConti.Add(_c);



					}
				}



				databaseConnection.Close();
			}
			catch (Exception ex)
			{

			}

			return Json(_lstConti);
		}
		[HttpGet]
		public IHttpActionResult GetSommaIban(int par1)
		{
			_lstConti = new List<ContiCorrentiModel>();
			string query = "SELECT SUM(saldo_conto) AS somma FROM conto_corrente WHERE id_cliente=" + par1 + ";";
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
						_c = new ContiCorrentiModel();
				
						_c.saldo_iban = Convert.ToDouble(dr["somma"]);


						_lstConti.Add(_c);



					}
				}



				databaseConnection.Close();
			}
			catch (Exception ex)
			{

			}

			return Json(_lstConti);
		}
		[HttpGet]
		public IHttpActionResult GetSaldo(string par1)
		{
			_lstConti = new List<ContiCorrentiModel>();
			string query = "SELECT * FROM conto_corrente WHERE IBAN_conto='" + par1 + "';";
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
						_c = new ContiCorrentiModel();
						_c.IBAN_conto = dr["IBAN_conto"].ToString();
						_c.data_apertura = dr["data_apertura"].ToString();
						_c.saldo_conto = Convert.ToDouble(dr["saldo_conto"]);
						_c.id_cliente = Convert.ToInt32(dr["id_cliente"]);


						_lstConti.Add(_c);



					}
				}



				databaseConnection.Close();
			}
			catch (Exception ex)
			{

			}

			return Json(_lstConti);
		}

		[HttpGet]
		public IHttpActionResult GetSaldoTran(double par1,string par2)
		{
			_lstConti = new List<ContiCorrentiModel>();
			string query = "SELECT IBAN_conto, (saldo_conto - " + par1+") FROM conto_corrente WHERE IBAN_conto='" + par2 + "';";
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
						_c = new ContiCorrentiModel();
						_c.IBAN_conto = dr["IBAN_conto"].ToString();
						_c.data_apertura = dr["data_apertura"].ToString();
						_c.saldo_conto = Convert.ToDouble(dr["saldo_conto"]);
						_c.id_cliente = Convert.ToInt32(dr["id_cliente"]);


						_lstConti.Add(_c);



					}
				}



				databaseConnection.Close();
			}
			catch (Exception ex)
			{

			}

			return Json(_lstConti);
		}
		[HttpGet]
		public string updateConto(double par1, string par2)
		{

			string query = "UPDATE conto_corrente SET saldo_conto=" + par1 + " WHERE IBAN_conto='" + par2 + "';";
			// Which could be translated manually to :
			// INSERT INTO user(`id`, `first_name`, `last_name`, `address`) VALUES (NULL, 'Bruce', 'Wayne', 'Wayne Manor')

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
		// GET: api/ContiCorrenti
		public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ContiCorrenti/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ContiCorrenti
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ContiCorrenti/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ContiCorrenti/5
        public void Delete(int id)
        {
        }
    }
}
