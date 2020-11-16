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
using Projekat.Manifestacija;
using Projekat.Model;

namespace Projekat.Tip
{
    /// <summary>
    /// Interaction logic for pocetniTip.xaml
    /// </summary>
    public partial class pocetniTip : Window
    {
        private static pocetniTip instance;
        private  ObservableCollection<TipKlasa> tipovi;
        private Baza baza;
        public  ObservableCollection<TipKlasa> Tipovi
        {
            get { return tipovi; }
            set { tipovi = value; }
        }

      public static pocetniTip Instance
       {
            get { return instance; }
       }


        public pocetniTip()
        {
            instance = this;
            baza = new Baza();
            baza.ucitajTipove();
            tipovi = baza.Tipovi;
            this.DataContext = this;
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

        private void DodajTip(object sender, RoutedEventArgs e)
        {

            var s = new Projekat.Tip.TipDodaj();
            s.ShowDialog();

        }

        public void PuniTip(TipKlasa t)
        {
            Tipovi.Add(t);
            TabelaTipova.Items.Refresh();
            
        }

        private void IzmeniTip(object sender, RoutedEventArgs e)
        {
            TipKlasa tp;
            if (TabelaTipova.SelectedValue is TipKlasa)
            {
                tp = (TipKlasa)TabelaTipova.SelectedValue;

                var s = new TipIzmeni(tp);
                s.ShowDialog();
                baza.ucitajTipove();
                Tipovi = baza.Tipovi;

                if (s.idx != -1)
                {
                    baza.Tipovi[s.idx] = s.izmenjenTip;
                    MainWindow.Instance.izmeniTip(s.izmenjenTip);
                    baza.sacuvajTip();
                    Tipovi = baza.Tipovi;
                    foreach (ManifestacijaKlasa ma in baza.Manifestacije)
                    {
                        if (ma.Tip.Oznaka.Equals(s.izmenjenTip.Oznaka))
                            ma.Tip = s.izmenjenTip;
                    }
                    baza.sacuvajManifestaciju();
                    baza.ucitajManifestacije();

                }
                TabelaTipova.ItemsSource = null;
                baza.ucitajTipove();
                Tipovi = baza.Tipovi;
                TabelaTipova.ItemsSource = Tipovi;

            }
            else
            {
                System.Windows.MessageBox.Show("Niste odabrali nijedan tip.", "Izmena tipa");

            }
        }

        private void Okej(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.tree.Items.Refresh();
            this.Close();
        }
        private void Obrisi(object sender, RoutedEventArgs e)
        {
            TipKlasa m = null;
            if (TabelaTipova.SelectedValue is TipKlasa)
            {
                m = (TipKlasa)TabelaTipova.SelectedValue;
                List<String> manif = new List<string>();
                bool ima = false;
                foreach (ManifestacijaKlasa ma in baza.Manifestacije)
                {
                    if (ma.Tip.Oznaka.Equals(m.Oznaka))
                        manif.Add("Oznaka: " + ma.Oznaka + ", Naziv: " + ma.Naziv + Environment.NewLine);
                }
                if (manif.Count > 0)
                    ima = true;
                MessageBoxResult result;
                if (ima)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append("Da li želite da nastavite sa brisanjem?" + Environment.NewLine + "Tip se trenutno koristi u sledećim manifestacijama: " + Environment.NewLine).AppendLine();
                    foreach (string str in manif)
                    {
                        builder.Append(str.ToString()).AppendLine();
                    }
                    builder.Append("Brisanjem tipa brišu se i manifestacije koje ga koriste. ").AppendLine();
                    result = System.Windows.MessageBox.Show(builder.ToString(), "Brisanje tipa", MessageBoxButton.YesNo);
                }
                else
                    result = MessageBox.Show("Da li sigurno želite da obrišete odabrani tip?", "Brisanje tipa", MessageBoxButton.YesNo);

                switch (result)
                {
                    case MessageBoxResult.Yes:

                        m = (TipKlasa)TabelaTipova.SelectedValue;
                        MainWindow.Instance.obrisiTip(m);
                        baza.brisanjeTipa(m);
                        //MainWindow.Instance.obrisiTip(m);
                        if (ima)
                        {
                            List<ManifestacijaKlasa> zaBrisanje = new List<ManifestacijaKlasa>();
                            foreach (ManifestacijaKlasa ma in baza.Manifestacije)
                            {
                                if (ma.Tip.Oznaka.Equals(m.Oznaka))
                                    zaBrisanje.Add(ma);
                            }
                            foreach (ManifestacijaKlasa ma in zaBrisanje)
                            {
                                baza.Manifestacije.Remove(ma);
                            }
                            baza.sacuvajManifestaciju();

                        }
                        Tipovi = baza.Tipovi;
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }


            }
            else
            {
                System.Windows.MessageBox.Show("Niste odabrali tip za brisanje!", "Brisanje tipa");

            }


        }

        private void pretraga_po_oznaci(object sender, TextChangedEventArgs e)
        {
            System.Windows.Controls.TextBox textbox = sender as System.Windows.Controls.TextBox;
            string filter = textbox.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(tipovi);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    TipKlasa man = o as TipKlasa;
                    string[] words = filter.Split(' ');
                    if (words.Contains(""))
                        words = words.Where(word => word != "").ToArray();
                    return words.Any(word => man.Oznaka.ToUpper().Contains(word.ToUpper()));
                };

                TabelaTipova.ItemsSource = tipovi;
            }
        }
    }
}
