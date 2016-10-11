using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QifFilter
{
	[Serializable]
	[XmlRoot("rule-info")]
	public class MercantilRulesInfo
	{
		private string sourceText;
		private string payee;
		private string category;

		[XmlAttribute("source-text")]
		public string SourceText
		{
			get { return sourceText; }
			set { sourceText = value; }
		}

		[XmlAttribute("payee")]
		public string Payee
		{
			get { return payee; }
			set { payee = value; }
		}

		[XmlAttribute("category")]
		public string Category
		{
			get { return category; }
			set { category = value; }
		}

		public MercantilRulesInfo(string source, string payee, string category)
		{
			this.sourceText = source;
			this.payee = payee;
			this.category = category;
		}

		public MercantilRulesInfo()
		{

		}
	}
}
