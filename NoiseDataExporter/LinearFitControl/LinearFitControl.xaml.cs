using Microsoft.Research.DynamicDataDisplay.Charts;
using Microsoft.Research.DynamicDataDisplay.Charts.Shapes;
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
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace LinearFitControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class LinearFitControl : UserControl
    {
        
        private LinearFitViewModel m_viewModel;
        

        public LinearFitControl()
        { 
            InitializeComponent();
            m_viewModel = new LinearFitViewModel(LinearFitPlotter);
            DataContext = m_viewModel;
        }
             
        

        private void DoneButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }


        public void SetData(List<Point> Data)
        {
            m_viewModel.Data = Data;
        }

    }
}
