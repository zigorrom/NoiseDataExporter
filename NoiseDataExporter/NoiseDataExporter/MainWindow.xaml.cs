using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NoiseDataExporter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel m_ViewModel;
        private FolderBrowserDialog m_fbd;
        public MainWindow()
        {
            InitializeComponent();
            m_ViewModel = new ViewModel();
            this.DataContext = m_ViewModel;
            m_fbd = new FolderBrowserDialog();
        }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var res = m_fbd.ShowDialog();
            if(res == System.Windows.Forms.DialogResult.OK)
            {
                m_ViewModel.WorkingDirectory = m_fbd.SelectedPath;
            }
        }
    }
}
