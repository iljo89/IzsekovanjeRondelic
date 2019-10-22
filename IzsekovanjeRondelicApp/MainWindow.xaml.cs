using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using IzsekovanjeRondelicLib;

namespace IzsekovanjeRondelicApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public List<OkroglaRondelica> Seznam
        {
            get;
            set;
        }

        private void BtnIzracunajStevilo_Click(object sender, RoutedEventArgs e)
        {
            double dolzinaTraku, sirinaTraku, polmerRond, razMedSos, razMedStran;
            if (!double.TryParse(TbDolzinaTraku.Text, out dolzinaTraku)
                || !double.TryParse(TbSirinaTraku.Text, out sirinaTraku)
                || !double.TryParse(TbRRond.Text, out polmerRond)
                || !double.TryParse(TbRazMedSos.Text, out razMedSos)
                || !double.TryParse(TbRazMedStran.Text, out razMedStran))
            {
                MessageBox.Show("Preveri vhodne podatke");
            }
            else
            {
                Seznam = IzsekovanjeRondelic.Izracunaj(dolzinaTraku,sirinaTraku,polmerRond,razMedSos, razMedStran);
                /*String izpis = "Seznam rondelic:\n";
                foreach (OkroglaRondelica rond in seznam)
                {
                    izpis += "X: " + rond.XPos + ", Y: " + rond.YPos + "\n";
                }
                MessageBox.Show(izpis);*/
                MessageBox.Show("St. rondelic: " + Seznam.Count.ToString());
            }
        }

        private void BtnPrikaziTrak_Click(object sender, RoutedEventArgs e)
        {
            double dolzinaTraku, sirinaTraku, polmerRond, razMedSos, razMedStran;
            if (!double.TryParse(TbDolzinaTraku.Text, out dolzinaTraku)
                || !double.TryParse(TbSirinaTraku.Text, out sirinaTraku)
                || !double.TryParse(TbRRond.Text, out polmerRond)
                || !double.TryParse(TbRazMedSos.Text, out razMedSos)
                || !double.TryParse(TbRazMedStran.Text, out razMedStran))
            {
                MessageBox.Show("Preveri vhodne podatke");
            }
            else
            {
                Seznam = IzsekovanjeRondelic.Izracunaj(dolzinaTraku, sirinaTraku, polmerRond, razMedSos, razMedStran);
                PrikazTraku prikazTraku = new PrikazTraku(Seznam, dolzinaTraku, sirinaTraku);
                prikazTraku.Show();
            }
        }
    }
}
