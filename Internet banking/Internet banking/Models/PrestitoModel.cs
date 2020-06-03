using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet_banking.Models
{
	public class PrestitoModel
	{
		public int    id_prestito { get; set; }
		public double importo { get; set; }
		public string data_emissione  { get; set; }
		public string data_termine { get; set; }
		public double tasso { get; set; }
		public int mensilita  	 { get; set; }
		public double rata	 { get; set; }
		public string tipo_prestito { get; set; }
		public string stato 	{ get; set; }
		public double importo_restituito { get; set; }
		public int id_cliente { get; set; }
		public ClienteModel cliente { get; set; }
		



	}
}