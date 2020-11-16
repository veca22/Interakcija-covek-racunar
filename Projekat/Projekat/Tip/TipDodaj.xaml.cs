using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using Microsoft.Win32;
using Projekat.Model;

namespace Projekat.Tip
{
    /// <summary>
    /// Interaction logic for TipDodaj.xaml
    /// </summary>
    public partial class TipDodaj : Window
    {
        private bool _myTextBoxChanging = false;
        private string oznaka;
        private string naziv;
        private string opis;
        private string slika = null;
        private Baza baza;

        public string Oznaka
        {
            get
            {
                return oznaka;
            }
            set
            {
                if (value != oznaka)
                {
                    oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

        public string Naziv
        {
            get
            {
                return naziv;
            }
            set
            {
                if (value != naziv)
                {
                    naziv = value;
                    OnPropertyChanged("Naziv");
                }
            }
        }

        public string Opis
        {
            get
            {
                return opis;
            }
            set
            {
                if (value != opis)
                {
                    opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }

        public string Slika
        {
            get { return slika; }
            set { slika = value; }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        public TipDodaj()
        {
            baza = new Baza();
            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void DodavanjeIkonice(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();


            fileDialog.Title = "Izaberi ikonicu";
            fileDialog.Filter = "Images|*.jpg;*.jpeg;*.png|" +
                                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                                "Portable Network Graphic (*.png)|*.png";
            if (fileDialog.ShowDialog() == true)
            {
                ikonica.Source = new BitmapImage(new Uri(fileDialog.FileName));
                slika = fileDialog.FileName;
            }
        }
        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            if (oznaka_tb.Text == "")
            {
                System.Windows.MessageBox.Show("Niste popunili oznaku!", "Dodavanje tipa");
                return;
            }
            else if(naziv_tb.Text == "")
            {
                System.Windows.MessageBox.Show("Niste popunili naziv!", "Dodavanje tipa");
                return;
            }
            else if(Slika == null)
            {
                System.Windows.MessageBox.Show("Niste odabrali sliku!", "Dodavanje tipa");
                return;
            }

                TipKlasa tp = new TipKlasa(oznaka, naziv, opis, slika);
                bool tip = baza.addTip(tp);
                if (tip)
                {
                    baza.sacuvajTip();
                    baza.ucitajTipove();
                    if(pocetniTip.Instance != null)
                         pocetniTip.Instance.PuniTip(tp);


                    MainWindow.Instance.tipovi.Add(tp);
                    MainWindow.Instance.tree.Items.Refresh();
                  

                    this.Close();
                }
                else
                {
                    System.Windows.MessageBox.Show("Tip sa ovom oznakom već postoji!", "Greška!");
                }
            
        }



        private void OznakaTB_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.A && e.Key <= Key.Z) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || (e.Key >= Key.D0 && e.Key <= Key.D9) || e.Key == Key.Tab)
            {
            }
            else
            {
                e.Handled = true;
            }
        }
    }

}
