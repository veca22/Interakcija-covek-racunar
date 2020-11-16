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
using Microsoft.Win32;
using Projekat.Etiketa;
using Projekat.Tip;
using Projekat.Model;

namespace Projekat.Manifestacija
{
    /// <summary>
    /// Interaction logic for ManifestacijaIzmena.xaml
    /// </summary>
    public partial class ManifestacijaIzmena : Window
    {
        private bool _myTextBoxChanging = false;

        private string oznaka;
        private string naziv;
        private string opis;
        private string slika;
        private string calkohol;
        private string ccene;
        private string cpublika;
        private TipKlasa tip;
        private string oznakaTipa;
        private string listaEtiketa;
        private ObservableCollection<EtiketaKlasa> etikete;

        private bool hendikepiranostDa;
        private bool hendikepiranostNe;

        private bool pusenjeDa;
        private bool pusenjeNe;

        private bool odrzavaUnutra;
        private bool odrzavaNapolju;

        private DateTime datum;

        private Baza baza;
        private ManifestacijaKlasa selektovana;
        private ManifestacijaKlasa izmenjena;
        public int idx = -1;


        public string Oznaka
        {
            get { return oznaka; }
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
            get { return naziv; }
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
            get { return opis; }
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
            set
            {
                if (value != slika)
                {
                    slika = value;
                    OnPropertyChanged("Slika");
                }

            }
        }

        public string CAlkohol
        {
            get { return calkohol; }
            set
            {
                if(value != calkohol)
                {
                    calkohol = value;
                    OnPropertyChanged("CAlkohol");
                }
            }
        }

        public string CCene
        {
            get { return ccene; }
            set
            {
                if (value != ccene)
                {
                    ccene = value;
                    OnPropertyChanged("CCene");
                }
            }
        }

        public string CPublika
        {
            get { return cpublika; }
            set
            {
                if (value != cpublika)
                {
                    cpublika = value;
                    OnPropertyChanged("CPublika");
                }
            }
        }
        public TipKlasa Tip
        {
            get { return tip; }
            set
            {
                if (value != tip)
                {
                    tip = value;
                    OnPropertyChanged("Tip");
                }
            }
        }

        public string OznakaTipa
        {
            get { return oznakaTipa; }
            set
            {
                if (value != oznakaTipa)
                {
                    oznakaTipa = value;
                    OnPropertyChanged("OznakaTipa");
                }
            }
        }

        public string ListaEtiketa
        {
            get { return listaEtiketa; }
            set
            {
                if (value != listaEtiketa)
                {
                    listaEtiketa = value;
                    OnPropertyChanged("ListaEtiketa");
                }
            }
        }

        public ObservableCollection<EtiketaKlasa> Etikete
        {
            get { return etikete; }
            set { etikete = value; }
        }

        
        public bool HendikepiranostDa
        {
            get { return hendikepiranostDa; }
            set
            {
                if (value != hendikepiranostDa)
                {
                    hendikepiranostDa = value;
                    OnPropertyChanged("HendikepiranostDa");
                }
            }
        }
        public bool HendikepiranostNe
        {
            get { return hendikepiranostNe; }
            set
            {
                if (value != hendikepiranostNe)
                {
                    hendikepiranostNe = value;
                    OnPropertyChanged("HendikepiranostNe");
                }
            }
        }

        public bool PusenjeDa
        {
            get { return pusenjeDa; }
            set
            {
                if (value != pusenjeDa)
                {
                    pusenjeDa = value;
                    OnPropertyChanged("PusenjeDa");
                }
            }
        }

        public bool PusenjeNe
        {
            get { return pusenjeNe; }
            set
            {
                if (value != pusenjeNe)
                {
                    pusenjeNe = value;
                    OnPropertyChanged("PusenjeNe");
                }
            }
        }
        public bool OdrzavaUnutra
        {
            get { return odrzavaUnutra; }
            set
            {
                if (value != odrzavaUnutra)
                {
                    odrzavaUnutra = value;
                    OnPropertyChanged("OdrzavaUnutra");
                }
            }
        }

