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
using System.Windows.Shapes;
using IzsekovanjeRondelicLib;

namespace IzsekovanjeRondelicApp
{
    /// <summary>
    /// Interaction logic for PrikazTraku.xaml
    /// </summary>
    public partial class PrikazTraku : Window
    {
        public PrikazTraku(List<OkroglaRondelica> seznam, double dolzinaTraku, double sirinaTraku)
        {
            InitializeComponent();
            NarisiCanvas(seznam, dolzinaTraku, sirinaTraku);
        }

        public void NarisiCanvas(List<OkroglaRondelica> seznam, double dolzinaTraku, double sirinaTraku)
        {
            CanTrak.Width = dolzinaTraku;
            CanTrak.Height = sirinaTraku;

            Rectangle trak = new Rectangle() // doda se oblika traku
            {
                Width = dolzinaTraku,
                Height = sirinaTraku,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };

            CanTrak.Children.Add(trak);
            trak.SetValue(Canvas.LeftProperty, 0.0);
            trak.SetValue(Canvas.TopProperty, 0.0);

            foreach (OkroglaRondelica rond in seznam) // Dodamo vse rondelice na trak
            {
                Ellipse rondelica = new Ellipse()
                {
                    Width = rond.RRond*2,
                    Height = rond.RRond*2,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1
                };

                CanTrak.Children.Add(rondelica);

                rondelica.SetValue(Canvas.LeftProperty, rond.XPos - rond.RRond);
                rondelica.SetValue(Canvas.TopProperty, sirinaTraku - rond.YPos - rond.RRond); // Na canvasu je izhodišče levo zgoraj, v aplikaciji pa levo spodaj, zato manevri z Y pozicijo
            }
        }
    }
}
