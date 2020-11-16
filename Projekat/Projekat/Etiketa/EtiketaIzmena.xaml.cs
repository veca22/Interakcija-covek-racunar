using System.Windows;
using System.Windows.Media;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Controls;
using Projekat.Model;
using System;

namespace Projekat.Etiketa
{
    /// <summary>
    /// Interaction logic for EtiketaIzmena.xaml
    /// </summary>
    public partial class EtiketaIzmena : Window
    {
        private bool _myTextBoxChanging = false;
        private string oznaka;
        private string opis;
        private string boja;
        private Baza baza;
        private EtiketaKlasa selektovanaEtiketa;
        public int idx = -1;
        public EtiketaKlasa izmenjenaEtiketa;
  
        public string Oznaka
        {
            get
            {
                return oznaka;
            }
            set
            {

                oznaka = value;
                OnPropertyChanged("Oznaka");

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
                opis = value;
                OnPropertyChanged("Opis");
            }
        }

        public string Boja
        {
            get
            {
                return boja;
            }
            set
            {
                if (value != boja)
                {
                    boja = value;
                    OnPropertyChanged("Boja");
                }
            }
        }

       


        private System.Windows.Media.Color mediacolor;
        public System.Windows.Media.Color Mediacolor
        {
            get { return mediacolor; }
            set
            {
                if (value != mediacolor)
                {
                    mediacolor = value;
                    OnPropertyChanged("Mediacolor");
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



        public EtiketaIzmena(EtiketaKlasa et)
        {
            
            baza = new Baza();
            this.DataContext = this;
            selektovanaEtiketa = et;
            Oznaka = et.Oznaka;
            Opis = et.Opis;
            boja = et.Boja;
            InitializeComponent();
            Mediacolor = (Color)System.Windows.Media.ColorConverter.ConvertFromString(et.Boja);
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            cmbColors.SelectedColor = Mediacolor;
            
        }

        
        private void colorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e)
        {
            Mediacolor = cmbColors.SelectedColor.Value;
            boja = cmbColors.SelectedColorText;
            this.Background = new SolidColorBrush(mediacolor);

        }
        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Izmeni(object sender, RoutedEventArgs e)
        {
            if (oznaka_tb.Text == "")
            {
                System.Windows.MessageBox.Show("Niste popunili oznaku !", "Izmena etikete");
                return;
            }
            else if(cmbColors.SelectedColorText == "")
            {
                System.Windows.MessageBox.Show("Niste odabrali boju !", "Izmena etikete");
                return;
            }
            izmenjenaEtiketa = new EtiketaKlasa(oznaka, opis, boja);
            baza.ucitajEtikete();
            idx = 0;

            foreach(EtiketaKlasa et in baza.Etikete)
            {
                if (et.Oznaka == izmenjenaEtiketa.Oznaka)
                    break;
                idx++;
            }

            baza.Etikete[idx] = izmenjenaEtiketa;
            baza.sacuvajEtiketu();

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
