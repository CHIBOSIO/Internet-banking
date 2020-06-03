using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet_banking.Models
{
	public class BenificiariModel
	{
		public int    id_benificiario  { get; set; }
		public string nome_cliente { get; set; }
		public string cognome_cliente { get; set; }
		public string IBAN_benificiario{ get; set; }
		public string indirizzo { get; set; }
		public string citta { get; set; }
		public int id_banca { get; set; }
		public int id_cliente { get; set; }
		public ClienteModel cliente { get; set; }
		public BancaModel banca { get; set; }
		public List<TrasferimentoModel> lstTrasferimento { get; set; }

	}
}