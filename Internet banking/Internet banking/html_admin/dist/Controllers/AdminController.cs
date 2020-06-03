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
    public class AdminController : ApiController
    {
		string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=banking;";

		private List<AdminModel> _lstAdmin;
		private AdminModel _a;
		// GET: api/Admin
		public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Admin/5
        public string Get(int id)
        {
            return "value";
        }
		[HttpPost]
		public IHttpActionResult accessoAdmin([FromBody]AdminModel a)
		{
			_lstAdmin = new List<AdminModel>();
			string query = "SELECT * FROM amministratore where username_amministratore='" + a.username_amministratore + "' and password_amministratore='" + a.password_amministratore + "';";
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
						_a = new AdminModel();
						_a.id_amministratore = Convert.ToInt32(dr["id_amministratore"]);
						_a.username_amministratore = dr["username_amministratore"].ToString();
						_a.password_amministratore = dr["password_amministratore"].ToString();
						_a.nome_amministratore = dr["nome_amministratore"].ToString();
						_a.cognome_amministratore = dr["cognome_amministratore"].ToString();
						
						_lstAdmin.Add(_a);



					}
				}



				databaseConnection.Close();
			}
			catch (Exception ex)
			{

			}

			return Json(_lstAdmin);
		}

		// POST: api/Admin
		public void Post([FromBody]string value)
        {
        }

        // PUT: api/Admin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Admin/5
        public void Delete(int id)
        {
        }
    }
}
