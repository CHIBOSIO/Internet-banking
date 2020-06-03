using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet_banking.Models
{
	public class RicaricheModel
	{
		public int	  id_ricarica  { get; set; }
		public string nr_telefono { get; set; }
		public string oeratore  { get; set; }
		public string IBAN_operatore { get; set; }
		public string data_ricarica { get; set; }
		public double importo { get; set; }
		public string IBAN_conto { get; set; }
		public ContiCorrentiModel conto { get; set; }

	}
}