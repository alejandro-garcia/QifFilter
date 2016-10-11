using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QifFilter
{
	class TransactionItem
	{
		private string date;
		private string amount;
		private string category;
		private string payee;
		private string memo;
		private string otherField;

		public string Date
		{
			get { return date; }
			set { date = value; }
		}

		public string Amount
		{
			get { return amount; }
			set { amount = value; }
		}
		
		public string Category
		{
			get { return category; }
			set { category = value; }
		}
		
		public string Payee
		{
			get { return payee; }
			set { payee = value; }
		}

		public string Memo
		{
			get { return memo; }
			set { memo = value; }
		}

		public string OtherField
		{
			get { return otherField; }
			set { otherField = value; }
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			//date
			stringBuilder.AppendFormat("D{0}", this.date);
			stringBuilder.AppendLine();
			//amount
			stringBuilder.AppendFormat("T{0}", this.amount);
			stringBuilder.AppendLine();
			//category
			stringBuilder.AppendFormat("L{0}", this.category);
			stringBuilder.AppendLine();
			//payee
			stringBuilder.AppendFormat("P{0}", this.payee);
			//memo
			if ((String.IsNullOrEmpty(this.category) && !String.IsNullOrEmpty(this.memo)))
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendFormat("M{0}", this.memo);
			}

			return stringBuilder.ToString();
		}
	}
}
