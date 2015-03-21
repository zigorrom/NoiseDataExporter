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

namespace NoiseDataExporter
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            var data = new List<Point>();
            data.Add(new Point(0, 0));
            data.Add(new Point(1, 1));
            Petro.SetData(data);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var rand = new Random();
            var data = new List<Point>();

            for (int i = 0; i < rand.Next(3,100); i++)
            {
                data.Add(new Point(rand.NextDouble()*1000, rand.NextDouble()));
            }
            Petro.SetData(data);
        }
    }
}
