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
    public class CarteController : ApiController
    {
		string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=banking;";

		private List<CarteModel> _lstCarte;
		private CarteModel _c;

		[HttpGet]
		public IHttpActionResult GetCarte(int par1)
		{
			_lstCarte = new List<CarteModel>();
			string query = "SELECT * FROM conto_corrente,carte WHERE  conto_corrente.id_cliente=" + par1 + " AND  conto_corrente.IBAN_conto=carte.IBAN_conto";
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
						_c = new CarteModel();
						_c.id_carta = Convert.ToInt32(dr["id_carta"]);
						_c.cvc = Convert.ToInt32(dr["cvc"]);
						_c.nr_carta = dr["nr_carta"].ToString();
						_c.circuito = dr["circuito"].ToString();
						_c.data_apertura = dr["data_apertura"].ToString();
						_c.data_scadenza = dr["data_scadenza"].ToString();
						_c.saldo = Convert.ToDouble(dr["saldo"]);
						_c.massimale = Convert.ToDouble(dr["massimale"]);
						_c.IBAN_conto = dr["IBAN_conto"].ToString();

						_lstCarte.Add(_c);



					}
				}



				databaseConnection.Close();
			}
			catch (Exception ex)
			{

			}

			return Json(_lstCarte);
		}
		public IHttpActionResult GetCarta(int par1)
		{
			_lstCarte = new List<CarteModel>();
			string query = "SELECT * FROM carte WHERE id_carta=" + par1 + ";";
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
						_c = new CarteModel();
						_c.id_carta = Convert.ToInt32(dr["id_carta"]);
						_c.cvc = Convert.ToInt32(dr["cvc"]);
						_c.nr_carta = dr["nr_carta"].ToString();
						_c.circuito = dr["circuito"].ToString();
						_c.data_apertura = dr["data_apertura"].ToString();
						_c.data_scadenza = dr["data_scadenza"].ToString();
						_c.saldo = Convert.ToDouble(dr["saldo"]);
						_c.massimale = Convert.ToDouble(dr["massimale"]);
						_c.IBAN_conto = dr["IBAN_conto"].ToString();

						_lstCarte.Add(_c);



					}
				}



				databaseConnection.Close();
			}
			catch (Exception ex)
			{

			}

			return Json(_lstCarte);
		}
		public IHttpActionResult GetSommaCarte(int par1)
		{
			_lstCarte = new List<CarteModel>();
			string query = "SELECT SUM(saldo) AS somma FROM carte,conto_corrente WHERE id_cliente=" + par1 + " and conto_corrente.IBAN_conto=carte.IBAN_conto;";
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
						_c = new CarteModel();

						_c.saldo_carte = Convert.ToDouble(dr["somma"]);

						_lstCarte.Add(_c);



					}
				}



				databaseConnection.Close();
			}
			catch (Exception ex)
			{

			}

			return Json(_lstCarte);
		}
		
		[HttpGet]
		public string updateCarta(double par1, int par2)
		{

			string query = "UPDATE carte SET saldo=" + par1 + " WHERE id_carta=" + par2 + ";";
		

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
	}
}
