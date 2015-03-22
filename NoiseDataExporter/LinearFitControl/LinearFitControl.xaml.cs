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
    public class DoneLinearFittingEventArgs:EventArgs
    {
        private double m_intercept;

        public double Intercept
        {
            get { return m_intercept; }
        }

        private double m_slope;

        public double Slope
        {
            get { return m_slope; }
        }

        private double m_zeroCrossingPointX;

        public double ZeroCrossingPointX
        {
            get { return m_zeroCrossingPointX; }
        }

        public DoneLinearFittingEventArgs(double Intercept,double Slope, double ZeroCrossingPointX)
        {
            m_intercept = Intercept;
            m_slope = Slope;
            m_zeroCrossingPointX = ZeroCrossingPointX;
        }

    }

    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class LinearFitControl : UserControl
    {
        
        private LinearFitViewModel m_viewModel;
        public event EventHandler<DoneLinearFittingEventArgs> FittingDone;

        public LinearFitControl()
        { 
            InitializeComponent();
            m_viewModel = new LinearFitViewModel(LinearFitPlotter);
            //ShowZeroCrossingPoint = false;
            DataContext = m_viewModel;
        }
             
        

        private void DoneButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnFittingDone(this, new DoneLinearFittingEventArgs(m_viewModel.Intercept, m_viewModel.Slope, m_viewModel.ZeroCrossingPointX));
        }

        private void OnFittingDone(object sender, DoneLinearFittingEventArgs e)
        {
            if (FittingDone != null)
                FittingDone(sender, e);
        }

        public void SetData(List<Point> Data)
        {
            m_viewModel.Data = Data;
        }

        public void ClearData()
        {
            m_viewModel = new LinearFitViewModel(LinearFitPlotter);
            DataContext = m_viewModel;
        }

        public double Intercept
        {
            get
            {
                return m_viewModel.Intercept;
            }
        }

        public double Slope
        {
            get { return m_viewModel.Slope; }
        }

        public double ZeroCrossingPointX
        {
            get { return m_viewModel.ZeroCrossingPointX; }
        }

    }
}
