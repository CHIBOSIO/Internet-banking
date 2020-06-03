using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet_banking.Models
{
	public class CarteModel
	{
	
		public int id_carta  { get; set; }
		public int cvc { get; set; }
		public string nr_carta 	{ get; set; }
		public string circuito { get; set; }
		public string data_apertura	{ get; set; }
		public string data_scadenza	{ get; set; }
		public double saldo 	{ get; set; }
		public double massimale 	{ get; set; }
			public double saldo_carte { get; set; }
		public string IBAN_conto { get; set; }
		public ContiCorrentiModel conto { get; set; }
	}
}