        public bool OdrzavaNapolju
        {
            get { return odrzavaNapolju; }
            set
            {
                if (value != odrzavaNapolju)
                {
                    odrzavaNapolju = value;
                    OnPropertyChanged("OdrzavaNapolju");
                }
            }
        }

        public DateTime Datum
        {
            get { return datum; }
            set
            {
                if (value != datum)
                {
                    datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }




        public ManifestacijaKlasa Izmenjena
        {
            get { return izmenjena; }
            set { izmenjena = value; }
        }

        public ObservableCollection<string> Cene
        {
            get;
            set;
        }

        public ObservableCollection<string> Alkohol
        {
            get;
            set;
        }

        public ObservableCollection<string> Publika
        {
            get;
            set;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public ManifestacijaIzmena(ManifestacijaKlasa m)
        {
            baza = new Baza();
            Alkohol = new ObservableCollection<string>();
            Alkohol.Add("Nema");
            Alkohol.Add("Može se doneti");
            Alkohol.Add("Kupiti na licu mesta");

            Cene = new ObservableCollection<string>();
            Cene.Add("Besplatno");
            Cene.Add("Niske");
            Cene.Add("Srednje");
            Cene.Add("Visoke");

            Publika = new ObservableCollection<string>();
            Publika.Add("Deca");
            Publika.Add("Odrasli");
            Publika.Add("Svi uzrasti");

            etikete = new ObservableCollection<EtiketaKlasa>();

            tip = new TipKlasa();
            this.DataContext = this;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            selektovana = m;
            Oznaka = m.Oznaka;
            Naziv = m.Naziv;
            Opis = m.Opis;
            Slika = m.Slika;
            CAlkohol = m.Alkohol;
            CCene = m.Cene;
            CPublika = m.Publika;
            Tip = m.Tip;
            OznakaTipa = Tip.Oznaka;
            Etikete = m.Etikete;

            bool hendikepiranost = m.Hendikepiranost;
            if(hendikepiranost)
            {
                HendikepiranostDa = true;
                HendikepiranostNe = false;
            }
            else
            {
                HendikepiranostDa = false;
                HendikepiranostNe = true;
            }

            bool pusenje = m.Pusenje;
            if(pusenje)
            {
                PusenjeDa = true;
                PusenjeNe = false; 
            }
            else
            {
                PusenjeDa = false;
                pusenjeNe = true;
            }

            bool odrzava = m.Odrzavanje;
            if(odrzava)
            {
                OdrzavaUnutra = true;
                OdrzavaNapolju = false;
            }
            else
            {
                OdrzavaUnutra = false;
                OdrzavaNapolju = true;
            }
            Datum = m.Datum;
            if(Etikete.Count > 0)
            {
                StringBuilder sb = new StringBuilder(ListaEtiketa);
                foreach (EtiketaKlasa et in Etikete)
                {
                    sb.Append(et.Oznaka);
                    sb.Append(System.Environment.NewLine);
                }

                ListaEtiketa = sb.ToString();
            }

            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Izmeni(object sender, RoutedEventArgs e)
        {
            if (oznaka_tb.Text == "")
            {
                System.Windows.MessageBox.Show("Niste uneli oznaku!", "Izmena podataka");
                return;
            }
            else if (textbox_naziv.Text == "")
            {
                System.Windows.MessageBox.Show("Niste uneli naziv!", "Izmena podataka");
                return;
            }
            else if (alkohol_cb.Text == "")
            {
                System.Windows.MessageBox.Show("Niste odabrali alkhol!", "Izmena podataka");
                return;
            }

            else if (cene_cb.Text == "")
            {
                System.Windows.MessageBox.Show("Niste odabrali cene!", "Izmena podataka");
                return;
            }
            else if (publika_cb.Text == "")
            {
                System.Windows.MessageBox.Show("Niste odabrali publiku!", "Izmena podataka");
                return;
            }
            else if (DatumPicker.Text == "")
            {
                System.Windows.MessageBox.Show("Niste odabrali datum!", "Izmena podataka");
                return;
            }
            else if (textbox_tip.Text == "")
            {
                System.Windows.MessageBox.Show("Niste odabrali tip!", "Izmena podataka");
                return;
            }
            else
            {
                bool _hendikepiranost = false;
                if (HendikepiranostDa)
                    _hendikepiranost = true;

                bool _pusenje = false;
                if (PusenjeDa)
                    _pusenje = true;

                bool _odrzava = false;
                if (odrzavaUnutra)
                    _odrzava = true;

                Izmenjena = new ManifestacijaKlasa(Oznaka, Naziv, Opis, CAlkohol, CCene,CPublika, Datum, _hendikepiranost, _pusenje, _odrzava,Slika, Tip, Etikete);
                Baza b = new Baza();
                idx = 0;
                foreach(ManifestacijaKlasa mf in b.Manifestacije)
                {
                    if (mf.Oznaka == izmenjena.Oznaka)
                        break;

                    idx++;
                }

                b.Manifestacije.RemoveAt(idx);
                b.Manifestacije.Add(Izmenjena);
                b.sacuvajManifestaciju();

                MainWindow.Instance.izmeniManf(izmenjena);
                this.Close();

            }
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
                slika = ikonica.Source.ToString();
            }
        }
        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OdabirEtikete(object sender, RoutedEventArgs e)
        {
            var s = new Etiketa.OdabirEtiketa();
            s.ShowDialog();

            ObservableCollection<EtiketaKlasa> temp = s.Odabrane;
            if (s.dodavanje)
            {
                ObservableCollection<EtiketaKlasa> pomocna = new ObservableCollection<EtiketaKlasa>();
                if (temp != null)
                {
                    bool b = false;
                    listaEtiketa = "";
                    baza.ucitajEtikete();
                    etikete = baza.Etikete;
                    StringBuilder sb = new StringBuilder(ListaEtiketa);

                    foreach (EtiketaKlasa et in etikete)
                    {
                        foreach (EtiketaKlasa et2 in temp)
                        {
                            if (et.Oznaka.Equals(et2.Oznaka))
                            {
                                b = true;
                            }
                            else b = false;
                            if (b)
                            {
                                pomocna.Add(et2);

                                sb.Append(et2.Oznaka);
                                sb.Append(System.Environment.NewLine);
                            }

                        }
                    }
                    etikete = pomocna;
                    ListaEtiketa = sb.ToString();

                    textbox_etikete.Text = ListaEtiketa;
                }
            }
            else
            {
                if (temp != null && temp.Count > 0)
                {

                    listaEtiketa = "";
                    baza.ucitajEtikete();
                    etikete = baza.Etikete;
                    ObservableCollection<EtiketaKlasa> pomocna2 = etikete;
                    StringBuilder sb = new StringBuilder(ListaEtiketa);
                    int idx = -1;
                    for (int i = 0; i < temp.Count; i++)
                    {
                        idx = 0;
                        foreach (EtiketaKlasa et in etikete)
                        {
                            if (et.Oznaka.Equals(temp.ElementAt(i).Oznaka))
                                break;
                            idx++;
                        }
                        if (idx != -1)
                        {
                            etikete.RemoveAt(idx);
                        }
                    }
                    foreach (EtiketaKlasa et in temp)
                    {
                        etikete.Remove(et);
                    }

                    foreach (EtiketaKlasa et in etikete)
                    {
                        sb.Append(et.Oznaka);
                        sb.Append(System.Environment.NewLine);
                    }
                    ListaEtiketa = sb.ToString();

                    textbox_etikete.Text = ListaEtiketa;
                }
            }
        }

        private void odabirTipa(object sender, RoutedEventArgs e)
        {
            OdabirTipa s = new OdabirTipa();
            s.ShowDialog();

            TipKlasa temp = s.Odabran;
            if (temp != null)
            {
                tip = temp;
                OznakaTipa = tip.Oznaka;
                textbox_tip.Text = OznakaTipa;
            }
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

        private void phoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char character = Convert.ToChar(e.Text);
            if (char.IsNumber(character))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

    }
}
