using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QifFilter
{
	[Serializable, XmlRoot("mercantil-rules-list")]
	public class MercantilRules
	{
		private List<MercantilRulesInfo> listaReglas;
		
		[XmlElement("rules")]
		public List<MercantilRulesInfo> ListaReglas
		{
			get { return listaReglas; }
			set { listaReglas = value; }
		}

		public MercantilRules()
		{
			// fill default rules
			listaReglas = new List<MercantilRulesInfo>();
			listaReglas.Add(new MercantilRulesInfo("RETIRO CAJERO", "Retiro Personal", "[Efectivo]"));
			listaReglas.Add(new MercantilRulesInfo("COMISION POR RECEPCION", "Comis. Transferencia", "Bank Charge"));
			listaReglas.Add(new MercantilRulesInfo("PAGO TARJETAS DE CREDITO", "Pago tarjeta", "[Visa Provincial]"));
			listaReglas.Add(new MercantilRulesInfo("RED INTERBANCARIA", "Comis. Cajero", "Bank Charge"));
			listaReglas.Add(new MercantilRulesInfo("PAGO C.A.N.T.V.", "Cantv", "Utilities:Telephone"));
			listaReglas.Add(new MercantilRulesInfo("PAGO LUZ", "Electricidad", "Utilities:Gas & Electric"));
		}



	}
}
