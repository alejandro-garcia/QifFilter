using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace QifFilter
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


						if (!File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "MercantilRules.xml")))
						{
							MercantilRules mercantilRules = new MercantilRules();

							XmlSerializer mySerializer = new XmlSerializer(typeof(MercantilRules));
							// To write to a file, create a StreamWriter object.
							StreamWriter myWriter = new StreamWriter("MercantilRules.xml");
							mySerializer.Serialize(myWriter, mercantilRules);
							myWriter.Close();
						}

						if (!File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "QifFilterSettings.xml")))
					  {
							QifFilterSettings settings = new QifFilterSettings();
							XmlSerializer mySerializer = new XmlSerializer(typeof(QifFilterSettings));

							StreamWriter myWriter = new StreamWriter("QifFilterSettings.xml");
							mySerializer.Serialize(myWriter, settings);
							myWriter.Close();
						}

            Application.Run(new frmMenu());
            //Application.Run(new frmQifFilter());
            //Application.Run(new frmTestFormat());
        }
    }
}
