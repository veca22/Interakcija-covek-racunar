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

namespace Projekat.Etiketa
{
    /// <summary>
    /// Interaction logic for pocetniEtiketa.xaml
    /// </summary>
    public partial class pocetniEtiketa : Window
    {
       
        private static pocetniEtiketa instanca;
        private ObservableCollection<EtiketaKlasa> etikete;
        private Baza baza;
      

        public static pocetniEtiketa Instanca
        {
            get { return instanca; }
        }

        public ObservableCollection<EtiketaKlasa> Etikete
        {
            get { return etikete; }
            set
            {
                if (etikete != value)
                {
                    etikete = value;
                    OnPropertyChanged("Etikete");
                }

            }
        }
      

        public pocetniEtiketa()
        {
           
            baza = new Baza();
            baza.ucitajEtikete();
            Etikete = baza.Etikete;
            this.DataContext = this;
            instanca = this;
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            
           
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public void puniEtikete(EtiketaKlasa et)
        {
            Etikete.Add(et);        
            TabelaEtiketa.Items.Refresh();
            this.UpdateLayout();
            this.TabelaEtiketa.UpdateLayout();
            
        }

        private void DodajEtiketu(object sender, RoutedEventArgs e)
        {
            var s = new Projekat.Etiketa.EtiketaDodaj();
            s.Show();
        }

        private void IzmeniEtiketu(object sender, RoutedEventArgs e)
        {
            EtiketaKlasa et;

            if(TabelaEtiketa.SelectedValue is EtiketaKlasa)
            {
                et = (EtiketaKlasa)TabelaEtiketa.SelectedValue;

                var s = new EtiketaIzmena(et);
                s.ShowDialog();
                baza.ucitajEtikete();
                Etikete = baza.Etikete;
                if(s.idx != -1)
                {
                    baza.Etikete[s.idx] = s.izmenjenaEtiketa;
                    baza.sacuvajEtiketu();
                    Etikete = baza.Etikete;
                }

                TabelaEtiketa.ItemsSource = null;
                baza.ucitajEtikete();
                Etikete = baza.Etikete;
                TabelaEtiketa.ItemsSource = Etikete;
            }
            else
            {
                System.Windows.MessageBox.Show("Niste odabrali nijednu etiketu za izmenu.", "Izmena etikete");
            }

           
        }

        private void Okej(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Obrisi(object sender, RoutedEventArgs e)
        {
            
            EtiketaKlasa m = null;
            if(TabelaEtiketa.SelectedValue is EtiketaKlasa)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Da li ste sigurni da želite da obrišete etiketu?", "Brisanje etikete", MessageBoxButton.YesNo);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        m = (EtiketaKlasa)TabelaEtiketa.SelectedValue;
                        baza.brisanjeEtikete(m);
                                      
                        Etikete = baza.Etikete;
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

        private void pretraga_po_oznaci(object sender, TextChangedEventArgs e)
        {
            System.Windows.Controls.TextBox textbox = sender as System.Windows.Controls.TextBox;
            string filter = textbox.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(etikete);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    EtiketaKlasa man = o as EtiketaKlasa;
                    string[] words = filter.Split(' ');
                    if (words.Contains(""))
                        words = words.Where(word => word != "").ToArray();
                    return words.Any(word => man.Oznaka.ToUpper().Contains(word.ToUpper()));
                };

                TabelaEtiketa.ItemsSource = etikete;
            }
        }
    }
}
