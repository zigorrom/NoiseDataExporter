
using Microsoft.Research.DynamicDataDisplay.DataSources;
using NoiseDataExporter.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
        private LinearFitControl.LinearFitControl m_fitControl;
        private LogControl m_logControl;
        //private Core m_core;
        private BackgroundWorker m_worker;

        //private IVAnalysis m_ivAnalysis;

        public MainWindow()
        {
            InitializeComponent();

            m_AverageDSVoltage = 0;
            m_DSVoltagesSum = 0;
            m_CurrentDSVoltageList = new List<MeasurDataExtendedLine>();
            
            m_ViewModel = new ViewModel(this);//m_core.CoreViewModel;
            this.DataContext = m_ViewModel;
            m_logControl = new LogControl();
            m_fitControl = new LinearFitControl.LinearFitControl();
            m_ViewModel.CurrentContent = m_logControl;
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
            //throw new NotImplementedException();
        }

        void m_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           // throw new NotImplementedException();
        }

        void m_worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           // throw new NotImplementedException();
        }
        
        
        private const string MeasureDataFilename = "MeasurData.dat";
        private const string MeasureDataExtendedFileName = "MeasurDataExtended.dat";
        private const double DrainSourceVoltageError = 0.005;
        private const char ValueCharSeparator = '\t';

        private double m_AverageDSVoltage;
        private double m_DSVoltagesSum;
       
        private List<MeasurDataExtendedLine> m_CurrentDSVoltageList;
        private string MeasurDataExtendedFN;
        

        void m_worker_DoWork(object sender, DoWorkEventArgs e)
        {
           
            var worker = (BackgroundWorker)sender;
            MeasurDataExtendedFN = String.Concat(m_ViewModel.WorkingDirectory, '\\', MeasureDataExtendedFileName);
            
            var HeaderStr = "";
            var UnitStr = "";

            
            if(!File.Exists(MeasurDataExtendedFN))
                return;
            using(StreamReader sr = new StreamReader(MeasurDataExtendedFN))
            {
                HeaderStr = sr.ReadLine();
                UnitStr = sr.ReadLine();
                while(!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var strValues = line.Split(ValueCharSeparator);
                    var MeasurData = new MeasurDataExtendedLine(strValues);
                    if(m_CurrentDSVoltageList.Count==0)
                    {
                        m_AverageDSVoltage = m_DSVoltagesSum = MeasurData.USample;
                        m_CurrentDSVoltageList.Add(MeasurData);
                    }
                    else
                    {
                        if (Math.Abs(MeasurData.USample - m_AverageDSVoltage) > DrainSourceVoltageError)
                        {
                            ProcessCurrentDataSet();
                            m_AverageDSVoltage = m_DSVoltagesSum = MeasurData.USample;
                            m_CurrentDSVoltageList.Add(MeasurData);
                        }
                        else
                        {
                            m_CurrentDSVoltageList.Add(MeasurData);
                            m_DSVoltagesSum += MeasurData.USample;
                            m_AverageDSVoltage = m_DSVoltagesSum / m_CurrentDSVoltageList.Count;
                        }
                    }
                }

            }
        }

        private void ProcessCurrentDataSet()
        {
            if (m_CurrentDSVoltageList.Count > 1)
            {
                var PointList = m_CurrentDSVoltageList.Select(x =>
                    {
                        return new Point(x.VoltageGate, x.Current);
                    }
                );

                Dispatcher.Invoke(new Action<List<Point>>(x => { m_fitControl.SetData(x); }),PointList.ToList());
                m_ViewModel.CurrentContent = m_fitControl;
                
            }
            ExportData();
            m_CurrentDSVoltageList.Clear();

        }

        private void ExportData()
        {
           // throw new NotImplementedException();
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

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            m_ViewModel.CurrentContent = m_fitControl;
                
        }
    }
}
