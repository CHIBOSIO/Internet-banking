using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Internet_banking
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Servizi e configurazione dell'API Web

			// Route dell'API Web
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				/*Action: specifico il metodo che voglio richiamare*/
				/*id, casa, titolo: campi*/
				//asp net,ogni parametro viene aggiunta una cartella
				routeTemplate: "api/{controller}/{action}/{par1}/{par2}/{par3}/{par4}/{par5}/{par6}/{par7}",//controller:senza nome controller, 
				defaults: new
				{ /*action = RouteParameter.Optional,*/
					par1 = RouteParameter.Optional,
					par2 = RouteParameter.Optional,
					par3 = RouteParameter.Optional,
					par4 = RouteParameter.Optional,
					par5 = RouteParameter.Optional,
					par6 = RouteParameter.Optional,
					par7 = RouteParameter.Optional

				}
					);
		}
	}
}
