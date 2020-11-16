using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.Manifestacija;

namespace Projekat.Model
{
    public class TipKlasa
    {
        private string oznaka = "";
        private string naziv = "";
        private string opis = "";
        private string slika = "";
       

        public ObservableCollection<ManifestacijaKlasa> manifestacije
        {
            get;
            set;
        }

        public TipKlasa(string oznaka,string naziv,string opis,string slika)
        {
            this.oznaka = oznaka;
            this.naziv = naziv;
            this.opis = opis;
            this.slika = slika;
            manifestacije = new ObservableCollection<ManifestacijaKlasa>();
        }

        public void setAll(TipKlasa t)
        {
            this.oznaka = t.oznaka;
            this.naziv = t.naziv;
            this.opis = t.opis;
            this.slika = t.slika;
        }

        public TipKlasa()
        {
            manifestacije = new ObservableCollection<ManifestacijaKlasa>();
        }

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
            get
            {
                return slika;
            }
            set
            {
                if (value != slika)
                {
                    slika = value;
                    OnPropertyChanged("Slika");
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

        public static implicit operator TipKlasa(string v)
        {
            throw new NotImplementedException();
        }
    }
}
