using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Collections;
namespace Homework11__
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Database Db;
        Consultant Cons;
        Manager Manag;
        public User CurrentUser;
        public ObservableCollection<Client> TDb { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Db = new Database("Database.txt");
            Cons = new Consultant(ref Db);
            Manag = new Manager(ref Db);
            ComboCurrentUser.Items.Add("Консультант");
            ComboCurrentUser.Items.Add("Менеджер");

            DbViewGrid.SelectionMode = DataGridSelectionMode.Single;
            DbViewGrid.SelectionUnit = DataGridSelectionUnit.Cell;
        }

        private void ComboCurrentUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            switch (ComboCurrentUser.SelectedItem.ToString())
            {
                case "Консультант":
                    Db.Save();
                    CurrentUser = Cons;
                    CurrentUser.Refresh();
                    DbViewGrid.AutoGenerateColumns = false;

                    DbViewGrid.ItemsSource = CurrentUser.Clients; //установка источника данных
                    AddRecordBorder.IsEnabled = false;

                    break;
                case "Менеджер":
                    Db.Save();
                    CurrentUser = Manag;
                    CurrentUser.Refresh();
                    DbViewGrid.ItemsSource = CurrentUser.Clients; //установка источника данных
                    AddRecordBorder.IsEnabled = true;
                    break;
                default:
                    return;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser is Manager)
            {
                Manag.AddClient(NameTextBox.Text, SurnameTextBox.Text, PatronymicTextBox.Text,
                    PhoneNumberTextBox.Text, PassportTextBox.Text);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Записываем Db в файл
            Db.Save();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

            DbViewGrid.Columns[6].Visibility = Visibility.Visible;
            DbViewGrid.Columns[7].Visibility = Visibility.Visible;
            DbViewGrid.Columns[8].Visibility = Visibility.Visible;
            DbViewGrid.Columns[9].Visibility = Visibility.Visible;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            DbViewGrid.Columns[6].Visibility = Visibility.Hidden;
            DbViewGrid.Columns[7].Visibility = Visibility.Hidden;
            DbViewGrid.Columns[8].Visibility = Visibility.Hidden;
            DbViewGrid.Columns[9].Visibility = Visibility.Hidden;
        }
    }
}
