using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseDataExporter.DataModel
{
    public class MeasurDataLine
    {
        public MeasurDataLine(string DataString)
        {

        }

        private double m_USample;
        public double USample
        {
            get { return m_USample; }
            set { m_USample = value; }
        }

        private double m_Current;

        public double Current
        {
            get { return m_Current; }
            set { m_Current = value; }
        }

        private double m_Req;

        public double ResistanceEquivalent
        {
            get { return m_Req; }
            set { m_Req = value; }
        }

        private string m_filename;

        public string FileName
        {
            get { return m_filename; }
            set { m_filename = value; }
        }

        private double m_Rload;

        public double Rload
        {
            get { return m_Rload; }
            set { m_Rload = value; }
        }

        private double m_Uwhole;

        public double Uwhole
        {
            get { return m_Uwhole; }
            set { m_Uwhole = value; }
        }

        private double m_U0sample;

        public double U0Sample
        {
            get { return m_U0sample; }
            set { m_U0sample = value; }
        }

        private double m_U0whole;

        public double U0whole
        {
            get { return m_U0whole; }
            set { m_U0whole = value; }
        }

        private double m_R0sample;

        public double R0sample
        {
            get { return m_R0sample; }
            set { m_R0sample = value; }
        }

        private double m_Resample;

        public double Resample
        {
            get { return m_Resample; }
            set { m_Resample = value; }
        }

        private double m_temp0;

        public double Temperature0
        {
            get { return m_temp0; }
            set { m_temp0 = value; }
        }

        private double m_tempE;

        public double TemperatureE
        {
            get { return m_tempE; }
            set { m_tempE = value; }
        }

        private long m_Kampl;

        public long AmplificationFactor
        {
            get { return m_Kampl; }
            set { m_Kampl = value; }
        }

        private long m_NAver;

        public long AverageNumber
        {
            get { return m_NAver; }
            set { m_NAver = value; }
        }

        private double m_Vgate;

        public double VoltageGate
        {
            get { return m_Vgate; }
            set { m_Vgate = value; }
        }



    }
}
