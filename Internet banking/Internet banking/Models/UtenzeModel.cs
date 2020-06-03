using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet_banking.Models
{
	public class UtenzeModel
	{
		public int		id_utenza  { get; set; }
		public string		data_attivazione { get; set; }
		public string	azienda { get; set; }
		public string	IBAN_creditore 	{ get; set; }
		public string	stato 	{ get; set; }
		public string IBAN_conto { get; set; }
	
		public ContiCorrentiModel conto { get; set; }
	
	}
	
}