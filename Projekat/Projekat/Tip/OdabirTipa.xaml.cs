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

namespace Projekat.Tip
{
    /// <summary>
    /// Interaction logic for OdabirTipa.xaml
    /// </summary>
    public partial class OdabirTipa : Window
    {
        private static OdabirTipa instance;
        private Baza baza;
        private ObservableCollection<TipKlasa> tipovi;
        private TipKlasa odabran;
        
        public ObservableCollection<TipKlasa> Tipovi
        {
            get { return tipovi; }
            set { tipovi = value; }
        }

        public TipKlasa Odabran
        {
            get { return odabran; }
            set { odabran = value; }
        }

        public static OdabirTipa Instance
        {
            get { return instance; }
        }


        public OdabirTipa()
        {
            instance = this;
            baza = new Baza();
            baza.ucitajTipove();
            tipovi = baza.Tipovi;
            this.DataContext = this;
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Izaberi(object sender, RoutedEventArgs e)
        {
            if (data_grid.SelectedItem != null)
                odabran = (TipKlasa)data_grid.SelectedItem;
            else
                odabran = null;
            this.Close();
        }

    }
}
