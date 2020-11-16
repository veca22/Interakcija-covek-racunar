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
using System.Windows.Threading;
using Microsoft.VisualBasic.Compatibility.VB6;
using Microsoft.Win32;
using Projekat.Etiketa;
using Projekat.Model;
using Projekat.Tip;

namespace Projekat.Manifestacija
{
    /// <summary>
    /// Interaction logic for ManifestacijaDodaj.xaml
    /// </summary>
    public partial class ManifestacijaDodaj : Window
    {
       

        private string oznaka = "";
        private string naziv = "";
        private string opis = "";
        private Boolean demoMod = false;
        

        private DateTime datum = DateTime.Today;

        private bool hendikepiranost = false;
        private bool pusenje = false;
        private bool odrzavanje = false;

        private string slika = "";

        private TipKlasa tip = new TipKlasa();
        private ObservableCollection<EtiketaKlasa> etikete = new ObservableCollection<EtiketaKlasa>();
        private ObservableCollection<ManifestacijaKlasa> mfList;

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

        private Baza baza;
        private string listaEtiketa;
        private string oznakaTipa;
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

        

        public DateTime Datum
        {
            get
            {
                return datum;
            }
            set
            {
                if (value != datum)
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


        public ManifestacijaDodaj()
        {
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
            baza = new Baza();
            tip = new TipKlasa();

            this.DataContext = this;
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            
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

        private void OdabirTipaa(object sender, RoutedEventArgs e)
        {
            var s = new Tip.OdabirTipa();
            s.ShowDialog();

            TipKlasa pomocni = s.Odabran;
            if(pomocni != null)
            {
                tip = pomocni;
                OznakaTipa = tip.Oznaka;
                tip_tb.Text = OznakaTipa;
            }
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

                    etikete_tb.Text = ListaEtiketa;
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

                    etikete_tb.Text = ListaEtiketa;
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
        private void Sacuvaj(object sender, RoutedEventArgs e)
        {
            if(oznaka_tb.Text == "")
            {
                System.Windows.MessageBox.Show("Niste popunili oznaku!", "Dodavanje Manifestacije");
                return;
            }
            else if(naziv_tb.Text == "")
            {
                System.Windows.MessageBox.Show("Niste popunili naziv!", "Dodavanje Manifestacije");
                return;
            }
            else if(alkohol_cb.Text == "")
            {
                System.Windows.MessageBox.Show("Niste odabrali alkhol!", "Dodavanje Manifestacije");
                return;
            }

            else if (cene_cb.Text == "")
            {
                System.Windows.MessageBox.Show("Niste odabrali cene!", "Dodavanje Manifestacije");
                return;
            }
            else if (publika_cb.Text == "")
            {
                System.Windows.MessageBox.Show("Niste odabrali publiku!", "Dodavanje Manifestacije");
                return;
            }
            else if (DatumPicker.Text == "")
            {
                System.Windows.MessageBox.Show("Niste odabrali datum!", "Dodavanje Manifestacije");
                return;
            }
            else if (tip_tb.Text == "")
            {
                System.Windows.MessageBox.Show("Niste odabrali tip!", "Dodavanje Manifestacije");
                return;
            }
            DateTime d = Datum;

            if (HendikepiranDa.IsChecked == true)
                hendikepiranost = true;

            if (PusenjeDa.IsChecked == true)
                pusenje = true;

            if (UnutraDa.IsChecked == true)
                odrzavanje = true;

            string alkoholi = "";

            if (alkohol_cb.SelectedIndex.Equals(-1))
                alkoholi = "";
            else if(alkohol_cb.SelectedItem.Equals("Nema"))
            {
                int idx = Alkohol.IndexOf("Nema");
                alkoholi = Alkohol[idx];
            }
            else if (alkohol_cb.SelectedItem.Equals("Može se doneti"))
            {
                int idx = Alkohol.IndexOf("Može se doneti");
                alkoholi = Alkohol[idx];
            }
            else
            {
                int idx = Alkohol.IndexOf("Kupiti na licu mesta");
                alkoholi = Alkohol[idx];
            }

            string cena = "";
            
            if (cene_cb.SelectedIndex.Equals(-1))
                cena = "";
            else if (cene_cb.SelectedItem.Equals("Besplatno"))
            {
                int idx = Cene.IndexOf("Besplatno");
                cena = Cene[idx];
            }
            else if (cene_cb.SelectedItem.Equals("Niske"))
            {
                int idx = Cene.IndexOf("Niske");
                cena = Cene[idx];
            }
            else if (cene_cb.SelectedItem.Equals("Srednje"))
            {
                int idx = Cene.IndexOf("Srednje");
                cena = Cene[idx];
            }
            else
            {
                int idx = Cene.IndexOf("Visoke");
                cena = Cene[idx];
            }
            string publike = "";

            if (publika_cb.SelectedIndex.Equals(-1))
                publike = "";
            else if (publika_cb.SelectedItem.Equals("Deca"))
            {
                int idx = Publika.IndexOf("Deca");
                publike = Publika[idx];
            }
            else if (publika_cb.SelectedItem.Equals("Odrasli"))
            {
                int idx = Publika.IndexOf("Odrasli");
                publike = Publika[idx];
            }
            else
            {
                int idx = Publika.IndexOf("Svi uzrasti");
                publike = Publika[idx];
            }

            Opis = opis_tb.Text;

            if(slika == null && tip.Slika != null)
            {
                if (tip.Slika != "")
                    slika = tip.Slika;
            }
            else if(slika == null && tip.Slika == null)
            {
                slika = System.IO.Path.GetFullPath(@"..\..\") + "Images\\defLoc.png";
            }

            string s = oznaka;
            s = s.Replace(' ', '_');
            oznaka = s;

            datum = (DateTime)DatumPicker.SelectedDate;
            ManifestacijaKlasa m = new ManifestacijaKlasa(oznaka, naziv, opis, alkoholi, cena, publike, datum, hendikepiranost, pusenje, odrzavanje,slika, tip, etikete);
            bool manif = baza.addManifestaciju(m);
            if (manif)
            {
                baza.sacuvajManifestaciju();
              
                mfList = baza.Manifestacije;
                MainWindow.Instance.puniDrvoProvera(m);
                if(pocetni.Instanca != null)
                  pocetni.Instanca.puniManif(m);

                this.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Manifestacija sa tom oznakom već postoji!", "Dodavanje Manifestacije");
            }
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

        public Point GetNazivPoint()
        {
            if (!demoMod)
                return new Point(0, 0);

            Point p2 = naziv_tb.PointToScreen(new Point(0d, 0d));
            return p2;
        }

        public Point getOznakaPoint()
        {
            if (!demoMod)
                return new Point(0, 0);

            return oznaka_tb.PointToScreen(new Point(0d, 0d));
        }

        public Point getOpisPoint()
        {
            if (!demoMod)
                return new Point(0, 0);

            return opis_tb.PointToScreen(new Point(0d, 0d));
        }

        public Point getOdustaniPoint()
        {
            if (!demoMod)
                return new Point(0, 0);

            return odustani_b.PointToScreen(new Point(0d, 0d));
        }

        public Point getAlkoholPoint()
        {
            if (!demoMod)
                return new Point(0, 0);

            return alkohol_cb.PointToScreen(new Point(0d, 0d));
        }

        public Point getCenePoint()
        {
            if (!demoMod)
                return new Point(0, 0);

            return cene_cb.PointToScreen(new Point(0d, 0d));
        }

        public Point getHendikepiranDa()
        {
            if (!demoMod)
                return new Point(0, 0);

            return HendikepiranDa.PointToScreen(new Point(0d, 0d));
        }

        public Point getPusenjeNe()
        {
            if (!demoMod)
                return new Point(0, 0);

            return PusenjeNe.PointToScreen(new Point(0d, 0d));
        }

        public Point getUnutraDa()
        {
            if (!demoMod)
                return new Point(0, 0);

            return UnutraDa.PointToScreen(new Point(0d, 0d));
        }

        public Point getPublika()
        {
            if (!demoMod)
                return new Point(0, 0);

            return publika_cb.PointToScreen(new Point(0d, 0d));
        }

        public Point getDatum()
        {
            if (!demoMod)
                return new Point(0, 0);

            return DatumPicker.PointToScreen(new Point(0d, 0d));
        }

        public Point getIkonica()
        {
            if (!demoMod)
                return new Point(0, 0);

            return ikonica_b.PointToScreen(new Point(0d, 0d));

        }

        public Point getTipLabel()
        {
            if (!demoMod)
                return new Point(0, 0);

            return tip_label.PointToScreen(new Point(0d, 0d));
        }

        public Point getOdaberiEtikete()
        {
            if (!demoMod)
                return new Point(0, 0);

            return odaberi_etikete.PointToScreen(new Point(0d, 0d));
        }

        public Point getOdaberiTip()
        {
            if (!demoMod)
                return new Point(0, 0);

            return odaberi_tip.PointToScreen(new Point(0d, 0d));
        }

        public Point getDodaj()
        {
            if (!demoMod)
                return new Point(0, 0);

            return dodaj_b.PointToScreen(new Point(0d, 0d));
        }
        public void LinearSmoothMove(Point newPosition, int steps)
        {
            if (demoMod)
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
                    if (!demoMod)
                    {
                        return;
                    }
                    iterPoint = new Point(iterPoint.X + slope.X, iterPoint.Y + slope.Y);
                    Win32.SetCursorPos((int)iterPoint.X, (int)iterPoint.Y);
                    System.Threading.Thread.Sleep(20);
                }

                // Move the mouse to the final destination.
                Win32.SetCursorPos((int)newPosition.X, (int)newPosition.Y);
            }

        }
        private void ExitDemo_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (demoMod == true)
            {
                e.CanExecute = true;
            }
        }

      
        private void ExitDemo_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            demoMod = false;
            this.Close();
            this.UpdateLayout();
        }

        public void beginDemo(MainWindow m)
        {
            demoMod = true;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    Point p3 = getOznakaPoint();
                    p3.Y += 5;
                    p3.X += 50;
                    LinearSmoothMove(p3, 100);
                    System.Threading.Thread.Sleep(500);
                }
                else
                    return;

            });
            if (!demoMod)
            {                
                return;
                
            }
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(100);
                    oznaka_tb.Text = "O";
                }
            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(100);
                    oznaka_tb.Text = "Oz";
                }
            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(100);
                    oznaka_tb.Text = "Ozn";
                }
            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(100);
                    oznaka_tb.Text = "Ozna";
                }
            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(100);
                    oznaka_tb.Text = "Oznak";
                }
            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(100);
                    oznaka_tb.Text = "Oznaka";
                }

            });
            if (!demoMod) return;

            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(500);
                    Point p2 = GetNazivPoint();
                    p2.Y += 5;
                    p2.X += 50;
                    LinearSmoothMove(p2, 100);
                    System.Threading.Thread.Sleep(500);
                }
            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(100);
                    naziv_tb.Text = "N";
                }
            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(100);
                    naziv_tb.Text = "Na";
                }
            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(100);
                    naziv_tb.Text = "Naz";
                }
            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(100);
                    naziv_tb.Text = "Nazi";
                }
            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(100);
                    naziv_tb.Text = "Naziv";
                }
            });
            if (!demoMod) return;

            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    Point p3 = getOpisPoint();
                    Console.WriteLine(p3.X + " " + p3.Y);

                    p3.X += 50;
                    p3.Y += 10;

                    LinearSmoothMove(p3, 100);
                    System.Threading.Thread.Sleep(500);
                }
            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(100);
                    opis_tb.Text = "O";
                }
            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(100);
                    opis_tb.Text = "Op";
                }
            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(100);
                    opis_tb.Text = "Opi";
                }
            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(100);
                    opis_tb.Text = "Opis";
                }
            });
            if (!demoMod) return;
            // na odustani
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    Point p3 = getAlkoholPoint();


                    p3.X += 50;
                    p3.Y += 10;

                    LinearSmoothMove(p3, 100);
                    System.Threading.Thread.Sleep(500);
                }
            });

            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(100);
                    alkohol_cb.IsDropDownOpen = true;
                }
                   

            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(250);
                    alkohol_cb.SelectedIndex = 0;
                }
                

            });

            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(550);
                    alkohol_cb.IsDropDownOpen = false;
                }


            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    Point p3 = getCenePoint();


                    p3.X += 50;
                    p3.Y += 10;

                    LinearSmoothMove(p3, 100);
                    System.Threading.Thread.Sleep(500);
                }
                
            });

            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(100);
                    cene_cb.IsDropDownOpen = true;
                }


            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(250);
                    cene_cb.SelectedIndex = 0;
                }


            });

            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(550);
                    cene_cb.IsDropDownOpen = false;
                }


            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    Point p3 = getHendikepiranDa();


                    p3.X -= 0;
                    p3.Y += 10;

                    LinearSmoothMove(p3, 100);
                    //System.Threading.Thread.Sleep(200);
                    HendikepiranDa.IsChecked = true;
                    System.Threading.Thread.Sleep(500);
                }
            });
          

            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(200);
                    Point p3 = getPusenjeNe();


                    p3.X -= 0;
                    p3.Y += 10;

                    LinearSmoothMove(p3, 100);
                    PusenjeNe.IsChecked = true;
                    System.Threading.Thread.Sleep(500);
                }
            });

            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(200);
                    Point p3 = getUnutraDa();


                    p3.X -= 0;
                    p3.Y += 10;

                    LinearSmoothMove(p3, 100);
                    UnutraDa.IsChecked = true;
                    System.Threading.Thread.Sleep(700);
                }
            });

            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    Point p3 = getPublika();


                    p3.X += 20;
                    p3.Y += 20;

                    LinearSmoothMove(p3, 100);
                    System.Threading.Thread.Sleep(700);
                }
            });

            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(100);
                    publika_cb.IsDropDownOpen = true;
                }


            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(250);
                    publika_cb.SelectedIndex = 2;
                }


            });

            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(550);
                    publika_cb.IsDropDownOpen = false;

                }
            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    Point p3 = getDatum();


                    p3.X += 20;
                    p3.Y += 20;

                    LinearSmoothMove(p3, 100);
                    System.Threading.Thread.Sleep(700);
                }
            });

            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(100);
                    DatumPicker.IsDropDownOpen = true;
                }
            });

            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(250);
                    DatumPicker.SelectedDate = DateTime.Now;
                }

            });

            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(550);
                    DatumPicker.IsDropDownOpen = false;
                }


            });

            System.Windows.Forms.OpenFileDialog fileDialog;
            SaveFileDialog sv = new SaveFileDialog();
            
            if (!demoMod) return;
             Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
             {
                 if (demoMod)
                 {
                     Point p3 = getIkonica();


                     p3.X += 20;
                     p3.Y += 20;

                     LinearSmoothMove(p3, 100);
                     System.Threading.Thread.Sleep(700);
                     fileDialog = new System.Windows.Forms.OpenFileDialog();
                     // fileDialog.InitialDirectory = "Projekat";
                     fileDialog.Title = "Izaberi ikonicu";
                     fileDialog.Filter = "Images|*.jpg;*.jpeg;*.png|" +
                                         "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                                         "Portable Network Graphic (*.png)|*.png";
                     if (!demoMod) return;
                     else
                         fileDialog.ShowDialog();

                     //ikonica.Source = new BitmapImage(new Uri(fileDialog.FileName));
                     //slika = ikonica.Source.ToString();                 

                     System.Threading.Thread.Sleep(500);
                 }
                 
             });


           

            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    Point p3 = getCenePoint();


                    p3.X += 70;
                    p3.Y += 70;

                    LinearSmoothMove(p3, 100);
                    System.Threading.Thread.Sleep(500);
                }
               

            });

            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {

                    Point p3 = getTipLabel();


                    p3.X += 280;
                    p3.Y += 100;

                    LinearSmoothMove(p3, 100);
                    System.Threading.Thread.Sleep(500);
                    DialogCloser.Execute();
                    ikonica.Source = new BitmapImage(new Uri(@"G:\HCI\Projekat\Projekat\Slike\exit.png"));
                    System.Threading.Thread.Sleep(500);
                }

            });

            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {

                if (demoMod)
                {
                    Point p3 = getOdaberiEtikete();


                    p3.X += 20;
                    p3.Y += 20;

                    LinearSmoothMove(p3, 100);
                    System.Threading.Thread.Sleep(500);

                }

            });
            OdabirEtiketa e = new OdabirEtiketa();
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(550);
                    String id = "Etiketa";
                    String opis = "Opis";
                    String boja = "Red";
                    EtiketaKlasa et = new EtiketaKlasa(id, opis, boja);
                    OdabirEtiketa.Instance.Etikete.Add(et);

                    System.Threading.Thread.Sleep(200);
                    if (!demoMod) return;
                    else
                        e.Show();
                }

            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {

                if (demoMod)
                {
                    Point p3 = getCenePoint();


                    p3.X += 60;
                    p3.Y -= 60;

                    LinearSmoothMove(p3, 100);
                    System.Threading.Thread.Sleep(500);

                }

            });

            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (!demoMod) return;
                if (demoMod)
                {
                    OdabirEtiketa.Instance.data_grid.SelectedIndex = 0;
                    System.Threading.Thread.Sleep(500);


                }
            });

            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {

                if (demoMod)
                {
                    Point p3 = getPublika();


                    p3.X += 160;
                    p3.Y += 85;

                    LinearSmoothMove(p3, 100);
                    System.Threading.Thread.Sleep(500);

                }

            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(550);
                    etikete_tb.SelectedText = "Etiketa";
                    e.Close();
                    System.Threading.Thread.Sleep(550);
                }
            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {

                    Point p3 = getOdaberiTip();


                    p3.X += 20;
                    p3.Y += 20;

                    LinearSmoothMove(p3, 100);
                    System.Threading.Thread.Sleep(500);
                }


            });
            OdabirTipa t = new OdabirTipa();
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(550);
                    TipKlasa t1 = new TipKlasa();
                    String naziv = "Naziv";
                    String oznaka = "Tip";
                    String opis = "Opis";
                    String slika = @"Projekat\slika.png";
                    t1.Naziv = naziv;
                    t1.Oznaka = oznaka;
                    t1.Opis = opis;
                    t1.Slika = slika;
                    OdabirTipa.Instance.Tipovi.Add(t1);
                    System.Threading.Thread.Sleep(200);
                    if (!demoMod) return;
                    else
                        t.Show();
                }

            });

            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {

                if (demoMod)
                {
                    Point p3 = getCenePoint();


                    p3.X += 60;
                    p3.Y -= 60;

                    LinearSmoothMove(p3, 100);
                    System.Threading.Thread.Sleep(500);

                }

            });

            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    if (!demoMod) return;

                    OdabirTipa.Instance.data_grid.SelectedIndex = 0;
                    System.Threading.Thread.Sleep(500);

                }

            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {


                    Point p3 = getPublika();


                    p3.X += 160;
                    p3.Y += 85;

                    LinearSmoothMove(p3, 100);
                    System.Threading.Thread.Sleep(500);


                }
            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(550);
                    tip_tb.SelectedText = "Tip";
                    t.Close();
                    System.Threading.Thread.Sleep(550);
                }
            });


            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(500);
                    Point p2 = getDodaj();
                    p2.Y += 5;
                    p2.X += 20;
                    LinearSmoothMove(p2, 100);
                    System.Threading.Thread.Sleep(500);
                }
            });

            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    System.Threading.Thread.Sleep(2000);
                    this.Close();
                    //Application.Current.MainWindow.Show();
                }

                this.Close();
                
            });
            if (!demoMod) return;
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
            {
                if (demoMod)
                {
                    m.demo();
                }
            });



        }

        private void OznakaTB_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.A && e.Key <= Key.Z) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || (e.Key >= Key.D0 && e.Key <= Key.D9) || e.Key == Key.Tab)
            {
            }
            else
            {
                e.Handled = true;
            }
        }

    }
}
