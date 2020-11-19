    using System.Windows;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System;
    using System.Collections.Generic;
    using System.Windows.Controls;
    using System.Collections.ObjectModel;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;

    namespace Projekt1
    {
        public partial class MainWindow : Window
        {
            public ObservableCollection<Person> PersonList = new ObservableCollection<Person>();
            public MainWindow()
            {
                InitializeComponent();
                Load();
            }

            //private void Button_Click(object sender, RoutedEventArgs e)
            //{
            //    Window1 okno = new Window1(this);
            //    okno.Show();
            //}

            private void Save_Click(object sender, RoutedEventArgs e)
            {
                XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Person>));
                using (StreamWriter wr = new StreamWriter("../ListaOsob.xml"))
                {
                    xs.Serialize(wr, PersonList);
                }
                MessageBox.Show("Zapisano pomyślnie");
            }
            private void Load_Click(object sender, RoutedEventArgs e)
            {
                XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Person>));
                using (StreamReader rd = new StreamReader("../ListaOsob.xml"))
                {
                    PersonList = xs.Deserialize(rd) as ObservableCollection<Person>;
                }
                MainList.ItemsSource = null;
                MainList.ItemsSource = PersonList;
                MessageBox.Show("Załadowano pomyślnie");
            }
            private void Load()
            {
                XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Person>));
                using (StreamReader rd = new StreamReader("../ListaOsob.xml"))
                {
                    PersonList = xs.Deserialize(rd) as ObservableCollection<Person>;
                }
                MainList.ItemsSource = null;
                MainList.ItemsSource = PersonList;
            }
            //private void More_Click(object sender, MouseButtonEventArgs e)
            //{
            //    int i = MainList.SelectedIndex;
            //    MessageBox.Show(Convert.ToString(i));
            //    //Window2 okno2 = new Window2(i, this);
            //    //okno2.Show();
            //}
        }
    }
}
