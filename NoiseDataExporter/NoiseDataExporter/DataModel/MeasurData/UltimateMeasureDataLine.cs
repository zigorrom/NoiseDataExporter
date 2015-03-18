using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseDataExporter.DataModel
{
    public class UltimateMeasureDataLine:MeasurDataExtendedLine
    {
        public UltimateMeasureDataLine(string[] DataSrtArray):base(DataSrtArray)
        {
            InitData(DataSrtArray);
        }

        public override string ToString()
        {
            const string StringFormat = "{0}\t{1}\t{2}\t{3}\t{4}\t{5}";
            return String.Format(StringFormat,
                base.ToString(),
                Gm,
                SuIntegrated,
                SNR,
                TresholdVoltage,
                OverdriveVoltage
                );
        }

        private void InitData(string[] DataStrArray)
        {
            try
            {
                Gm = double.Parse(DataStrArray[UltimateMeasurDataHeader.gmIndex]);
                SuIntegrated = double.Parse(DataStrArray[UltimateMeasurDataHeader.SuIntegratedIndex]);
                SNR = double.Parse(DataStrArray[UltimateMeasurDataHeader.SNRIndex]);
                TresholdVoltage = double.Parse(DataStrArray[UltimateMeasurDataHeader.TresholdVoltageIndex]);
                OverdriveVoltage = double.Parse(DataStrArray[UltimateMeasurDataHeader.OverdriveVoltage]);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        private double m_gm;

        public double Gm
        {
            get { return m_gm; }
            set { m_gm = value; }
        }

        private double m_SuIntegrated;

        public double SuIntegrated
        {
            get { return m_SuIntegrated; }
            set { m_SuIntegrated = value; }
        }

        private double m_SNR;

        public double SNR
        {
            get { return m_SNR; }
            set { m_SNR = value; }
        }

        private double m_TresholdVoltage;

        public double TresholdVoltage
        {
            get { return m_TresholdVoltage; }
            set { m_TresholdVoltage = value; }
        }

        private double m_OverdriveVoltage;

        public double OverdriveVoltage
        {
            get { return m_OverdriveVoltage; }
            set { m_OverdriveVoltage = value; }
        }

    }
}
