using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet_banking.Models
{
	public class AssegniModel
	{
		public int id_carnet { get; set; }
		public string IBAN_conto { get; set; }
		public string data_emissione { get; set; }
		public ContiCorrentiModel conto { get; set;}
	}
}