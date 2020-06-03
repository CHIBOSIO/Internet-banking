using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Internet_banking.Models
{
	public class ClienteModel
	{
	public int		id_cliente 				 { get; set; }
	public string	nome_cliente			 { get; set; }
	public string	cognome_cliente 		 { get; set; }
	public string	 data_nascita 			 { get; set; }
	public  string	comune_nascita 			 { get; set; }
	public  string	nazionalita_cliente 	 { get; set; }
	public  string	sesso 					 { get; set; }
	public  string	indirizzo 				 { get; set; }
	public string	comune_residenza			{ get; set; } 
	public  string	codice_fiscale_cliente	 { get; set; }
	public  string	carta_identita 			 { get; set; }
	public  string	num_telefono 			 { get; set; }
	public string	email					 { get; set; }
	public string attivo { get; set; }
		public List<ContiCorrentiModel> lstConti { get; set; }
	public List<BenificiariModel> lstBeneficiari { get; set; }
	public List<PrestitoModel> lstPrestiti { get; set; }

	}
}