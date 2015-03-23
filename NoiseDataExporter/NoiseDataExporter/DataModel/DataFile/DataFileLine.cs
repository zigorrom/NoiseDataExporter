using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseDataExporter.DataModel
{
    public class DataFileLine
    {

        public DataFileLine(int frequency,double sv)
        {
            Frequency = frequency;
            VoltageSpectralDensity = sv;
        }
        public DataFileLine(string[] DataStrArray)
        {
            InitData(DataStrArray);
        }

        public override string ToString()
        {
            return String.Format(new NumberFormatInfo() { NumberDecimalSeparator ="." ,NumberGroupSeparator=""},"{0}\t{1}", Frequency, VoltageSpectralDensity);
        }

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
            try
            {
                Frequency = IntFromString(DataStrArray[DataFileHeader.FrequencyIndex]);
                VoltageSpectralDensity = DoubleFromString(DataStrArray[DataFileHeader.VoltageSpectralDensityIndex]);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        private int m_frequency;

        public int Frequency
        {
            get { return m_frequency; }
            set { m_frequency = value; }
        }

        private double m_Sv;

        public double VoltageSpectralDensity
        {
            get { return m_Sv; }
            set { m_Sv = value; }
        }

    }

}
