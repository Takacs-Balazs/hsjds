using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string kapsolatLeiro = "datasource=127.0.0.0.1;port=3306;username=root;password=;database=termekek;";
        List<Termek> termekek_list = new List<Termek>();
        MySqlConnection SQLkapcsolat;

        public MainWindow()
        {
            InitializeComponent();
            AdatbazisMegnitasa();
            KategoriakBetoltese();
            GyartokBetltese();
            TermekekBetolteseListba();
            AdtbazisLezarasa();
        }
        private void btnMentes_Click(object sender, RoutedEventArgs e) {
            StreamWriter sw = new StreamWriter("blabla.csv");
            foreach (var item in termekek) 
            {
                sw.WriteLine(item.ToCSVString());
            }
            Sw.Close();

        }

        private void TermekekBetolteseListaba()
        {
            string SQLOsszesTermek = "SELECT * FROM termékek";
            MySqlCommand SQLparancs = new MySqlCommand(SQLOsszesTermek, SQLkpcsolat);
            MySqlDataReader eredmenyOlvaso = SQLparancs.ExecuteReader();
            while (eredmenyOlvaso.Read())
            {
                Termek uj = new Termek(eredmenyOlvaso.GetString("Kategória"), (eredmenyOlvaso.GetString("Gyártó"), (eredmenyOlvaso.GetString("Név"), (eredmenyOlvaso.GetString("Ár"), (eredmenyOlvaso.GetString("Garidő"));
                termekek_list.Add(uj);
            }
            eredmenyOlvaso.Close();
            dgTermekek.ItemsSource = termekek_list;
        }
    }
}
