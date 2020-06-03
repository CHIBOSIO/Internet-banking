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
using System.Net.Mail;

namespace Internet_banking.Controllers
{
    public class AccountController : ApiController
    {
		string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=banking;";

		private List<AccountModel> _lstAccount;
		private AccountModel _a;
		private ClienteModel _c;
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
		[HttpGet]
		public IHttpActionResult inviaEmail(int par1)
		{
			_lstAccount = new List<AccountModel>();
			string query = "SELECT * FROM account,cliente where account.id_cliente=cliente.id_cliente and account.id_cliente=" + par1+";";
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
						_c = new ClienteModel();
						_a.username_cliente = Convert.ToInt32(dr["username_cliente"]);
						_a.password_cliente = dr["password_cliente"].ToString();
						_a.data_attivazione = dr["data_attivazione"].ToString();
						_a.primo_accesso = dr["primo_accesso"].ToString();
						_a.id_cliente = Convert.ToInt32(dr["id_cliente"]);
						_a.id_amministratore = Convert.ToInt32(dr["id_amministratore"]);
						_c.email = dr["email"].ToString();
						invia(_a.username_cliente, _a.password_cliente, _c.email);
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
			string query = "SELECT * FROM account WHERE username_cliente="+ a.username_cliente+ " AND password_cliente='" + a.password_cliente+"';";
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
			commandDatabase.CommandTimeout = 60;
			MySqlDataReader dr;
			try
			{

				databaseConnection.Open();
				dr = commandDatabase.ExecuteReader();
				
				
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

				





				databaseConnection.Close();
			}
			catch (Exception ex)
			{
				
			}

			return Json(_lstAccount);
		}
		private void invia(int user, string pwd, string email_dest)
		{
			string subject = "CREDENZIALI ACCESSO INTERNET BANKING";
			string body = "<!DOCTYPE html>" +
"<html>" +
"  <body style='background-color: #222533; padding: 20px; font-family: font-size: 14px; line-height: 1.43; font-family: 'Helvetica Neue', 'Segoe U'I, 'Helvetica', 'Arial', 'sans-serif;'>" +
"    <div style='max-width: 600px; margin: 10px auto 20px; font-size: 12px; color: #A5A5A5; text-align: center;'>" +
"      Se non riesci a visualizzare il messaggio  <a href='#' style='color: #A5A5A5; text-decoration: underline;'>clicca qui per il browser</a>" +
"    </div>" +
"    <div style='max-width: 600px; margin: 0px auto; background-color: #fff; box-shadow: 0px 20px 50px rgba(0,0,0,0.05);'>" +
"      <table style='width: 100%;'>" +
"        <tr>" +
"          <td style='background-color: #fff;'>" +
"            <img alt='' src='img/logo.png' style='width: 70px; padding: 20px'>" +
"          </td>" +
"          <td style='padding-left: 50px; text-align: right; padding-right: 20px;'>" +
"            <a href='#' style='color: #261D1D; text-decoration: underline; font-size: 14px; letter-spacing: 1px;'>Sign In</a><a href='#' style='color: #7C2121; text-decoration: underline; font-size: 14px; margin-left: 20px; letter-spacing: 1px;'>Forgot Password</a>" +
"          </td>" +
"        </tr>" +
"      </table><div style='padding: 60px 70px; border-top: 1px solid rgba(0,0,0,0.05);'>" +
"        <h1 style='margin-top: 0px;'>" +
"          Benvenuto su B-BANK" +
"        </h1>" +
"        <div style='color: #636363; font-size: 14px;'>" +
"          <p>" +
"           Grazie per aver creato un account sul nostro sito Internet banking , siamo lieti di darvi il benvenuto nella nostra famiglia. Abbiamo molte funzioni interessanti disponibili sul nostro sito Web, puoi dare un'occhiata a una breve descrizione delle funzionalità più popolari di seguito." +
"          </p>" +
"        </div>" +
"        <div style='border: 2px solid #09093C; padding: 40px; margin: 40px 0px;'>" +
"          <h4 style='margin-bottom: 20px; margin-top: 0px; font-size: 18px; display: inline-block; border-bottom: 1px dotted #111;'>" +
"            Incomincia" +
"          </h4>" +
"          <table style='width: 100%;'>" +
"            <tr>" +
"              <td style='padding: 10px 0px; border-bottom: 1px solid rgba(0,0,0,0.05);'>" +
"                <img alt='' src='img/bigicon7.png' style='width: 70px; height: auto;'>" +
"              </td>" +
"              <td style='padding-left: 30px; border-bottom: 1px solid rgba(0,0,0,0.05);'>" +
"                <div style='font-weight: bold; color: #09093C; font-size: 16px;'>" +
"                  Crea il tuo account" +
"                </div>" +
"                <div style='font-size: 14px; color: #B8B8B8;'>" +
"                  Super veloce" +
"                </div>" +
"              </td>" +
"			  " +
"            </tr>" +
"            <tr>" +
"              <td style='padding: 10px 0px; border-bottom: 1px solid rgba(0,0,0,0.05);'>" +
"                <img alt='' src='img/bigicon1.png' style='width: 70px; height: auto;'>" +
"              </td>" +
"              <td style='padding-left: 30px; border-bottom: 1px solid rgba(0,0,0,0.05);'>" +
"                <div style='font-weight: bold; color: #09093C; font-size: 16px;'>" +
"                 Personalizza i widget" +
"                </div>" +
"                <div style='font-size: 14px; color: #B8B8B8;'>" +
"                  Sistema versatile" +
"                </div>" +
"              </td>" +
"            </tr>" +
"                  " +
"          <table style='width: 100%; border-top: 1px solid #eee'>" +
"            <tr>" +
"              <td style='font-size: 14px;'>" +
"                Username: <strong>"+user+"</strong>" +
"				 " +
"              </td>" +
"			     <td style='font-size: 14px;'>" +
"             " +
"				  Username: <strong>" + pwd + "</strong>" +
"              </td>" +
"              " +
"            </tr>" +
"          </table>" +
"        </div>" +
"      " +
"        <div style='color: #A5A5A5; font-size: 12px;'>" +
"          <p>" +
"           " +
"Se hai domande, puoi semplicemente rispondere a questa email o trovare le nostre informazioni di contatto di seguito. Contattaci anche a <a href='#' style='text-decoration: underline; color: #09093C;'>bosiosbank@gmail.com</a>" +
"          </p>" +
"        </div>" +
"      </div><div style='background-color: #F5F5F5; padding: 40px; text-align: center;'>" +
"       " +
"        " +
"      " +
"      </div>" +
"    </div>" +
"  </body>" +
"</html>";




			string FromMail = "bosiosbank@gmail.com";
			string emailTo = email_dest;
			MailMessage mail = new MailMessage();
			mail.IsBodyHtml = true;
			SmtpClient SmtpServer = new SmtpClient
			{
				Host = "smtp.gmail.com",
				Port = 587,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				Credentials = new NetworkCredential(FromMail, "azsx1234."),
				Timeout = 20000

			};
			mail.From = new MailAddress(FromMail);
			mail.To.Add(emailTo);
			mail.Subject = subject;
			mail.Body = body;
			SmtpServer.Send(mail);
		}
		[HttpPost]
		public string updatePassword(AccountModel a)
		{

			string query = "UPDATE account SET password_cliente='" + a.password_cliente + "' WHERE id_cliente=" + a.id_cliente + ";";
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

		[HttpPost]
		public string insertAccount([FromBody]AccountModel a)
		{
			_lstAccount = new List<AccountModel>();
			string query = "INSERT INTO account (password_cliente, data_attivazione, primo_accesso, id_cliente, id_amministratore) VALUES ('" + a.password_cliente + "', '" + a.data_attivazione + "', '" + a.primo_accesso + "', " + a.id_cliente + ", " + a.id_amministratore + ")";

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
		[HttpGet]
		public string updateAccount(int par1)
		{
			_lstAccount = new List<AccountModel>();
			string query = "UPDATE cliente SET attivo='si' WHERE id_cliente="+par1+";";
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
