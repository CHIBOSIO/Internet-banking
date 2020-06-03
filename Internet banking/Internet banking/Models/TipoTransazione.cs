using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet_banking.Models
{
	public class TipoTransazione
	{
		public int id_tipo_transazione { get; set; }
		public string nome  { get; set; }
		public List<TransazioniModel> lstTransazioni { get; set; }
	}
}