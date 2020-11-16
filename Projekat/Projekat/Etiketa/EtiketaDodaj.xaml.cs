using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Projekat.Model;

namespace Projekat.Etiketa
{
    /// <summary>
    /// Interaction logic for EtiketaDodaj.xaml
    /// </summary>
    public partial class EtiketaDodaj : Window
    {

        private static EtiketaDodaj instance;
        private string oznaka;
        private string opis;
        private bool _myTextBoxChanging = false;
        private string boja;

        public static EtiketaDodaj Instance
        {
            get { return instance; }
        }
        

        public string Oznaka
        {
            get
            {
                return oznaka;
            }
            set
            {
           
               oznaka = value;

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

                boja = value;
               
            }
        }

        private Baza baza;

        public EtiketaDodaj()
        {
            instance = this;
            baza = new Baza();
            InitializeComponent();
        
            this.DataContext = this;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }


        private void Dodaj(object sender, RoutedEventArgs e)
        {
            if(oznaka_tb.Text == "")
            {
                System.Windows.MessageBox.Show("Niste popunili oznaku!", "Izmena podataka o etiketi");
                return;
            }
            else if (cmbColors.SelectedColorText == "")
            {
                System.Windows.MessageBox.Show("Niste odabrali boju!", "Izmena podataka o etiketi");
                return;
            }
            EtiketaKlasa et = new EtiketaKlasa(oznaka, opis, boja);
            Console.WriteLine(boja + "\n\n");
            bool etiketa = baza.addEtiketa(et);
            if(etiketa)
            {
                //System.Windows.MessageBox.Show("Uspešno dodavanje nove etikete.", "Uspeh!");
                baza.sacuvajEtiketu();
                if (pocetniEtiketa.Instanca != null)
                {
                    pocetniEtiketa.Instanca.puniEtikete(et);
                    //pocetniEtiketa.Instanca.TabelaEtiketa.Items.Refresh();
                    //pocetniEtiketa.Instanca.TabelaEtiketa.UpdateLayout();
                    //pocetniEtiketa.Instanca.UpdateLayout();
                }
                this.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Vec postoji etiketa sa tom oznakom!", "Greska!");
            }
        }

     
        private void colorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e)
        {
            System.Windows.Media.Color mediacolor = cmbColors.SelectedColor.Value;
            boja = cmbColors.SelectedColorText;
            this.Background = new SolidColorBrush(mediacolor);

        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
      

        private void OznakaTB_KeyDown(object sender, KeyEventArgs e)
        {
            
            if ((e.Key >= Key.A && e.Key <= Key.Z) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || (e.Key >= Key.D0 && e.Key <= Key.D9) || e.Key == Key.Tab)
            {
            }
            else if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
