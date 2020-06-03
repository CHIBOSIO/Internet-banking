using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet_banking.Models
{
	public class ContiCorrentiModel
	{
	
		public string IBAN_conto { get; set; }
		public string data_apertura{ get; set; }
		public double saldo_conto { get; set; }
		public int id_cliente { get; set; }
		public ClienteModel cliente { get; set; }
		public List<UtenzeModel> lstUtente { get; set; }
		public List<InvestimentiModel> lstInvestimenti { get; set; }
		public List<TransazioniModel> lstTransazioni { get; set; }
		public List<AssegniModel> lstAssegni { get; set; }
		public List<RicaricheModel> lstRicariche { get; set; }
		public List<CarteModel> lstCarte { get; set; }
		public List<TrasferimentoModel> lstTrasferimento { get; set; }

		public double saldo_iban { get; set; }

	}
}