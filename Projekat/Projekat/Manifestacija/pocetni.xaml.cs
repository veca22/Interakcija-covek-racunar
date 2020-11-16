using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Projekat.Model;

namespace Projekat.Manifestacija
{
    /// <summary>
    /// Interaction logic for pocetni.xaml
    /// </summary>
    public partial class pocetni : Window
    {
        private static pocetni instanca;
        private Baza baza;
        private ObservableCollection<ManifestacijaKlasa> mpom;
        public int idx = -1;
        public ManifestacijaKlasa izmenjena;


        public ObservableCollection<ManifestacijaKlasa> Mpom
        {
            get { return mpom; }
            set { mpom = value; }
        }

        public static pocetni Instanca
        {
            get { return instanca; }
        }

        public void puniManif(ManifestacijaKlasa m1)
        {
            Mpom.Add(m1);
            TabelaManifestacija.Items.Refresh();
        }
       

        public pocetni()
        {
            instanca = this;
            Mpom = new ObservableCollection<ManifestacijaKlasa>();
            baza = new Baza();
            baza.ucitajManifestacije();
            mpom = baza.Manifestacije;
            this.DataContext = this;
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void DodajManifestaciju(object sender, RoutedEventArgs e)
        {
            var s = new Projekat.Manifestacija.ManifestacijaDodaj();
            s.ShowDialog();
        }

        private void IzmeniManifestaciju(object sender, RoutedEventArgs e)
        {
            if (TabelaManifestacija.SelectedValue is ManifestacijaKlasa)
            {
                ManifestacijaKlasa m = (ManifestacijaKlasa)TabelaManifestacija.SelectedValue;


                var s = new ManifestacijaIzmena(m);
                s.ShowDialog();
                if (s.idx != -1)
                {
                    baza.Manifestacije[s.idx] = s.Izmenjena;
                    baza.sacuvajManifestaciju();
                    baza.ucitajManifestacije();
                    Mpom = baza.Manifestacije;
                    idx = s.idx;
                    izmenjena = s.Izmenjena;

                }
            }
            else
            {
                System.Windows.MessageBox.Show("Niste odabrali manifestaciju za izmenu podataka.", "Izmena manifestacije");

            }
        }
        private void ObrisiManifestaciju(object sender, RoutedEventArgs e)
        {
            ManifestacijaKlasa m = null;
            if (TabelaManifestacija.SelectedValue is ManifestacijaKlasa)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Da li ste sigurni da želite da obrišete manifestaciju?", "Brisanje manifestacije", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        m = (ManifestacijaKlasa)TabelaManifestacija.SelectedValue;
                        baza.brisanjeManifestacije(m);
                        MainWindow.Instance.izbrisiManf(m);
                        Mpom = baza.Manifestacije;                      
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }


            }
            else
            {
                System.Windows.MessageBox.Show("Niste odabrali manifestaciju za brisanje!", "Brisanje manifestacije");

            }
        }

        private void Okej(object sender, RoutedEventArgs e)
        {

            MainWindow.Instance.tree.Items.Refresh();
            this.Close();
        }

        private void pretraga_po_oznaci(object sender, TextChangedEventArgs e)
        {
            System.Windows.Controls.TextBox textbox = sender as System.Windows.Controls.TextBox;
            string filter = textbox.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(mpom);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    ManifestacijaKlasa man = o as ManifestacijaKlasa;
                    string[] words = filter.Split(' ');
                    if (words.Contains(""))
                        words = words.Where(word => word != "").ToArray();
                    return words.Any(word => man.Oznaka.ToUpper().Contains(word.ToUpper()));
                };

                TabelaManifestacija.ItemsSource = mpom;
            }
        }

    }

    
}
