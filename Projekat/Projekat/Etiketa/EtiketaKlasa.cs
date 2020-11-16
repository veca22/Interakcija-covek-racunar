using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projekat.Etiketa
{
    public class EtiketaKlasa
    {
        private string oznaka = "";
        private string opis = "";
        private string boja = "";

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

        public string Opis
        {
            get
            {
                return opis;
            }
            set
            {
                if (opis != value)
                {
                    opis = value;
                    OnPropertyChanged("Opis");
                }

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

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        

        public EtiketaKlasa(string id,string o,string b)
        {
            oznaka = id;
            opis = o;
            boja = b;
        }

        public void setAll(EtiketaKlasa e)
        {
           oznaka = e.oznaka;
           boja = e.boja;
           opis = e.opis;
        }
    }

    
}
