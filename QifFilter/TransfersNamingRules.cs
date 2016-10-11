using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QifFilter
{
	[Serializable, XmlRoot("transfers-naming-rules-list")]
	public class TransfersNamingRules
	{
		private List<TransfersInfo> listTransferInfo = null;

		[XmlArray("transfers-info-list")]
		public List<TransfersInfo> ListTransferInfo
		{
			get { return listTransferInfo; }
			set { listTransferInfo = value; }
		}

		public TransfersNamingRules()
		{
			//listTransferInfo = new List<TransfersInfo>();
			//listTransferInfo.Add(new TransfersInfo() { AccountName = "Mercantil", DepositPayee = "Deposito Personal", DestAccountType = DestinationAccountTypes.Cash, Tag = "Alejandro", WithdrawalPayee = "Retiro Personal" });
			//listTransferInfo.Add(new TransfersInfo() { AccountName = "Mercantil", DepositPayee = "Avance Tarjeta", DestAccountType = DestinationAccountTypes.Credit, Tag = "Alejandro", WithdrawalPayee = "Pago Tarjeta" });
		}		
	}
}
