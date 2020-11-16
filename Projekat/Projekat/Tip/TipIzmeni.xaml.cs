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
    /// Interaction logic for TipIzmeni.xaml
    /// </summary>
    public partial class TipIzmeni : Window
    {
        private bool _myTextBoxChanging = false;

        private string oznaka;
        private string naziv;
        private string slika = null;
        private string opis;
        private Baza baza;
        private TipKlasa selektovanTip;
        public int idx = -1;
        public TipKlasa izmenjenTip;


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
        

        public string Slika
        {
            get { return slika; }
            set
            {
                if (value != slika)
                {
                    slika = value;
                    OnPropertyChanged("Slika");
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


        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


            public TipIzmeni(TipKlasa tp)
            {

                baza = new Baza();
                InitializeComponent();  
                 this.DataContext = this;
                selektovanTip = tp;
                Opis = tp.Opis;
                Naziv = tp.Naziv;
                Oznaka = tp.Oznaka;
                Slika = tp.Slika;
                ikonica.Source = new BitmapImage(new Uri(tp.Slika));
                InitializeComponent();
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
        private void Izmeni(object sender, RoutedEventArgs e)
        {
            if (oznaka_tb.Text == "")
            {
                System.Windows.MessageBox.Show("Niste popunili oznaku!", "Dodavanje tipa");
                return;
            }
            else if (naziv_tb.Text == "")
            {
                System.Windows.MessageBox.Show("Niste popunili naziv!", "Dodavanje tipa");
                return;
            }
            else if (Slika == null)
            {
                System.Windows.MessageBox.Show("Niste odabrali sliku!", "Dodavanje tipa");
                return;
            }
            izmenjenTip = new TipKlasa(oznaka, naziv, opis, slika);
            baza.ucitajTipove();
            idx = 0;
            foreach(TipKlasa tp in baza.Tipovi)
            {
                if (tp.Oznaka == izmenjenTip.Oznaka)
                    break;
                idx++;
            }
            baza.Tipovi[idx] = izmenjenTip;
            baza.sacuvajTip();
            this.Close();
        }

        private void Brojevi(object sender, TextChangedEventArgs e)
        {

            validateText(oznaka_tb);
        }

        private void validateText(TextBox box)
        {
            if (_myTextBoxChanging)
                return;
            _myTextBoxChanging = true;

            string text = box.Text;
            if (text == "")
                return;
            string validText = "";
            int pos = box.SelectionStart;
            for (int i = 0; i < text.Length; i++)
            {
                char s = text[i];
                if (s < '0' || s > '9')
                {
                    if (i <= pos)
                        pos--;
                }
                else
                    validText += s;
            }

            // trim starting 00s 
            while (validText.Length >= 2 && validText.StartsWith("00"))
            {
                validText = validText.Substring(1);
                if (pos < 2)
                    pos--;
            }

            if (pos > validText.Length)
                pos = validText.Length;
            box.Text = validText;
            box.SelectionStart = pos;
            _myTextBoxChanging = false;
        }

    }
}
