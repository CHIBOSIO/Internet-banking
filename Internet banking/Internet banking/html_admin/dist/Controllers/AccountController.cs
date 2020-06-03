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
    public class AccountController : ApiController
    {
		string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=rr;database=banking;";

		private List<AccountModel> _lstAccount;
		private AccountModel _a;
		// GET: api/Account
		public IHttpActionResult GetAllAccount()
		{
			_lstAccount = new List<AccountModel>();
			string query = "SELECT * FROM account";
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
						_a = new AccountModel();
						_a.username_cliente = Convert.ToInt32(dr["username_cliente"]);
						_a.password_cliente = dr["password_cliente"].ToString();
						_a.data_attivazione = dr["data_attivazione"].ToString();
						_a.primo_accesso = dr["primo_accesso"].ToString();
						_a.id_cliente = Convert.ToInt32(dr["id_cliente"]);
						_a.id_amministratore = Convert.ToInt32(dr["id_amministratore"]);
						_lstAccount.Add(_a);



					}
				}
				

			
				databaseConnection.Close();
			}
			catch (Exception ex)
			{
				
			}
			
			return Json(_lstAccount);
		}

        // GET: api/Account/5
        public string Get(int id)
        {
            return "value";
        }

		[HttpPost]
        // POST: api/Account
        public IHttpActionResult accessoAccount([FromBody]AccountModel a)
        {
			_lstAccount = new List<AccountModel>();
			string query = "SELECT * FROM account where username_cliente="+ a.username_cliente+ " and password_cliente='" + a.password_cliente+"';";
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
						_a = new AccountModel();
						_a.username_cliente = Convert.ToInt32(dr["username_cliente"]);
						_a.password_cliente = dr["password_cliente"].ToString();
						_a.data_attivazione = dr["data_attivazione"].ToString();
						_a.primo_accesso = dr["primo_accesso"].ToString();
						_a.id_cliente = Convert.ToInt32(dr["id_cliente"]);
						_a.id_amministratore = Convert.ToInt32(dr["id_amministratore"]);
						_lstAccount.Add(_a);



					}
				}



				databaseConnection.Close();
			}
			catch (Exception ex)
			{
				
			}

			return Json(_lstAccount);
		}

        // PUT: api/Account/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Account/5
        public void Delete(int id)
        {
        }
    }
}
