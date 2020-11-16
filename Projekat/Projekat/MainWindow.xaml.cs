using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Projekat.Etiketa;
using Projekat.Manifestacija;
using Projekat.Model;
using Projekat.Tip;


namespace Projekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow instance;
        private Baza baza;
        private TipKlasa tip;
        private ObservableCollection<EtiketaKlasa> etikete;
        private string listaEtiketa;
        private ManifestacijaKlasa m;
        private Point startPoint;
        private ObservableCollection<ManifestacijaKlasa> mfList;
        private ManifestacijaKlasa lastSelected;
        public static MainWindow Instance
        {
            get { return instance; }
        }


        public ObservableCollection<ManifestacijaKlasa> MfList
        {
            get { return mfList; }
            set
            {
                if (mfList != value)
                {

                    mfList = value;
                    OnPropertyChanged("MfList");
                }
            }
        }

        public ObservableCollection<TipKlasa> tipovi
        {
            get;
            set;
        }


        public TipKlasa Tip

        {
            get { return tip; }
            set { tip = value; }
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


        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public void ucitajSve()
        {
            foreach (ManifestacijaKlasa m in baza.Manifestacije)
            {
                bool result = canvasMap.Children.Cast<Image>()
                           .Any(x => x.Tag != null && x.Tag.ToString() == m.Oznaka);

                if (result)
                    continue;

                if (m.X != -1 || m.Y != -1)
                {
                    Image img = new Image();
                    if (!m.Slika.Equals(""))
                        img.Source = new BitmapImage(new Uri(m.Slika));
                    else
                        img.Source = new BitmapImage(new Uri(m.Tip.Slika));


                    img.Width = 50;
                    img.Height = 50;
                    img.Tag = m.Oznaka;
                    WrapPanel wp = new WrapPanel();
                    wp.Orientation = Orientation.Vertical;

                    TextBox oznaka = new TextBox();
                    oznaka.IsEnabled = false;
                    oznaka.Text = "Oznaka: " + m.Oznaka;
                    wp.Children.Add(oznaka);

                    TextBox naziv = new TextBox();
                    naziv.IsEnabled = false;
                    naziv.Text = "Naziv: " + m.Naziv;
                    wp.Children.Add(naziv);


                    TextBox tip = new TextBox();
                    tip.IsEnabled = false;
                    tip.Text = "Tip: " + m.Tip.Oznaka;
                    wp.Children.Add(tip);


                    TextBox opis = new TextBox();
                    opis.IsEnabled = false;
                    opis.Text = "Opis: " + m.Opis;
                    wp.Children.Add(opis);


                    TextBox datum = new TextBox();
                    datum.IsEnabled = false;
                    datum.Text = "Datum: " + m.Datum.ToShortDateString();
                    wp.Children.Add(datum);

                    TextBox hendikepiranost = new TextBox();
                    hendikepiranost.IsEnabled = false;
                    if (m.Hendikepiranost)
                        hendikepiranost.Text = "Dostupan za hendikepirane: Da";
                    else
                        hendikepiranost.Text = "Dostupan za hendikepirane: Ne";
                    wp.Children.Add(hendikepiranost);

                    TextBox pusenje = new TextBox();
                    pusenje.IsEnabled = false;
                    if (m.Pusenje)
                        pusenje.Text = "Dozvoljeno pusenje: Da";
                    else
                        pusenje.Text = "Dozvoljeno pusenje: Ne";
                    wp.Children.Add(pusenje);


                    TextBox odrzavanje = new TextBox();
                    odrzavanje.IsEnabled = false;
                    if (m.Odrzavanje)
                        odrzavanje.Text = "Odrzava se: Unutra";
                    else
                        odrzavanje.Text = "Odrzava se: Napolju";
                    wp.Children.Add(odrzavanje);

                    TextBox alkohol = new TextBox();
                    alkohol.IsEnabled = false;
                    alkohol.Text = "Alkohol: " + m.Alkohol;
                    wp.Children.Add(alkohol);

                    TextBox cene = new TextBox();
                    cene.IsEnabled = false;
                    cene.Text = "Cene: " + m.Cene;
                    wp.Children.Add(cene);

                    TextBox publika = new TextBox();
                    publika.IsEnabled = false;
                    publika.Text = "Publika: " + m.Publika;
                    wp.Children.Add(publika);

                    TextBox etikete = new TextBox();
                    etikete.IsEnabled = false;
                    etikete.Text = "Etikete:" + System.Environment.NewLine;
                    ListaEtiketa = "";
                    StringBuilder sb = new StringBuilder(ListaEtiketa);
                    ObservableCollection<EtiketaKlasa> list = m.Etikete;
                    foreach (EtiketaKlasa et in list)
                    {
                        sb.Append(et.Oznaka);
                        sb.Append(System.Environment.NewLine);
                    }
                    ListaEtiketa = sb.ToString();
                    etikete.Text += ListaEtiketa;
                    ListaEtiketa = "";
                    wp.Children.Add(etikete);

                    ToolTip tt = new ToolTip();
                    tt.Content = wp;

                    img.ToolTip = tt;
                    img.PreviewMouseLeftButtonDown += DraggedImagePreviewMouseLeftButtonDown;
                    img.MouseMove += DraggedImageMouseMove;

                    canvasMap.Children.Add(img);
                    Canvas.SetLeft(img, m.X - 20);
                    Canvas.SetTop(img, m.Y - 20);
                }
            }
        }

        public MainWindow()
        {
            instance = this;
            etikete = new ObservableCollection<EtiketaKlasa>();
            tipovi = new ObservableCollection<TipKlasa>();
            tip = new TipKlasa();
            m = new ManifestacijaKlasa();
            baza = new Baza();
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.DataContext = this;

            tree.Items.Refresh();
            baza.ucitajManifestacije();
            ucitajSve();
            mfList = baza.Manifestacije;
            baza.ucitajEtikete();
            baza.ucitajTipove();

            tipovi = baza.Tipovi;

            puniDrvo();

            

        }

        public void puniDrvo()
        {
            tree.Items.Refresh();

            foreach (TipKlasa t in tipovi)
            {
                foreach (ManifestacijaKlasa ma in baza.Manifestacije)
                {
                    if (ma.Tip.Oznaka.Equals(t.Oznaka))
                    {
                        t.manifestacije.Add(ma);

                    }

                }
            }
        }

        public void izbrisiManf(ManifestacijaKlasa m)
        {
            foreach (TipKlasa t in tipovi)
            {
                if (m.Tip.Oznaka.Equals(t.Oznaka))
                {
                    for (int i = 0; i < t.manifestacije.Count; i++)
                    {
                        if (m.Oznaka == t.manifestacije[i].Oznaka)
                        {
                            Image zaBrisanje = null;
                            foreach (Image img in canvasMap.Children)
                            {
                                if (t.manifestacije[i].Oznaka.Equals(img.Tag))
                                {
                                    zaBrisanje = img;
                                }
                            }
                            if (zaBrisanje != null)
                                canvasMap.Children.Remove(zaBrisanje);

                            t.manifestacije.Remove(t.manifestacije[i]);
                            tree.Items.Refresh();
                            break;
                        }
                    }
                }
            }

        }

        public void izmeniManf(ManifestacijaKlasa m)
        {
            foreach (TipKlasa t in tipovi)
            {
                if (m.Tip.Oznaka.Equals(t.Oznaka))
                {
                    for (int i = 0; i < t.manifestacije.Count; i++)
                    {
                        if (m.Oznaka == t.manifestacije[i].Oznaka)
                        {
                            t.manifestacije[i].setAll(m);


                            Image zaMenjanje = null;
                            int idx = 0;
                            foreach (Image img in canvasMap.Children)
                            {
                                if (t.manifestacije[i].Oznaka.Equals(img.Tag))
                                {
                                    zaMenjanje = img;
                                    break;
                                }
                                idx++;
                            }
                            if (zaMenjanje != null)
                            {
                                WrapPanel wp = new WrapPanel();
                                wp.Orientation = Orientation.Vertical;

                                TextBox oznaka = new TextBox();
                                oznaka.IsEnabled = false;
                                oznaka.Text = "Oznaka: " + m.Oznaka;
                                wp.Children.Add(oznaka);

                                TextBox naziv = new TextBox();
                                naziv.IsEnabled = false;
                                naziv.Text = "Naziv: " + m.Naziv;
                                wp.Children.Add(naziv);


                                TextBox tip = new TextBox();
                                tip.IsEnabled = false;
                                tip.Text = "Tip: " + m.Tip.Oznaka;
                                wp.Children.Add(tip);


                                TextBox opis = new TextBox();
                                opis.IsEnabled = false;
                                opis.Text = "Opis: " + m.Opis;
                                wp.Children.Add(opis);


                                TextBox datum = new TextBox();
                                datum.IsEnabled = false;
                                datum.Text = "Datum: " + m.Datum.ToShortDateString();
                                wp.Children.Add(datum);

                                TextBox hendikepiranost = new TextBox();
                                hendikepiranost.IsEnabled = false;
                                if (m.Hendikepiranost)
                                    hendikepiranost.Text = "Dostupan za hendikepirane: Da";
                                else
                                    hendikepiranost.Text = "Dostupan za hendikepirane: Ne";
                                wp.Children.Add(hendikepiranost);

                                TextBox pusenje = new TextBox();
                                pusenje.IsEnabled = false;
                                if (m.Pusenje)
                                    pusenje.Text = "Dozvoljeno pusenje: Da";
                                else
                                    pusenje.Text = "Dozvoljeno pusenje: Ne";
                                wp.Children.Add(pusenje);


                                TextBox odrzavanje = new TextBox();
                                odrzavanje.IsEnabled = false;
                                if (m.Odrzavanje)
                                    odrzavanje.Text = "Odrzava se: Unutra";
                                else
                                    odrzavanje.Text = "Odrzava se: Napolju";
                                wp.Children.Add(odrzavanje);

                                TextBox alkohol = new TextBox();
                                alkohol.IsEnabled = false;
                                alkohol.Text = "Alkohol: " + m.Alkohol;
                                wp.Children.Add(alkohol);

                                TextBox cene = new TextBox();
                                cene.IsEnabled = false;
                                cene.Text = "Cene: " + m.Cene;
                                wp.Children.Add(cene);

                                TextBox publika = new TextBox();
                                publika.IsEnabled = false;
                                publika.Text = "Publika: " + m.Publika;
                                wp.Children.Add(publika);

                                TextBox etikete = new TextBox();
                                etikete.IsEnabled = false;
                                etikete.Text = "Etikete:" + System.Environment.NewLine;
                                ListaEtiketa = "";
                                StringBuilder sb = new StringBuilder(ListaEtiketa);
                                ObservableCollection<EtiketaKlasa> list = m.Etikete;
                                foreach (EtiketaKlasa et in list)
                                {
                                    sb.Append(et.Oznaka);
                                    sb.Append(System.Environment.NewLine);
                                }
                                ListaEtiketa = sb.ToString();
                                etikete.Text += ListaEtiketa;
                                ListaEtiketa = "";
                                wp.Children.Add(etikete);

                                ToolTip tt = new ToolTip();
                                tt.Content = wp;
                                zaMenjanje.ToolTip = tt;

                                if (!m.Slika.Equals(""))
                                    zaMenjanje.Source = new BitmapImage(new Uri(m.Slika));
                                else
                                    zaMenjanje.Source = new BitmapImage(new Uri(m.Tip.Slika));

                                canvasMap.Children[idx] = zaMenjanje;


                            }


                        }
                    }
                }
            }
        }

        public void obrisiTip(TipKlasa t)
        {

            foreach (TipKlasa t1 in tipovi)
            {

                if (t1.Oznaka == t.Oznaka)
                {
                    for (int i = 0; i < t1.manifestacije.Count; i++)
                    {
                        Image zaBrisanje = null;
                        foreach (Image img in canvasMap.Children)
                        {

                            if (t1.manifestacije[i].Oznaka.Equals(img.Tag))
                            {
                                zaBrisanje = img;
                                Console.WriteLine(img.Tag + "\n\n");
                                if (zaBrisanje != null)
                                {
                                    canvasMap.Children.Remove(zaBrisanje);
                                    break;
                                }

                            }
                        }

                    }
                    tipovi.Remove(t1);
                    tree.Items.Refresh();
                    break;
                }


            }
        }

        public void izmeniTip(TipKlasa t)
        {
            foreach (TipKlasa t1 in tipovi)
            {
                if (t1.Oznaka == t.Oznaka)
                {

                    t1.setAll(t);

                    for (int i = 0; i < t1.manifestacije.Count; i++)
                    {

                        Image zaMenjanje = null;
                        int idx = 0;
                        foreach (Image img in canvasMap.Children)
                        {
                            if (t1.manifestacije[i].Oznaka.Equals(img.Tag))
                            {
                                zaMenjanje = img;

                                if (!t1.manifestacije[i].Slika.Equals(""))
                                    zaMenjanje.Source = new BitmapImage(new Uri(t1.manifestacije[i].Slika));
                                else
                                {
                                    zaMenjanje.Source = new BitmapImage(new Uri(t1.Slika));
                                    t1.manifestacije[i].Tip.Slika = t1.Slika;
                                }


                                canvasMap.Children[idx] = zaMenjanje;


                            }
                            idx++;
                        }


                        tree.Items.Refresh();
                    }
                    tree.Items.Refresh();
                    break;
                }
            }
        }


        public void puniDrvoProvera(ManifestacijaKlasa m)
        {

            ObservableCollection<ManifestacijaKlasa> tmp = new ObservableCollection<ManifestacijaKlasa>();

            foreach (TipKlasa t in tipovi)
            {


                if (m.Tip.Oznaka.Equals(t.Oznaka))
                {
                    if (t.manifestacije.Count > 0)
                    {
                        for (int i = 0; i < t.manifestacije.Count; i++)
                        {
                            if (m.Oznaka != t.manifestacije[i].Oznaka)
                            {

                                t.manifestacije.Add(m);
                                //tree.ItemsSource = tipovi;
                                mfList.Add(m);
                                break;
                            }
                        }
                    }
                    else
                    {
                        t.manifestacije.Add(m);
                        mfList.Add(m);
                    }
                }
            }
        }



        private void dropOnMe_Drop(object sender, DragEventArgs e)
        {
            baza.ucitajManifestacije();
            if (e.Data.GetDataPresent("manifestacija"))
            {


                ManifestacijaKlasa m = e.Data.GetData("manifestacija") as ManifestacijaKlasa;

                bool result = canvasMap.Children.Cast<Image>()
                           .Any(x => x.Tag != null && x.Tag.ToString() == m.Oznaka);
                //  bool preklapanje = false;
                System.Windows.Point d0 = e.GetPosition(canvasMap);

                foreach (ManifestacijaKlasa r0 in baza.Manifestacije)
                {
                    if (m.Oznaka != r0.Oznaka) //ako hoce da pomeri manifesatciju jako malo da ne okida dole
                    {
                        if (r0.X != -1 && r0.Y != -1)
                        {
                            if (Math.Abs(r0.X - d0.X) <= 30 && Math.Abs(r0.Y - d0.Y) <= 30)
                            {
                                System.Windows.MessageBox.Show("Manifestacija sa ovom lokacijom već postoji na mapi! Ponovo unesite manifestaciju na mapu.", "Premeštanje manifestacije na mapi");
                                ucitajSve();
                                return;
                            }
                        }
                    }
                }

                if (result == false)
                {
                    Image img = new Image();
                    if (!m.Slika.Equals(""))
                        img.Source = new BitmapImage(new Uri(m.Slika));
                    else
                        img.Source = new BitmapImage(new Uri(m.Tip.Slika));


                    img.Width = 50;
                    img.Height = 50;
                    img.Tag = m.Oznaka;

                    var positionX = e.GetPosition(canvasMap).X;
                    var positionY = e.GetPosition(canvasMap).Y;
                    m.X = positionX;
                    m.Y = positionY;


                    WrapPanel wp = new WrapPanel();
                    wp.Orientation = Orientation.Vertical;

                    TextBox oznaka = new TextBox();
                    oznaka.IsEnabled = false;
                    oznaka.Text = "Oznaka: " + m.Oznaka;
                    wp.Children.Add(oznaka);

                    TextBox naziv = new TextBox();
                    naziv.IsEnabled = false;
                    naziv.Text = "Naziv: " + m.Naziv;
                    wp.Children.Add(naziv);


                    TextBox tip = new TextBox();
                    tip.IsEnabled = false;
                    tip.Text = "Tip: " + m.Tip.Oznaka;
                    wp.Children.Add(tip);


                    TextBox opis = new TextBox();
                    opis.IsEnabled = false;
                    opis.Text = "Opis: " + m.Opis;
                    wp.Children.Add(opis);


                    TextBox datum = new TextBox();
                    datum.IsEnabled = false;
                    datum.Text = "Datum: " + m.Datum.ToShortDateString();
                    wp.Children.Add(datum);

                    TextBox hendikepiranost = new TextBox();
                    hendikepiranost.IsEnabled = false;
                    if (m.Hendikepiranost)
                        hendikepiranost.Text = "Dostupan za hendikepirane: Da";
                    else
                        hendikepiranost.Text = "Dostupan za hendikepirane: Ne";
                    wp.Children.Add(hendikepiranost);

                    TextBox pusenje = new TextBox();
                    pusenje.IsEnabled = false;
                    if (m.Pusenje)
                        pusenje.Text = "Dozvoljeno pusenje: Da";
                    else
                        pusenje.Text = "Dozvoljeno pusenje: Ne";
                    wp.Children.Add(pusenje);


                    TextBox odrzavanje = new TextBox();
                    odrzavanje.IsEnabled = false;
                    if (m.Odrzavanje)
                        odrzavanje.Text = "Odrzava se: Unutra";
                    else
                        odrzavanje.Text = "Odrzava se: Napolju";
                    wp.Children.Add(odrzavanje);

                    TextBox alkohol = new TextBox();
                    alkohol.IsEnabled = false;
                    alkohol.Text = "Alkohol: " + m.Alkohol;
                    wp.Children.Add(alkohol);

                    TextBox cene = new TextBox();
                    cene.IsEnabled = false;
                    cene.Text = "Cene: " + m.Cene;
                    wp.Children.Add(cene);

                    TextBox publika = new TextBox();
                    publika.IsEnabled = false;
                    publika.Text = "Publika: " + m.Publika;
                    wp.Children.Add(publika);

                    TextBox etikete = new TextBox();
                    etikete.IsEnabled = false;
                    etikete.Text = "Etikete:" + System.Environment.NewLine;
                    ListaEtiketa = "";
                    StringBuilder sb = new StringBuilder(ListaEtiketa);
                    ObservableCollection<EtiketaKlasa> list = m.Etikete;
                    foreach (EtiketaKlasa et in list)
                    {
                        sb.Append(et.Oznaka);
                        sb.Append(System.Environment.NewLine);
                    }
                    ListaEtiketa = sb.ToString();
                    etikete.Text += ListaEtiketa;
                    ListaEtiketa = "";
                    wp.Children.Add(etikete);

                    ToolTip tt = new ToolTip();
                    tt.Content = wp;
                    img.ToolTip = tt;
                    img.PreviewMouseLeftButtonDown += DraggedImagePreviewMouseLeftButtonDown;
                    img.MouseMove += DraggedImageMouseMove;

                    ObservableCollection<ManifestacijaKlasa> mfLista = baza.Manifestacije;

                    int idx = 0;
                    foreach (ManifestacijaKlasa ma in mfLista)
                    {
                        if (ma.Oznaka.Equals(m.Oznaka))
                            break;

                        idx++;
                    }

                    mfLista[idx] = m;
                    baza.Manifestacije = mfLista;
                    baza.sacuvajManifestaciju();

                    canvasMap.Children.Add(img);
                    Canvas.SetLeft(img, m.X - 20);
                    Canvas.SetTop(img, m.Y - 20);
                }
                else
                {
                    System.Windows.MessageBox.Show("Manifestacija sa ovom oznakom već postoji na mapi!", "Dodavanje manifestacije na mapu");
                }
            }
        }

        private void DraggedImageMouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;
            if (e.LeftButton == MouseButtonState.Pressed &&
               (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
               Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {

                try
                {
                    ManifestacijaKlasa selektovana = (ManifestacijaKlasa)tree.SelectedValue;
                    if (selektovana != null)
                    {
                        Image img = sender as Image;
                        canvasMap.Children.Remove(img);
                        DataObject dragData = new DataObject("manifestacija", selektovana);
                        DragDrop.DoDragDrop(img, dragData, DragDropEffects.Move);

                    }
                }
                catch
                {

                }

            }

        }

        private void DropList_DragEnter(object sender, DragEventArgs e)
        {


            if (!e.Data.GetDataPresent("manifestacija") || sender == e.Source)
            {

                e.Effects = DragDropEffects.None;
            }

        }

        private void PrikazIkonice_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }


        private void DraggedImagePreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            startPoint = e.GetPosition(null);
            Image img = sender as Image;

            foreach (ManifestacijaKlasa man in MfList)
            {
                if (man.Oznaka.Equals(img.Tag))
                {

                    var tvi = FindTviFromObjectRecursive(tree, man);
                    if (tvi != null) tvi.IsSelected = true;
                    if (!man.Slika.Equals(""))
                        PrikazIkonice.Source = new BitmapImage(new Uri(man.Slika));
                    else
                        PrikazIkonice.Source = new BitmapImage(new Uri(man.Tip.Slika));

                }
            }
            if (e.LeftButton == MouseButtonState.Released)
                e.Handled = true;

        }

        private void DraggedImagePreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

            startPoint = e.GetPosition(null);
            Image img = sender as Image;
            int i = 0;

            foreach (ManifestacijaKlasa man in mfList)
            {
                if (man.Oznaka.Equals(img.Tag))
                {
                    var tvi = FindTviFromObjectRecursive(tree, man);
                    if (tvi != null) tvi.IsSelected = true;
                }
            }

        }

        public static TreeViewItem FindTviFromObjectRecursive(ItemsControl ic, object o)
        {

            try
            {//Search for the object model in first level children (recursively)

                TreeViewItem tvi = ic.ItemContainerGenerator.ContainerFromItem(o) as TreeViewItem;

                if (tvi != null)
                {
                    tvi.Focus();
                    return tvi;
                }
                //Loop through user object models
                foreach (object i in ic.Items)
                {
                    //Get the TreeViewItem associated with the iterated object model
                    TreeViewItem tvi2 = ic.ItemContainerGenerator.ContainerFromItem(i) as TreeViewItem;
                    tvi = FindTviFromObjectRecursive(tvi2, o);

                    if (tvi != null)
                    {
                        tvi.Focus();
                        return tvi;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        private void PrikazIkonice_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;
            if (e.LeftButton == MouseButtonState.Pressed &&
               (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
               Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                try
                {
                    ManifestacijaKlasa selektovana = (ManifestacijaKlasa)tree.SelectedValue;
                    if (selektovana != null)
                    {

                        DataObject dragData = new DataObject("manifestacija", selektovana);
                        DragDrop.DoDragDrop(PrikazIkonice, dragData, DragDropEffects.Move);
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        private void tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (tree.SelectedValue is ManifestacijaKlasa)
            {
                ManifestacijaKlasa m = (ManifestacijaKlasa)tree.SelectedValue;
                lastSelected = m;
                if (!m.Slika.Equals(""))
                    PrikazIkonice.Source = new BitmapImage(new Uri(m.Slika));
                else
                    PrikazIkonice.Source = new BitmapImage(new Uri(m.Tip.Slika));

            }
            else { PrikazIkonice.Source = null; }

        }

        private void Ukloni_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ManifestacijaKlasa selektovana = (ManifestacijaKlasa)tree.SelectedItem;
                if (selektovana != null)
                {
                    bool postoji = canvasMap.Children.Cast<Image>()
                           .Any(x => x.Tag != null && x.Tag.ToString() == selektovana.Oznaka);
                    if (postoji)
                    {
                        Image img = null;
                        foreach (Image i in canvasMap.Children)
                        {
                            if (i.Tag.Equals(selektovana.Oznaka))
                                img = i;
                        }
                        canvasMap.Children.Remove(img);
                        int idx = 0;
                        foreach (ManifestacijaKlasa m in mfList)
                        {
                            if (selektovana.Oznaka.Equals(m.Oznaka))
                                break;
                            idx++;
                        }


                        baza.Manifestacije[idx].X = -1;
                        baza.Manifestacije[idx].Y = -1;
                        mfList[idx].X = -1;
                        mfList[idx].Y = -1;

                        baza.sacuvajManifestaciju();
                        baza.ucitajManifestacije();


                        ucitajSve();
                        //tree.Items.Refresh();
                    }
                }
            }
            catch
            {
                return;
            }
        }


        private void Manifestacija(object sender, RoutedEventArgs e)
        {
            var s = new Projekat.Manifestacija.pocetni();
            s.Show();
        }

        private void Etiketa(object sender, RoutedEventArgs e)
        {
            var s = new Projekat.Etiketa.pocetniEtiketa();
            s.Show();
        }

        private void Tipp(object sender, RoutedEventArgs e)
        {
            var s = new Projekat.Tip.pocetniTip();
            s.Show();
        }

        public void About_click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Help.ShowHelp(null, @"./../../../Help.chm");
            
        }

        private void DodajManifestaciju(object sender, RoutedEventArgs e)
        {
            var s = new Projekat.Manifestacija.ManifestacijaDodaj();
            s.Show();
        }

        private void DodajEtiketu(object sender, RoutedEventArgs e)
        {
            var s = new Projekat.Etiketa.EtiketaDodaj();
            s.Show();
        }

        private void DodajTip(object sender, RoutedEventArgs e)
        {

            var s = new Projekat.Tip.TipDodaj();
            s.Show();

        }

        public void demo()
        {
            demoMode = true;

            Point p = DodajManifestaciju_dugme.PointToScreen(new Point(0d, 0d));
            p.X += 20;
            p.Y += 10;

            LinearSmoothMove(p, 100);
            if (!demoMode) return;
            Thread.Sleep(500);
            if (!demoMode) return;
            ManifestacijaDodaj w2 = new ManifestacijaDodaj();
            w2.Show();
            Thread.Sleep(500);
            Application.Current.Dispatcher?.BeginInvoke(new Action(() =>
            {

                w2.beginDemo(this);
            }));
        }

        private void demo_Begin(object sender, RoutedEventArgs e)
        {

            demoMode = true;

            Point p = DodajManifestaciju_dugme.PointToScreen(new Point(0d, 0d));
            p.X += 20;
            p.Y += 10;

            if (demoMode)
            {
                LinearSmoothMove(p, 100);

                ManifestacijaDodaj w2 = new ManifestacijaDodaj();
                w2.Show();
                Thread.Sleep(500);
                Application.Current.Dispatcher?.BeginInvoke(new Action(() =>
                {

                    w2.beginDemo(this);
                }));

            }

            //Win32.ClientToScreen(this.Handle, ref p);

        }

        public Boolean ciklicno = false;

        public void LinearSmoothMove(Point newPosition, int steps)
        {
            if (demoMode)
            {
                Point start = Win32.GetMousePosition();
                Point iterPoint = start;

                // Find the slope of the line segment defined by start and newPosition
                Point slope = new Point(newPosition.X - start.X, newPosition.Y - start.Y);

                // Divide by the number of steps
                slope.X = slope.X / steps;
                slope.Y = slope.Y / steps;

                // Move the mouse to each iterative point.
                for (int i = 0; i < steps; i++)
                {
                    if (!demoMode)
                    {
                        Thread.ResetAbort();
                        return;
                        
                    }
                    iterPoint = new Point(iterPoint.X + slope.X, iterPoint.Y + slope.Y);
                    Win32.SetCursorPos((int)iterPoint.X, (int)iterPoint.Y);
                    Thread.Sleep(20);
                    
                }

                // Move the mouse to the final destination.
                Win32.SetCursorPos((int)newPosition.X, (int)newPosition.Y);
            }
        }

        private Boolean demoMode = false;

        private void ExitDemo_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (demoMode == true)
            {
                e.CanExecute = true;
            }
        }

        private void ExitDemo_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            demoMode = false;
           
        }

        
    }
}

