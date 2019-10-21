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
        }

        private void BtnIzracunajStevilo_Click(object sender, RoutedEventArgs e)
        {
            var seznam = IzsekovanjeRondelic.Izracunaj(double.Parse(TbDolzinaTraku.Text), double.Parse(TbSirinaTraku.Text), double.Parse(TbRRond.Text), double.Parse(TbRazMedSos.Text), double.Parse(TbRazMedStran.Text));
            /*String izpis = "Seznam rondelic:\n";
            foreach (OkroglaRondelica rond in seznam)
            {
                izpis += "X: " + rond.XPos + ", Y: " + rond.YPos + "\n";
            }
            MessageBox.Show(izpis);*/
            MessageBox.Show("St. rondelic: " + seznam.Count.ToString());
        }
    }
}
