using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseDataExporter.DataModel
{
    public class MeasurDataLine
    {
        public MeasurDataLine()
        {

        }

        public MeasurDataLine(string[] DataStrArray)
        {
            InitData(DataStrArray);
        }

        public MeasurDataLine(double Usample, double Current, double Req, string FileName, double Rload, double Uwhole, double U0Sample, double U0whole, double R0sample, double Resample, double Temperature0, double TempleratureE, int AmplificationFactor, int AverageNumber, double VoltageGate)
        {
            InitData(Usample, Current, Req, FileName, Rload, Uwhole, U0Sample, U0whole, R0sample, Resample, Temperature0, TempleratureE, AmplificationFactor, AverageNumber, VoltageGate);
        }
        protected MeasurDataLine(MeasurDataLine Data)
        {
            InitData(
                Data.USample,
                Data.Current,
                Data.ResistanceEquivalent,
                Data.FileName,
                Data.Rload,
                Data.Uwhole,
                Data.U0Sample,
                Data.U0whole,
                Data.R0sample,
                Data.Resample,
                Data.Temperature0,
                Data.TemperatureE,
                Data.AmplificationFactor,
                Data.AverageNumber,
                Data.VoltageGate);
        }

        private void InitData(double Usample, double Current, double Req, string FileName, double Rload, double Uwhole, double U0Sample, double U0whole, double R0sample, double Resample, double Temperature0, double TempleratureE, int AmplificationFactor, int AverageNumber, double VoltageGate)
        {
            m_USample = Usample;
            m_Current = Current;
            m_Req = Req;
            m_filename = FileName;
            m_Rload = Rload;
            m_Uwhole = Uwhole;
            m_U0sample = U0Sample;
            m_U0whole = U0whole;
            m_R0sample = R0sample;
            m_Resample = Resample;
            m_temp0 = Temperature0;
            m_tempE = TempleratureE;
            m_Kampl = AmplificationFactor;
            m_NAver = AverageNumber;
            m_Vgate = VoltageGate;
        }

        //internal virtual bool ParseString(string str, out double value)
        //{
        //    //value = 0;
        //    return double.TryParse(str, NumberStyles.Float, new NumberFormatInfo() { NumberDecimalSeparator=".", NumberGroupSeparator = "" }, out value);
        //    //var result = double.Parse(str, System.Globalization.NumberStyles.Float, new NumberFormatInfo() { CurrencyDecimalSeparator = ".", CurrencyGroupSeparator = "" });
        //    //return result;
        //}

        //internal virtual bool ParseString(string str, out int value)
        //{
        //    return int.TryParse(str, NumberStyles.Float, new NumberFormatInfo() { NumberDecimalSeparator=".", NumberGroupSeparator = "" }, out value);
        //}

        public double DoubleFromString(string str)
        {
            return double.Parse(str, NumberStyles.Float, new NumberFormatInfo() { NumberDecimalSeparator = ".", NumberGroupSeparator = "" });
        }

        public int IntFromString(string str)
        {
            return int.Parse(str, NumberStyles.Float, new NumberFormatInfo() { NumberDecimalSeparator = ".", NumberGroupSeparator = "" });
        }
        private void InitData(string[] DataStrArray)
        {
            var StrDataArray = DataStrArray;
            try
            {
                USample = DoubleFromString(StrDataArray[MeasurDataHeader.USampleIndex]);//double.Parse(StrDataArray[MeasurDataHeader.USampleIndex]);
                Current = DoubleFromString(StrDataArray[MeasurDataHeader.CurrentIndex]);
                ResistanceEquivalent = DoubleFromString(StrDataArray[MeasurDataHeader.ReqIndex]);
                FileName = StrDataArray[MeasurDataHeader.FileNameIndex];
                Rload = DoubleFromString(StrDataArray[MeasurDataHeader.RloadIndex]);
                Uwhole = DoubleFromString(StrDataArray[MeasurDataHeader.UwholeIndex]);
                U0Sample = DoubleFromString(StrDataArray[MeasurDataHeader.U0sampleIndex]);
                U0whole = DoubleFromString(StrDataArray[MeasurDataHeader.U0wholeIndex]);
                R0sample = DoubleFromString(StrDataArray[MeasurDataHeader.R0sampleIndex]);
                Resample = DoubleFromString(StrDataArray[MeasurDataHeader.ResampleIndex]);
                Temperature0 = DoubleFromString(StrDataArray[MeasurDataHeader.Temperature0Index]);
                TemperatureE = DoubleFromString(StrDataArray[MeasurDataHeader.TemperatureEIndex]);
                AmplificationFactor = IntFromString(StrDataArray[MeasurDataHeader.KamplIndex]);
                AverageNumber = IntFromString(StrDataArray[MeasurDataHeader.NaverIndex]);
                VoltageGate = DoubleFromString(StrDataArray[MeasurDataHeader.VGateIndex]);
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
