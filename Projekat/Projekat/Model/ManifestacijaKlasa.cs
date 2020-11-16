using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.Etiketa;
using Projekat.Tip;

namespace Projekat.Model
{
    public class ManifestacijaKlasa
    {
        private string oznaka = "";
        private string naziv = "";
        private string opis = "";

        private string alkohol = "";
        private string cene = "";
        private string publika = "";

        private DateTime datum = DateTime.Today;

        private bool hendikepiranost = false;
        private bool pusenje = false;
        private bool odrzavanje = false;

        private string slika = "";

        private TipKlasa tip = new TipKlasa();
        private ObservableCollection<EtiketaKlasa> etikete = new ObservableCollection<EtiketaKlasa>();

        private double x = -1;
        private double y = -1;

        public string Oznaka
        {
            get
            {
                return oznaka;
            }
            set
            {
                if(value != oznaka)
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
                if(value != naziv)
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

        public string Alkohol
        {
            get
            {
                return alkohol;
            }
            set
            {
                if (value != alkohol)
                {
                    alkohol = value;
                    OnPropertyChanged("Alkohol");
                }
            }
        }

        public string Cene
        {
            get
            {
                return cene;
            }
            set
            {
                if (value != cene)
                {
                    cene = value;
                    OnPropertyChanged("Cene");
                }
            }
        }

        public string Publika
        {
            get
            {
                return publika;
            }
            set
            {
                if (value != publika)
                {
                    publika = value;
                    OnPropertyChanged("Publika");
                }
            }
        }

        public DateTime Datum
        {
            get
            {
                return datum;
            }
            set
            {
                if(value != datum)
                {
                    datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }

        public bool Hendikepiranost
        {
            get
            {
                return hendikepiranost;
            }
            set
            {
                if (value != hendikepiranost)
                {
                    hendikepiranost = value;
                    OnPropertyChanged("Hendikepiranost");
                }
            }
        }

        public bool Pusenje
        {
            get
            {
                return pusenje;
            }
            set
            {
                if (value != pusenje)
                {
                    pusenje = value;
                    OnPropertyChanged("Pusenje");
                }
            }
        }

        public bool Odrzavanje
        {
            get
            {
                return odrzavanje;
            }
            set
            {
                if (value != odrzavanje)
                {
                    odrzavanje = value;
                    OnPropertyChanged("Odrzavanje");
                }
            }
        }

        public String Slika
        {
            get
            {
                return slika;
            }
            set
            {
                if (value != slika)
                    slika = value;
                OnPropertyChanged("Slika");
            }
        }

        public TipKlasa Tip
        {
            get
            {
                return tip;
            }
            set
            {
                if (value != tip)
                {
                    tip = value;
                    OnPropertyChanged("Tip");
                }
            }
        }

        public ObservableCollection<EtiketaKlasa> Etikete
        {
            get
            {
                return etikete;
            }
            set
            {
                if (value != etikete)
                {
                    etikete = value;
                    OnPropertyChanged("Etikete");
                }
            }
        }

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                if (value != x)
                    x = value;
                OnPropertyChanged("X");
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value != y)
                    y = value;
                OnPropertyChanged("Y");
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

        public ManifestacijaKlasa()
        {

        }

        public ManifestacijaKlasa(string oznaka,string naziv,string opis,string alkohol,string cene,string publika,DateTime datum,bool hendikepiranost,bool pusenje,bool odrzavanje,string slika,TipKlasa tip, ObservableCollection<EtiketaKlasa> etikete)
        {
            this.oznaka = oznaka;
            this.naziv = naziv;
            this.opis = opis;
            this.alkohol = alkohol;
            this.cene = cene;
            this.publika = publika;
            this.datum = datum;
            this.hendikepiranost = hendikepiranost;
            this.pusenje = pusenje;
            this.odrzavanje = odrzavanje;
            this.slika = slika;
            this.tip = tip;
            this.etikete = etikete;
        }

        public void setAll(ManifestacijaKlasa m)
        {
            this.oznaka = m.oznaka;
            this.naziv = m.naziv;
            this.opis = m.opis;
            this.alkohol = m.alkohol;
            this.cene = m.cene;
            this.publika = m.publika;
            this.datum = m.datum;
            this.hendikepiranost = m.hendikepiranost;
            this.pusenje = m.pusenje;
            this.odrzavanje = m.odrzavanje;
            this.slika = m.slika;
            this.tip = m.tip;
            this.etikete = m.etikete;
        }
    }
}
