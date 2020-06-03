using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet_banking.Models
{
	public class AccountModel
	{
	
		public int username_cliente { get; set; }
		public string password_cliente { get; set; }
		public string data_attivazione { get; set; }
		public string primo_accesso { get; set; }
		public int id_cliente { get; set; }		
		public int id_amministratore { get; set; }
		public AdminModel amministratore { get; set; }
		public ClienteModel cliente { get; set; }
	}
}