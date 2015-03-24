
using Microsoft.Research.DynamicDataDisplay.DataSources;
using NoiseDataExporter.DataModel;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

    public class ExportDataContainer : List<MeasurDataExtendedLine>
    {
        public ExportDataContainer()
            : base()
        {
            m_AverageDSVoltage = 0;
            m_DSVoltagesSum = 0;
            m_TresholdVoltage = 0;
        }

        public new void Add(MeasurDataExtendedLine line)
        {
            base.Add(line);
            DSVoltagesSum += line.USample;
            AverageDSVoltage = DSVoltagesSum / Count;
        }

        private double m_AverageDSVoltage;

        public double AverageDSVoltage
        {
            get { return m_AverageDSVoltage; }
            set { m_AverageDSVoltage = value; }
        }

        private double m_DSVoltagesSum;

        public double DSVoltagesSum
        {
            get { return m_DSVoltagesSum; }
            set { m_DSVoltagesSum = value; }
        }

        private double m_TresholdVoltage;

        public double TresholdVoltage
        {
            get { return m_TresholdVoltage; }
            set { m_TresholdVoltage = value; }
        }

        public List<Point> GetIVcurve()
        {
            var PointList = this.Select(x =>
            {
                return new Point(x.VoltageGate, x.Current);
            }).ToList();
            return PointList;
        }

    }
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
        private ConcurrentQueue<ExportDataContainer> m_queue;

        //private IVAnalysis m_ivAnalysis;

        public MainWindow()
        {
            InitializeComponent();

            
            m_ViewModel = new ViewModel(this);//m_core.CoreViewModel;
            this.DataContext = m_ViewModel;
            m_logControl = new LogControl();
            m_fitControl = new LinearFitControl.LinearFitControl();
            m_ViewModel.CurrentContent = m_logControl;
            m_fbd = new FolderBrowserDialog();
            m_ofd = new OpenFileDialog();
            m_queue = new ConcurrentQueue<ExportDataContainer>();
            m_fitControl.FittingDone += m_fitControl_FittingDone;

            m_worker = new BackgroundWorker();
            m_worker.WorkerReportsProgress = true;
            m_worker.WorkerSupportsCancellation = true;
            //m_worker.ProgressChanged += m_worker_ProgressChanged;
            //m_worker.RunWorkerCompleted += m_worker_RunWorkerCompleted;
            //m_worker.Disposed += m_worker_Disposed;
        }

        void m_fitControl_FittingDone(object sender, LinearFitControl.DoneLinearFittingEventArgs e)
        {
            ExportData(e.ZeroCrossingPointX);
            //ProcessNextDataSet();
        }

        

        
        
        private const string MeasureDataFilename = "MeasurData.dat";
        private const string MeasureDataExtendedFileName = "MeasurDataExtended.dat";
        private const double DrainSourceVoltageError = 0.005;
        private const char ValueCharSeparator = '\t';
        private string MeasurDataExtendedFN;


        private void WorkerReadFromFileToQueueCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_worker.DoWork -= WorkerReadFromFilrToQueue;
            m_worker.RunWorkerCompleted -= WorkerReadFromFileToQueueCompleted;
            ProcessNextDataSet();
        }
        void WorkerReadFromFilrToQueue(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            MeasurDataExtendedFN = String.Concat(m_ViewModel.WorkingDirectory, '\\', MeasureDataExtendedFileName);

            var HeaderStr = "";
            var UnitStr = "";

            if (!File.Exists(MeasurDataExtendedFN))
                return;
            using (StreamReader sr = new StreamReader(MeasurDataExtendedFN))
            {
                HeaderStr = sr.ReadLine();
                UnitStr = sr.ReadLine();
                ExportDataContainer CurrentList = new ExportDataContainer();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var strValues = line.Split(ValueCharSeparator);
                    var MeasurData = new MeasurDataExtendedLine(strValues);

                    if (CurrentList.Count == 0)//m_CurrentDSVoltageList.Count==0)
                    {
                        CurrentList.Add(MeasurData);
                    }
                    else
                    {
                        if (Math.Abs(MeasurData.USample - CurrentList.AverageDSVoltage) > DrainSourceVoltageError)//m_AverageDSVoltage) > DrainSourceVoltageError)
                        {
                            m_queue.Enqueue(CurrentList);
                            //OnDataReceived();
                            CurrentList = new ExportDataContainer();
                            CurrentList.Add(MeasurData);
                        }
                        else
                        {
                            CurrentList.Add(MeasurData);
                        }
                    }
                }
                if (CurrentList.Count > 0)
                    m_queue.Enqueue(CurrentList);

            }
        }

       

        private void ProcessNextDataSet()
        {
            if (m_fitControl.IsBusy)
                return;
            if (m_queue.Count == 0)
                return;
            var cont = new ExportDataContainer();
            while (!m_queue.TryPeek(out cont)) ;
            var ivCurve = cont.GetIVcurve();
            if (ivCurve.Count < 2)
            {
                ExportData(0);
                return;
            }
            m_fitControl.SetData(ivCurve);
            SwitchToFitView();
        }



        private void SwitchToFitView()
        {
            Dispatcher.Invoke(new Action(()=>{m_ViewModel.CurrentContent = m_fitControl;}));
            
        }
        private void SwitchToLogView()
        {
            m_ViewModel.CurrentContent = m_logControl;
        }
        private const string ExportFileName = "UltimateMeasurData.dat";
        void WorkerExportToFile(object sender, DoWorkEventArgs e)
        {
            double treshold = (double)e.Argument;
            ExportDataContainer cont;
            while (!m_queue.TryDequeue(out cont)) ;
            cont.TresholdVoltage = treshold;

            var saveDir = m_ViewModel.SaveDirectory;

            if (cont.Count > 1)
                saveDir = String.Concat(saveDir, "Vds=", cont.AverageDSVoltage);
            if (!Directory.Exists(saveDir))
                Directory.CreateDirectory(saveDir);

            var fn = String.Concat(saveDir, "\\", ExportFileName);
            bool FileExisted = false;
            if (File.Exists(fn))
                FileExisted = true; 
                
            using (StreamWriter str = new StreamWriter(new FileStream(fn, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None)))
            {
                if(!FileExisted)
                {
                    var a = new UltimateMeasurDataHeader();
                    str.WriteLine(a.HeaderString());
                    str.WriteLine(a.UnitString());
                }
                foreach (var item in cont)
                {
                    UltimateMeasureDataLine umdl = new UltimateMeasureDataLine(item);
                    umdl.TresholdVoltage = cont.TresholdVoltage;
                    umdl.OverdriveVoltage = umdl.VoltageGate - umdl.TresholdVoltage;
                    var OldDataFile = String.Concat(m_ViewModel.WorkingDirectory, "\\", umdl.FileName);
                    var NewDataFile = String.Concat(saveDir, "\\", "Extended", umdl.FileName);
                    List<UltimateDataFileLine> DataList = new List<UltimateDataFileLine>();
                    using (StreamReader rFileStr = new StreamReader(OldDataFile))
                    {
                        rFileStr.ReadLine();
                        rFileStr.ReadLine();
                        while (!rFileStr.EndOfStream)
                        {
                            var strValArr = rFileStr.ReadLine().Split(ValueCharSeparator);
                            var line = new UltimateDataFileLine(new DataFileLine(strValArr));
                            DataList.Add(line);
                        }
                    }
                    var transcond = Math.Sqrt(DataList.Where(x => x.Frequency == m_ViewModel.TransconductanceReferenceFrequency).Select(x => x.VoltageSpectralDensity).First() / m_ViewModel.TransconductanceReferenceValue);
                    foreach (var line in DataList)
                    {
                        line.CurrentSpectralDensity = line.VoltageSpectralDensity / (umdl.ResistanceEquivalent * umdl.ResistanceEquivalent);
                        line.CurrentSpectralDensityDivSqrI = line.CurrentSpectralDensity / (umdl.Current * umdl.Current);
                        line.EquivalentInputNoise = line.CurrentSpectralDensity / (transcond * transcond);
                    }
                    double[] xFreqArr = DataList.Select(x => Convert.ToDouble(x.Frequency)).ToArray();
                    double[] ySuArr = DataList.Select(x => x.EquivalentInputNoise).ToArray();
                    var interpolation = MathNet.Numerics.Interpolation.CubicSpline.InterpolateAkimaSorted(xFreqArr, ySuArr);
                    var SuIntegr = interpolation.Integrate(1, 10000);
                    //a.Integrate()
                    umdl.Gm = transcond;
                    umdl.SuIntegrated = SuIntegr;
                    umdl.SNR = 0.001 / Math.Sqrt(SuIntegr);


                    //MathNet.Numerics.Integrate.OnClosedInterval(new Func<double, double>(x=>), 1, 10000);
                    using (StreamWriter wFileStr = new StreamWriter(NewDataFile))
                    {
                        var header = new UltimateDataFileHeader();
                        wFileStr.WriteLine(header.HeaderString());
                        wFileStr.WriteLine(header.UnitString());
                        foreach (var line in DataList)
                        {
                            wFileStr.WriteLine(line.ToString());
                        }
                    }

                    str.WriteLine(umdl.ToString());
                    //UltimateDataFileLine uddl = new UltimateDataFileLine()
                }
            }

            //blabla
        }
        void WorkerExportToFileCompleted(object sender,RunWorkerCompletedEventArgs e)
        {
            m_worker.DoWork -= WorkerExportToFile;
            m_worker.RunWorkerCompleted -= WorkerExportToFileCompleted;
            ProcessNextDataSet();
        }
        
        private void ExportData(double Threshold)
        {
            SwitchToLogView();
            while (m_worker.IsBusy) ;
            m_worker.DoWork += WorkerExportToFile;
            m_worker.RunWorkerCompleted += WorkerExportToFileCompleted;
            m_worker.RunWorkerAsync(Threshold);
         //   throw new NotImplementedException();
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
                using(StreamReader sr = new StreamReader(m_ViewModel.TransconductanceReferenceFile))
                {
                    while(!sr.EndOfStream)
                    {
                        var line = new DataFileLine(sr.ReadLine().Split('\t'));
                        if (line.Frequency == m_ViewModel.TransconductanceReferenceFrequency)
                        {
                            m_ViewModel.TransconductanceReferenceValue = line.VoltageSpectralDensity;
                            return;
                        }
                    }
                }
            }
        }

        private void ProcessData(object sender, System.Windows.RoutedEventArgs e)
        {
            m_worker.DoWork += WorkerReadFromFilrToQueue;
            m_worker.RunWorkerCompleted += WorkerReadFromFileToQueueCompleted;
            m_worker.RunWorkerAsync();
        }

        

        

    }
}
