using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet_banking.Models
{
	public class BancaModel
	{
		public int id_banca { get; set; }
		public string  nome_banca { get; set; }
		public string  nazionalita_banca { get; set; }
		public List<BenificiariModel> lstBeneficiari { get; set; }
	}
}