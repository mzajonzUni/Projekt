using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.IO;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Projekt1
{
    public partial class Window2 : Window 
    {

        private MainWindow mw;
        public int a;
    public Window2(int i, MainWindow mainWindow)
    {
        mw = mainWindow;
        a = i;
        InitializeComponent();
        Numer.Text = Convert.ToString(mw.PersonList[i].Numer);
        Imie.Text = Convert.ToString(mw.PersonList[i].Imie);
        Nazwisko.Text = Convert.ToString(mw.PersonList[i].Nazwisko);
        Wiek.Text = Convert.ToString(mw.PersonList[i].Wiek);
        Pozycja.Text = Convert.ToString(mw.PersonList[i].Pozycja);
        Wzrost.Text = Convert.ToString(mw.PersonList[i].Wzrost);
        Poczatek.Text = Convert.ToString(mw.PersonList[i].Poczatek);
        Koniec.Text = Convert.ToString(mw.PersonList[i].Koniec);
            try
            {
                Uri fileUri = new Uri(mw.PersonList[i].Url);
                imgDynamic.Source = new BitmapImage(fileUri);
            }
            catch
            {
                MessageBox.Show("Nie znaleziono zdjęcia");
            }
    }

    private void Edit_Click(object sender, RoutedEventArgs e)
    {
        mw.PersonList[a].Numer = Convert.ToInt32(Numer.Text);
        mw.PersonList[a].Imie = Convert.ToString(Imie.Text);
        mw.PersonList[a].Nazwisko = Convert.ToString(Nazwisko.Text);
        mw.PersonList[a].Wiek = Convert.ToInt32(Wiek.Text);
        mw.PersonList[a].Pozycja = Convert.ToString(Pozycja.Text);
        mw.PersonList[a].Wzrost = Convert.ToInt32(Wzrost.Text);
        mw.PersonList[a].Poczatek = Convert.ToString(Poczatek.Text);
        mw.PersonList[a].Koniec = Convert.ToString(Poczatek.Text);
        mw.PersonList[a].Url = Convert.ToString(imgDynamic.Source);
        mw.MainList.ItemsSource = null;
        mw.MainList.ItemsSource = mw.PersonList;
        this.Close();
        MessageBox.Show("Edytowano pomyślnie");
    }
    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        mw.PersonList.RemoveAt(mw.MainList.SelectedIndex);
            this.Close();
    }
        private void Photo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                imgDynamic.Source = new BitmapImage(fileUri);
            }
        }
    }
}
