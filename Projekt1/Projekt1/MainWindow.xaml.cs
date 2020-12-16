using System;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt1 {
    public partial class MainWindow : Window
{
        public IList<Person> pe1 = new List<Person>();
        public string connetionString;
        public SqlConnection cnn;
        public SqlCommand com;
        public SqlDataAdapter adapter;
        public DataSet ds;
        public string sql;
        public MainWindow()
    {
            InitializeComponent();
            connetionString = @"Data Source= DESKTOP-0PKT22P;Initial Catalog=Projekt; User ID=Projekt;Password = 123456789";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 okno = new Window1(this);
            this.Close();
            okno.Show();
            lstBox.ItemsSource = null;
            ds.Tables.Clear();
            pe1.Clear();
            lstBox.ItemsSource = pe1;
        }
    private void Load_Click(object sender, RoutedEventArgs e)
    {
            zal();
            lstBox.ItemsSource = pe1;
        }
    private void zal()
    {
            sql = "Select * FROM Pilkarze";
            com = new SqlCommand(sql, cnn);
            adapter = new SqlDataAdapter(com);
            ds = new DataSet();
            adapter.Fill(ds, "Pilkarze");
            Person pe = new Person();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                pe1.Add(new Person
                {
                    ID = Convert.ToInt32(dr[0].ToString()),
                    Numer = Convert.ToInt32(dr[1].ToString()),
                    Imie = dr[2].ToString(),
                    Nazwisko = dr[3].ToString(),
                    Wiek = Convert.ToInt32(dr[4].ToString()),
                    Pozycja = dr[5].ToString(),
                    Wzrost = Convert.ToInt32(dr[6].ToString()),
                    Poczatek = dr[7].ToString(),
                    Koniec = dr[8].ToString(),
                    Url = dr[9].ToString()
                });
            }
           
    }
        private void More_Click(object sender, RoutedEventArgs e)
        {
            int i = lstBox.SelectedIndex;
            if (i < 0)
            {
                MessageBox.Show("Nie wybrano elementu");
                return;
            }
            else
            {
                Window2 okno2 = new Window2(i, this);
                this.Close();
                okno2.Show();
            }
            lstBox.ItemsSource = null;
            ds.Tables.Clear();
            pe1.Clear();
            lstBox.ItemsSource = pe1;
        }
    }
}