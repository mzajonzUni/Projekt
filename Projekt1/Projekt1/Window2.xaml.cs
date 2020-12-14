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
        public int a,o=5;
        private bool error,liczba;
        private string blad;
        public Window2(int i, MainWindow mainWindow)
    {
        mw = mainWindow;
        a = i;
        InitializeComponent();
        //Numer.Text = Convert.ToString(mw.PersonList[i].Numer);
        //Imie.Text = Convert.ToString(mw.PersonList[i].Imie);
        //Nazwisko.Text = Convert.ToString(mw.PersonList[i].Nazwisko);
        //Wiek.Text = Convert.ToString(mw.PersonList[i].Wiek);
        //Pozycja.Text = Convert.ToString(mw.PersonList[i].Pozycja);
        //Wzrost.Text = Convert.ToString(mw.PersonList[i].Wzrost);
        //Poczatek.Text = Convert.ToString(mw.PersonList[i].Poczatek);
        //Koniec.Text = Convert.ToString(mw.PersonList[i].Koniec);
        //    try
        //    {
        //        Uri fileUri = new Uri(mw.PersonList[i].Url);
        //        imgDynamic.Source = new BitmapImage(fileUri);
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Nie znaleziono zdjęcia");
        //    }
    }
        private void Spr()
        {
            if (Numer.Text == null || Imie.Text == "" || Nazwisko.Text == "" || Wiek.Text == null || Pozycja.Text == "" || Wzrost.Text == null || Poczatek.Text == "" || Koniec.Text == "")
            {
                MessageBox.Show("Puste pole");
                error = true;
                return;
            }
            string numString = Numer.Text;
            int number = 0;
            bool canConvert = int.TryParse(numString, out number);
            if (canConvert != true)
            {
                error = true;
                blad += "Bledny numer" + "\r\n";
            }
            string numString1 = Wiek.Text;
            int number1 = 0;
            bool canConvert1 = int.TryParse(numString1, out number1);
            if (canConvert1 != true)
            {
                blad += "Błędny Wiek" + "\r\n";
                error = true;
            }
            string numString2 = Wzrost.Text;
            int number2 = 0;
            bool canConvert2 = int.TryParse(numString2, out number2);
            if (canConvert2 != true)
            {
                blad += "Błędny Wzrost" + "\r\n";
                error = true;
            }
            string numString3 = Poczatek.Text;
            int number3 = 0;
            bool canConvert3 = int.TryParse(numString3, out number3);
            if (canConvert3 != true)
            {

                blad += "Błędny początek" + "\r\n";
                error = true;
            }
            Sprawdz(Imie);
            Sprawdz(Nazwisko);
            Sprawdz(Pozycja);
            if (imgDynamic.Source == null)
            {
                blad += "Nie dodano zdjecia" + "\r\n";
                error = true;
            }
        }
        private void Sprawdz(TextBox x)
        {
            liczba = false;
            string slowo = x.Text;
            for (int i = 0; i != slowo.Length; i++)
            {
                char z = slowo[i];
                if (((z >= 'a') && (z <= 'z')) || ((z >= 'A') && (z <= 'Z')))
                {

                }
                else
                {
                    liczba = true;
                }
            }
            if (liczba == true)
            {
                blad += x.Name + " zawiera liczbe" + "\r\n";
                o++;
                error = true;
            }

        }
        private void Edit_Click(object sender, RoutedEventArgs e)
    {
            Spr();
            if (error)
            {
                MessageBox.Show(blad);
                error = false;
                blad = "";
                return;
            }
        //mw.PersonList[a].Numer = Convert.ToInt32(Numer.Text);
        //mw.PersonList[a].Imie = Convert.ToString(Imie.Text);
        //mw.PersonList[a].Nazwisko = Convert.ToString(Nazwisko.Text);
        //mw.PersonList[a].Wiek = Convert.ToInt32(Wiek.Text);
        //mw.PersonList[a].Pozycja = Convert.ToString(Pozycja.Text);
        //mw.PersonList[a].Wzrost = Convert.ToInt32(Wzrost.Text);
        //mw.PersonList[a].Poczatek = Convert.ToString(Poczatek.Text);
        //mw.PersonList[a].Koniec = Convert.ToString(Poczatek.Text);
        //mw.PersonList[a].Url = Convert.ToString(imgDynamic.Source);
        //mw.MainList.ItemsSource = null;
        //mw.MainList.ItemsSource = mw.PersonList;
        //this.Close();
        //MessageBox.Show("Zapisano pomyślnie");
    }
    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        //mw.PersonList.RemoveAt(mw.MainList.SelectedIndex);
        //    this.Close();
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
