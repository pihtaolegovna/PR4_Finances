using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Appearance;
using System.Linq;
using System;
using System.ComponentModel.Design;
using Wpf.Ui.Mvvm.Interfaces;

namespace PR4_Finances
{
 /// <summary>
 /// Interaction logic for MainWindow.xaml
 /// </summary>
 public partial class MainWindow : Window
    {
	public MainWindow()
        {
            InitializeComponent();
			comboBox.ItemsSource = Type.items;
            Theme.Apply(
            ThemeType.Light,         // Theme type
            BackgroundType.Mica, // Background type
            true                                      // Whether to change accents automatically
            );

            Theme.Apply(
            ThemeType.Dark,         // Theme type
            BackgroundType.None, // Background type
            true                                      // Whether to change accents automatically
            );
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox.Text))
            {
                Type.items.Add(comboBox.Text);
                comboBox.SelectedIndex = Type.items.Count - 1;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox.Text) && comboBox.SelectedIndex >= 0)
            {
                Type.items[comboBox.SelectedIndex] = comboBox.Text;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedIndex >= 0)
            {
                Type.items.RemoveAt(comboBox.SelectedIndex);
            }
        }

		private void Save(object sender, RoutedEventArgs e)
		{
            Finance.DeserializeFinances();
		}

		private void Load(object sender, RoutedEventArgs e)
		{
            Finance.SerializeFinances(Finance.Finances);
		}

		private void ComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedIndex >= 0)
            {
                comboBox.Text = Type.items[comboBox.SelectedIndex];
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (Datepicker.SelectedDate == null) Datepicker.SelectedDate = DateTime.Now;

			Finance.Finances.Add(new Finance(Title.Text, comboBox.Text, NumBox.Value, Datepicker.SelectedDate.Value));
            MessageBox.Show($"{Title.Text}, {comboBox.Text}, {NumBox.Value}, {Datepicker.SelectedDate.Value}");
            PopulateDataGridByDay(Datepicker.SelectedDate.Value);
		}

        private void DeleteButton_Click_1(object sender, RoutedEventArgs e)
        {

        }

		private void PopulateDataGridByDay(DateTime selectedDate)
		{
			var financesByDay = Finance.Finances.Where(f => f.date == selectedDate);
			DataGrid.ItemsSource = financesByDay;
		}

		private void Datepicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(Datepicker.SelectedDate.Value.ToString());
			PopulateDataGridByDay(Datepicker.SelectedDate.Value);
		}
    }
}
