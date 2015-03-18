using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private OpenFileDialog m_ofd;
        private Core m_core;
        private BackgroundWorker m_worker;
        


        public MainWindow()
        {
            InitializeComponent();
            m_core = new Core();
            m_ViewModel = m_core.CoreViewModel;
            this.DataContext = m_ViewModel;
            m_fbd = new FolderBrowserDialog();
            m_ofd = new OpenFileDialog();
            m_worker = new BackgroundWorker();
            m_worker.WorkerReportsProgress = true;
            m_worker.WorkerSupportsCancellation = true;
            m_worker.DoWork += m_worker_DoWork;
            m_worker.ProgressChanged += m_worker_ProgressChanged;
            m_worker.RunWorkerCompleted += m_worker_RunWorkerCompleted;
            m_worker.Disposed += m_worker_Disposed;
        }

        void m_worker_Disposed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void m_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void m_worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void m_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            if (!m_core.PrepareToProcessData())
                return;

           
        }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var res = m_fbd.ShowDialog();
            if(res == System.Windows.Forms.DialogResult.OK)
            {
                m_ViewModel.WorkingDirectory = m_fbd.SelectedPath;
            }
        }

        private void MenuItem_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            var res = m_ofd.ShowDialog();
            if(res == System.Windows.Forms.DialogResult.OK)
            {
                m_ViewModel.TransconductanceReferenceFile = m_ofd.FileName;
            }
        }

        private void MenuItem_Click_2(object sender, System.Windows.RoutedEventArgs e)
        {
            m_worker.RunWorkerAsync();
        }
    }
}
