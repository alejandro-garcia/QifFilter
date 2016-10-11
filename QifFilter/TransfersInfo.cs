using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QifFilter
{
	[Serializable]
	[XmlRoot("transfers-info")]
	public class TransfersInfo
	{
		private string tag;
		private string withdrawalPayee;
		private string depositPayee;
		private DestinationAccountTypes destAccountType;
		private string accountName;

		[XmlElement("account-name")]
		public string AccountName
		{
			get { return accountName; }
			set { accountName = value; }
		}

		[XmlElement("destination-account-type")]
		public DestinationAccountTypes DestAccountType
		{
			get { return destAccountType; }
			set { destAccountType = value; }
		}

		[XmlElement("tag")]
		public string Tag
		{
			get { return tag; }
			set { tag = value; }
		}

		[XmlElement("withdrawal-payee")]
		public string WithdrawalPayee
		{
			get { return withdrawalPayee; }
			set { withdrawalPayee = value; }
		}

		[XmlElement("deposit-payee")]
		public string DepositPayee
		{
			get { return depositPayee; }
			set { depositPayee = value; }
		}

		public TransfersInfo()
		{

		}
	}

	public enum DestinationAccountTypes
	{
		Cash,
		Credit,
		Bank
	}; 

}
