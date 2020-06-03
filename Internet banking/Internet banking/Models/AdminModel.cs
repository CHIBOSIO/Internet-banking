using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet_banking.Models
{
	public class AdminModel
	{
		public int id_amministratore { get; set; }
		public string username_amministratore { get; set; }
		public string password_amministratore{ get; set; }
		public string nome_amministratore { get; set; }
		public string cognome_amministratore { get; set; }
	}

}