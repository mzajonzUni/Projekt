﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Projekt1
{
    public partial class Window1 : Window
    {
        private MainWindow mOkno = new MainWindow();
        private MainWindow mw;
        private bool liczba;
        public Window1(MainWindow mainwindow)
        {
            mw = mainwindow;
            InitializeComponent();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            //if (Numer.Text == null || Imie.Text == "" || Nazwisko.Text == "" || Wiek.Text == null || Pozycja.Text == "" || Wzrost.Text == null || Poczatek.Text == "" || Koniec.Text == "")
            //{
            //    MessageBox.Show("Puste pole");
            //    return;
            //}
            //string numString = Numer.Text;
            //int number = 0;
            //bool canConvert = int.TryParse(numString, out number);
            //if (canConvert != true)
            //{
            //    MessageBox.Show("Błędny Numer");
            //    return;
            //}
            //string numString1 = Wiek.Text;
            //int number1 = 0;
            //bool canConvert1 = int.TryParse(numString1, out number1);
            //if (canConvert1 != true)
            //{
            //    MessageBox.Show("Błędny Wiek");
            //    return;
            //}
            //string numString2 = Wzrost.Text;
            //int number2 = 0;
            //bool canConvert2 = int.TryParse(numString2, out number2);
            //if (canConvert2 != true)
            //{
            //    MessageBox.Show("Błędny Wzrost");
            //    return;
            //}
            //string numString3 = Poczatek.Text;
            //int number3 = 0;
            //bool canConvert3 = int.TryParse(numString3, out number3);
            //if (canConvert3 != true)
            //{
            //    MessageBox.Show("Błędny początek");
            //    return;
            //}
            //Sprawdz(Imie);
            //if (liczba == true)
            //    return;
            //Sprawdz(Nazwisko);
            //if (liczba == true)
            //    return;
            //Sprawdz(Pozycja);
            //if (liczba == true)
            //    return;
            //if (imgDynamic.Source == null)
            //{
            //    MessageBox.Show("Nie dodano zdjecia");
            //    return;
            //}
            //mw.PersonList.Add(new Person(Convert.ToInt32(Numer.Text), Convert.ToString(Imie.Text), Convert.ToString(Nazwisko.Text), Convert.ToInt32(Wiek.Text), Convert.ToString(Pozycja.Text), Convert.ToInt32(Wzrost.Text), Convert.ToString(Poczatek.Text), Convert.ToString(Koniec.Text), Convert.ToString(imgDynamic.Source)));
            //mw.MainList.ItemsSource = mw.PersonList;
            //this.Close();
            mw.sql = "Insert into Pilkarze(Numer,Imie,Nazwisko,Wiek,Pozycja,Wzrost,Poczatek,Koniec,Zdjecie) VALUES('" + Numer.Text + "','" + Imie.Text + "','" + Nazwisko.Text + "','" + Wiek.Text + "','" + Pozycja.Text + "','" + Wzrost.Text + "','" + Poczatek.Text + "','" + Koniec.Text + "','" + imgDynamic.Source.ToString() + "')";
            mw.com = new System.Data.SqlClient.SqlCommand(mw.sql, mw.cnn);
            mw.adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand(mw.sql, mw.cnn);
            mw.adapter.UpdateCommand.ExecuteNonQuery();
            mOkno.Show();
            this.Close();

        }
        private void Sprawdz(TextBox x)
        {
            liczba = false;
            string slowo = x.Text;
            for(int i = 0; i != slowo.Length; i++)
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
            if(liczba == true)
            {
                MessageBox.Show(x.Name + " zawiera liczbe");
            }

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
