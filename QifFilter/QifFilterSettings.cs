using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

namespace QifFilter
{
	[Serializable]
	[XmlRoot("Qif-filter-settings")]
	public class QifFilterSettings
	{
		private bool completeTransfersInfo = true;
		private TransfersNamingRules tranfersRules;
		
		private static QifFilterSettings current = null;

		public static QifFilterSettings GetCurrent()
		{
			if (current == null)
			{

				string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "QifFilterSettings.xml");

				bool wasDeserialized = true;

				try
				{
					if (File.Exists(filePath))
					{
						XmlSerializer serializer = new XmlSerializer(typeof(QifFilterSettings));
						using (FileStream stream = new FileStream(filePath, FileMode.Open))
						{
							current = (QifFilterSettings)serializer.Deserialize(stream);
						}
					}
					else
					{
						wasDeserialized = false;
					}
				}
				catch
				{
					wasDeserialized = false;
				}
				finally
				{
					if (!wasDeserialized)
						current = new QifFilterSettings();
				}
			}

			return current;
		}

		[XmlElement("complete-transfers-info")]
		public bool CompleteTransfersInfo
		{
			get { return completeTransfersInfo; }
			set { completeTransfersInfo = value; }
		}

		[XmlElement("tranfers-rules")]
		public TransfersNamingRules TranfersRules
		{
			get { return tranfersRules; }
			set { tranfersRules = value; }
		}

		public QifFilterSettings()
		{
			tranfersRules = new TransfersNamingRules();
		}
	}
}
