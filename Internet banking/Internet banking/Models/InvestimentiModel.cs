using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet_banking.Models
{
	public class InvestimentiModel
	{
		public int id_operazione { get; set; }
		public int quantita   { get; set; }
		public string titolo { get; set; }
		public string data_investimento { get; set; }
		public double prezzo  { get; set; }
		public string IBAN_conto { get; set; }
		public ContiCorrentiModel conto { get; set; }
	}
}