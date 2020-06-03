﻿using System;
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
    public class ClienteController : ApiController
    {
		// GET: api/Cliente

		string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=banking;";

		private List<ClienteModel> _lstCliente;
		private ClienteModel _c;

		[HttpGet]
		public IHttpActionResult GetAllClienti()
		{
			_lstCliente = new List<ClienteModel>();
			string query = "SELECT * FROM cliente";
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
						_c = new ClienteModel();
						_c.id_cliente = Convert.ToInt32(dr["id_cliente"]);
						_c.nome_cliente= dr["nome_cliente"].ToString();
						_c.cognome_cliente = dr["cognome_cliente"].ToString();
						_c.data_nascita= dr["data_nascita"].ToString();
						_c.comune_nascita= dr["comune_nascita"].ToString();
						_c.nazionalita_cliente= dr["nazionalita_cliente"].ToString();
						_c.sesso= dr["sesso"].ToString();
						_c.indirizzo= dr["indirizzo"].ToString();
						_c.comune_residenza= dr["comune_residenza"].ToString();
						_c.codice_fiscale_cliente= dr["codice_fiscale_cliente"].ToString();
						_c.carta_identita= dr["carta_identita"].ToString();
						_c.num_telefono = dr["num_telefono"].ToString();
						_c.email = dr["email"].ToString();
						_c.attivo = dr["attivo"].ToString();

						_lstCliente.Add(_c);



					}
				}



				databaseConnection.Close();
			}
			catch (Exception ex)
			{

			}

			return Json(_lstCliente);
		}
		[HttpGet]
		public IHttpActionResult GetCliente(int par1)
		{
			_lstCliente = new List<ClienteModel>();
			string query = "SELECT * FROM cliente WHERE id_cliente="+par1+";";
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
						_c = new ClienteModel();
						_c.id_cliente = Convert.ToInt32(dr["id_cliente"]);
						_c.nome_cliente = dr["nome_cliente"].ToString();
						_c.cognome_cliente = dr["cognome_cliente"].ToString();
						_c.data_nascita = dr["data_nascita"].ToString();
						_c.comune_nascita = dr["comune_nascita"].ToString();
						_c.nazionalita_cliente = dr["nazionalita_cliente"].ToString();
						_c.sesso = dr["sesso"].ToString();
						_c.indirizzo = dr["indirizzo"].ToString();
						_c.comune_residenza = dr["comune_residenza"].ToString();
						_c.codice_fiscale_cliente = dr["codice_fiscale_cliente"].ToString();
						_c.carta_identita = dr["carta_identita"].ToString();
						_c.num_telefono = dr["num_telefono"].ToString();
						_c.email = dr["email"].ToString();
						_c.attivo = dr["attivo"].ToString();

						_lstCliente.Add(_c);



					}
				}



				databaseConnection.Close();
			}
			catch (Exception ex)
			{

			}

			return Json(_lstCliente);
		}
		[HttpPost]
		public string updateCliente([FromBody]ClienteModel a)
		{
			
			string query = "UPDATE cliente SET nazionalita_cliente='"+a.nazionalita_cliente+ "', sesso='" + a.sesso + "',indirizzo='" + a.indirizzo + "',comune_residenza='" + a.comune_residenza + "',carta_identita='" + a.carta_identita + "',num_telefono='" + a.num_telefono + "', email='" + a.email + "'  WHERE id_cliente=" + a.id_cliente + ";";
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


		// GET: api/Cliente/5
		public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cliente
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cliente/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cliente/5
        public void Delete(int id)
        {
        }
    }
}
