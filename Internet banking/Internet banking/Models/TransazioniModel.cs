using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet_banking.Models
{
	public class TransazioniModel
	{
		public int id_transazione { get; set; }
		public string IBAN_mittente { get; set; }
		public string IBAN_creditore { get; set; }
		public string controparte { get; set; }
		public string data_transazione { get; set; }
		public string entrata_uscita { get; set; }
		public string stato  { get; set; }
		public double importo { get; set; }
		public int id_tipo_transazione { get; set; }
		public string IBAN_conto { get; set; }
		public ContiCorrentiModel conto { get; set; }
	
		public TipoTransazione tipoTran { get; set; }


	}
}