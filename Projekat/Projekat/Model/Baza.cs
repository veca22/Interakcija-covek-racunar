using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Projekat.Etiketa;
using Projekat.Manifestacija;
using Projekat.Tip;

namespace Projekat.Model
{
    class Baza
    {
        private ObservableCollection<EtiketaKlasa> etikete = new ObservableCollection<EtiketaKlasa>();
        private ObservableCollection<TipKlasa> tipovi = new ObservableCollection<TipKlasa>();
        private ObservableCollection<ManifestacijaKlasa> manifestacije = new ObservableCollection<ManifestacijaKlasa>();

        private string pathEtiketa = null;
        private string pathTip = null;
        private string pathManifestacija = null;
        public ObservableCollection<EtiketaKlasa> Etikete
        {

            get { return etikete; }
            set { etikete = value; }
        }

        public ObservableCollection<TipKlasa> Tipovi
        {

            get { return tipovi; }
            set { tipovi = value; }
        }

        public ObservableCollection<ManifestacijaKlasa> Manifestacije
        {

            get { return manifestacije; }
            set { manifestacije = value; }
        }


        public Baza()
        {
            pathEtiketa = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "etikete.txt");
            pathTip = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tipovi.txt");
            pathManifestacija = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "manifestacije.txt");

            ucitajEtikete();
            ucitajTipove();
            ucitajManifestacije();

            sacuvajManifestaciju();
        }
        public void ucitajEtikete()
        {
            if (File.Exists(pathEtiketa))
            {

                using (StreamReader reader = File.OpenText(pathEtiketa))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    etikete = (ObservableCollection<EtiketaKlasa>)serializer.Deserialize(reader, typeof(ObservableCollection<EtiketaKlasa>));
                }
            }
            else
            {
                etikete = new ObservableCollection<EtiketaKlasa>();
            }
        }

        public void ucitajTipove()
        {
            if (File.Exists(pathTip))
            {

                using (StreamReader reader = File.OpenText(pathTip))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    tipovi = (ObservableCollection<TipKlasa>)serializer.Deserialize(reader, typeof(ObservableCollection<TipKlasa>));
                }
            }
            else
            {
                tipovi = new ObservableCollection<TipKlasa>();
            }
        }

        public void ucitajManifestacije()
        {
            if (File.Exists(pathManifestacija))
            {

                using (StreamReader reader = File.OpenText(pathManifestacija))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    manifestacije = (ObservableCollection<ManifestacijaKlasa>)serializer.Deserialize(reader, typeof(ObservableCollection<ManifestacijaKlasa>));
                }
            }
            else
            {
                manifestacije = new ObservableCollection<ManifestacijaKlasa>();
            }
        } 



        public void sacuvajEtiketu()
        {
            using (StreamWriter writer = File.CreateText(pathEtiketa))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, etikete);
                writer.Close();
            }

        }

        public void sacuvajTip()
        {
            using (StreamWriter writer = File.CreateText(pathTip))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, tipovi);
                writer.Close();
            }
        }

        public void sacuvajManifestaciju()
        {
            using (StreamWriter writer = File.CreateText(pathManifestacija))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, manifestacije);
                writer.Close();
            }
        }


        public bool addEtiketa(EtiketaKlasa e)
        {
            foreach (EtiketaKlasa e1 in etikete)
            {
                if (e1.Oznaka == e.Oznaka)
                {

                    return false;
                }
            }
            etikete.Add(e);
            sacuvajEtiketu();
            return true;

        }

        public bool addTip(TipKlasa tp)
        {
            foreach (TipKlasa tp1 in tipovi)
            {
                if (tp1.Oznaka == tp.Oznaka)
                {

                    return false;
                }
            }
            tipovi.Add(tp);
            sacuvajTip();
            return true;

        }

        public bool addManifestaciju(ManifestacijaKlasa m)
        {
            foreach (ManifestacijaKlasa m1 in manifestacije)
            {
                if (m1.Oznaka == m.Oznaka)
                {

                    return false;
                }
            }
            manifestacije.Add(m);
            sacuvajManifestaciju();
            return true;

        }

        public bool brisanjeManifestacije(ManifestacijaKlasa m)
        {

            foreach (ManifestacijaKlasa m1 in manifestacije)
            {
                if (m1.Oznaka == m.Oznaka)
                {
                    manifestacije.Remove(m);
                    sacuvajManifestaciju();

                    return true;
                }
            }

            return false;
        }



        public bool brisanjeEtikete(EtiketaKlasa e)
        {

            foreach (EtiketaKlasa e1 in etikete)
            {
                if (e1.Oznaka == e.Oznaka)
                {
                    etikete.Remove(e);
                    sacuvajEtiketu();
                    return true;
                }
            }

            return false;
        }


        public bool brisanjeTipa(TipKlasa t)
        {

            foreach (TipKlasa t1 in tipovi)
            {
                if (t1.Oznaka == t.Oznaka)
                {
                    tipovi.Remove(t);
                    sacuvajTip();
                    return true;
                }
            }

            return false;
        }
    }
}
