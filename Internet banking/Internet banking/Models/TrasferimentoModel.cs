using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet_banking.Models
{
	public class TrasferimentoModel
	{

		public int   id_trasferimento  { get; set; }
		public double importo  { get; set; }
		public string data_trasferimento { get; set; }
		public string IBAN_destinatario { get; set; }
		public string causale { get; set; }
		public string IBAN_conto  { get; set; }
		
	
		public int id_benificiario { get; set; }
		public ContiCorrentiModel conto { get; set; }
	
		 public BenificiariModel beneficiario { get; set; }

	}
}