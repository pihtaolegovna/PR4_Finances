using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Animation;
using System.ComponentModel;
using Newtonsoft.Json;
using System.IO;

namespace PR4_Finances
{
    class Type : MainWindow
    {
        public static ObservableCollection<string> items = new ObservableCollection<string>();

        
    }
	public class Finance : MainWindow
	{
		public Finance(string name, string type, double money, DateTime date)
		{
			this.FinanceName = name;
			this.Type = type;
			this.Money = money;
			this.date = date;
		}
		public double Budget { get; set; }
		public string FinanceName { get; set; }
		public string Type { get; set; }
		public double Money { get; set; }
		public DateTime date { get; set; }

		public static ObservableCollection<Finance> Finances = new ObservableCollection<Finance>();

		private static string FilePath = "D://DnoApps/Finances/Finance.json";
		public static void SerializeFinances(Collection<Finance> finances)
		{
			checkFile();

			string financesJson = JsonConvert.SerializeObject(finances);
			File.WriteAllText(FilePath, financesJson);
		}

		public static Collection<Finance> DeserializeFinances()
		{
			checkFile();

			string financesJson = File.ReadAllText(FilePath);
			MessageBox.Show(financesJson);
			Collection<Finance> loadedFinances = JsonConvert.DeserializeObject<Collection<Finance>>(financesJson);
			return loadedFinances;
		}

		private static void checkFile()
		{
			string directoryPath = Path.GetDirectoryName(FilePath);

			// Create the directory if it does not exist
			if (!Directory.Exists(directoryPath))
			{
				Directory.CreateDirectory(directoryPath);
			}

			// Create the file if it does not exist
			if (!File.Exists(FilePath))
			{
				using (StreamWriter sw = File.CreateText(FilePath))
				{
					sw.WriteLine("[]");
				}
			}
		}
	}
}
