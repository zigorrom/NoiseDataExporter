using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                    OnPropertyChanged("WorkingDirectory");
                }
            }
        }

        private string m_TransconductanceReferenceFile;

        public string TransconductanceReferenceFile
        {
            get { return m_TransconductanceReferenceFile; }
            set { 
                m_TransconductanceReferenceFile = value; 
            }
        }

        private int m_TransconductanceReferenceFrequency;

        public int TransconductanceReferenceFrequency
        {
            get { return m_TransconductanceReferenceFrequency; }
            set { m_TransconductanceReferenceFrequency = value; }
        }

        private double m_TransconductanceReferenceValue;

        public double TransconductanceReferenceValue
        {
            get { return m_TransconductanceReferenceValue; }
            set { m_TransconductanceReferenceValue = value; }
        }



    }
}
