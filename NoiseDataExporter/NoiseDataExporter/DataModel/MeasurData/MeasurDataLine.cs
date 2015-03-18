using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseDataExporter.DataModel
{
    public class MeasurDataLine
    {
        public MeasurDataLine(string[] DataStrArray)
        {
            InitData(DataStrArray);
        }


        private void InitData(string[] DataStrArray)
        {
            var StrDataArray = DataStrArray;
            try
            {
                USample = double.Parse(StrDataArray[MeasurDataHeader.USampleIndex]);
                Current = double.Parse(StrDataArray[MeasurDataHeader.CurrentIndex]);
                ResistanceEquivalent = double.Parse(StrDataArray[MeasurDataHeader.ReqIndex]);
                FileName = StrDataArray[MeasurDataHeader.FileNameIndex];
                Rload = double.Parse(StrDataArray[MeasurDataHeader.RloadIndex]);
                Uwhole = double.Parse(StrDataArray[MeasurDataHeader.UwholeIndex]);
                U0Sample = double.Parse(StrDataArray[MeasurDataHeader.U0sampleIndex]);
                U0whole = double.Parse(StrDataArray[MeasurDataHeader.U0wholeIndex]);
                R0sample = double.Parse(StrDataArray[MeasurDataHeader.R0sampleIndex]);
                Resample = double.Parse(StrDataArray[MeasurDataHeader.ResampleIndex]);
                Temperature0 = double.Parse(StrDataArray[MeasurDataHeader.Temperature0Index]);
                TemperatureE = double.Parse(StrDataArray[MeasurDataHeader.TemperatureEIndex]);
                AmplificationFactor = int.Parse(StrDataArray[MeasurDataHeader.KamplIndex]);
                AverageNumber = int.Parse(StrDataArray[MeasurDataHeader.NaverIndex]);
                VoltageGate = double.Parse(StrDataArray[MeasurDataHeader.VGateIndex]);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public override string ToString()
        {
            const string StringFormat = "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}";
            return String.Format(StringFormat,
                USample,
                Current,
                ResistanceEquivalent,
                FileName,
                Rload,
                Uwhole,
                U0Sample,
                U0whole,
                R0sample,
                Resample,
                Temperature0,
                TemperatureE,
                AmplificationFactor,
                AverageNumber,
                VoltageGate
                );
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

        private int m_Kampl;

        public int AmplificationFactor
        {
            get { return m_Kampl; }
            set { m_Kampl = value; }
        }

        private int m_NAver;

        public int AverageNumber
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
