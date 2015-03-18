using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseDataExporter
{
    public class ViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string PropertyName)
        {
            if (null != PropertyChanged)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        private string m_WorkingDirectory;

        public string WorkingDirectory
        {
            get { return m_WorkingDirectory; }
            set {
                if (m_WorkingDirectory != value)
                {
                    m_WorkingDirectory = value;
                    var dir = new DirectoryInfo(m_WorkingDirectory);
                    m_SaveDirectory = String.Concat(dir.Parent.FullName, "\\", dir.Name, "Extended");
                    
                    OnPropertyChanged("WorkingDirectory");
                }
            }
        }

        private string m_SaveDirectory;

        public string SaveDirectory
        {
            get { return m_SaveDirectory; }
            set
            {
                if (m_SaveDirectory != value)
                {
                    m_SaveDirectory = value;
                    OnPropertyChanged("SaveDirectory");
                }
            }
        }


        private string m_TransconductanceReferenceFile;

        public string TransconductanceReferenceFile
        {
            get { return m_TransconductanceReferenceFile; }
            set {
                if (m_TransconductanceReferenceFile != value)
                {
                    m_TransconductanceReferenceFile = value;
                    OnPropertyChanged("TransconductanceReferenceFile");
                }
            }
        }

        private int m_TransconductanceReferenceFrequency;

        public int TransconductanceReferenceFrequency
        {
            get { return m_TransconductanceReferenceFrequency; }
            set
            {
                if (m_TransconductanceReferenceFrequency != value)
                {
                    m_TransconductanceReferenceFrequency = value;
                    OnPropertyChanged("TransconductanceReferenceFrequency");
                }
            }
        }

        private double m_TransconductanceReferenceValue;

        public double TransconductanceReferenceValue
        {
            get { return m_TransconductanceReferenceValue; }
            set
            {
                if (m_TransconductanceReferenceValue != value)
                {
                    m_TransconductanceReferenceValue = value;
                    OnPropertyChanged("TransconductanceReferenceValue");
                }
            }
        }



    }
}
