using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for OdabirEtiketa.xaml
    /// </summary>
    public partial class OdabirEtiketa : Window
    {
        private static OdabirEtiketa instance;
        private Baza baza;
        private ObservableCollection<EtiketaKlasa> etikete;
        private ObservableCollection<EtiketaKlasa> odabrane;
        public bool dodavanje;

        public static OdabirEtiketa Instance
        {
            get { return instance; }
        }


        public ObservableCollection<EtiketaKlasa> Etikete
        {
            get { return etikete; }
            set { etikete = value; }
        }

        public ObservableCollection<EtiketaKlasa> Odabrane
        {
            get { return odabrane; }
            set { odabrane = value; }
        }

        public OdabirEtiketa()
        {
            instance = this;
            baza = new Baza();
            baza.ucitajEtikete();
            etikete = baza.Etikete;
            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Izaberi(object sender, RoutedEventArgs e)
        {
            dodavanje = true;
            odabrane = new ObservableCollection<EtiketaKlasa>();
            if (data_grid.SelectedItems != null)
            {
                foreach (EtiketaKlasa et in data_grid.SelectedItems)
                {
                    odabrane.Add(et);
                }
            }
            else
                odabrane = null;
            this.Close();
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
