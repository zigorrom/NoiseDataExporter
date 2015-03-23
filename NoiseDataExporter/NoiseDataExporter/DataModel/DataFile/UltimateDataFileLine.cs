using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseDataExporter.DataModel
{
    public class UltimateDataFileLine:DataFileLine
    {
        public UltimateDataFileLine(DataFileLine line ):base(line.Frequency,line.VoltageSpectralDensity)
        {
            CurrentSpectralDensity = 0;
            CurrentSpectralDensityDivSqrI = 0;
            EquivalentInputNoise = 0;
        }
        public UltimateDataFileLine(int Frequency,double Sv,double Si, double SiDivSqrI, double Su):base(Frequency,Sv)
        {
            CurrentSpectralDensity = Si;
            CurrentSpectralDensityDivSqrI = SiDivSqrI;
            EquivalentInputNoise = Su;
        }

        public UltimateDataFileLine(string[] DataStrArray):base(DataStrArray)
        {
            InitData(DataStrArray);
        }
        
        
        public override string ToString()
        {
            const string StringFormat = "{0}\t{1}\t{2}\t{3}";
            return string.Format(new NumberFormatInfo() { NumberDecimalSeparator ="." ,NumberGroupSeparator=""}, StringFormat,
                base.ToString(),
                CurrentSpectralDensity,
                CurrentSpectralDensityDivSqrI,
                EquivalentInputNoise
                );
        }

        private void InitData(string[] DataStrArray)
        {
            try
            {
                CurrentSpectralDensity = DoubleFromString(DataStrArray[UltimateDataFileHeader.SiIndex]);
                CurrentSpectralDensityDivSqrI = DoubleFromString(DataStrArray[UltimateDataFileHeader.SiDivSqrI]);
                EquivalentInputNoise = DoubleFromString(DataStrArray[UltimateDataFileHeader.SuIndex]);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private double m_Si;

        public double CurrentSpectralDensity
        {
            get { return m_Si; }
            set { m_Si = value; }
        }

        private double m_SiDivSqrI;

        public double CurrentSpectralDensityDivSqrI
        {
            get { return m_SiDivSqrI; }
            set { m_SiDivSqrI = value; }
        }

        private double m_Su;

        public double EquivalentInputNoise
        {
            get { return m_Su; }
            set { m_Su = value; }
        }


    }
}
