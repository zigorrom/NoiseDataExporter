using System;
using System.Collections.Generic;
using System.Globalization;
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

        public UltimateMeasureDataLine(MeasurDataExtendedLine Data)
            : base(
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
                Data.VoltageGate,
                Data.GR1Si,
                Data.GR1f,
                Data.GR2Si,
                Data.GR2f,
                Data.GR3Si,
                Data.GR3f,
                Data.GR4Si,
                Data.GR4f,
                Data.GR5Si,
                Data.GR5f,
                Data.AFlicker,
                Data.AlphaFlicker,
                Data.fSiFlicker,
                Data.fSiFlickerDivSqrI
                )
        {
             Gm = 0;
             SuIntegrated = 0;
             SNR=0;
             TresholdVoltage = 0;
             OverdriveVoltage = 0;
            //InitData(GmReference, TresholdVoltage);
        }

        private void InitData(double GmReference, double TresholdVoltage)
        {
            throw new NotImplementedException();
        }

        public UltimateMeasureDataLine(
            double Usample,
            double Current,
            double Req,
            string FileName,
            double Rload,
            double Uwhole,
            double U0Sample,
            double U0whole,
            double R0sample,
            double Resample,
            double Temperature0,
            double TempleratureE,
            int AmplificationFactor,
            int AverageNumber,
            double VoltageGate,
            double GR1Si,
            double GR1f,
            double GR2Si,
            double GR2f,
            double GR3Si,
            double GR3f,
            double GR4Si,
            double GR4f,
            double GR5Si,
            double GR5f,
            double AFlicker,
            double AlphaFlicker,
            double fSiFlicker,
            double fSiFlickerDivSqrI,
            double Gm,
            double SuIntegrated,
            double SNR,
            double TresholdVoltage,
            double OverdriveVoltage)
            : base(
                Usample,
                Current,
                Req,
                FileName,
                Rload,
                Uwhole,
                U0Sample,
                U0whole,
                R0sample,
                Resample,
                Temperature0,
                TempleratureE,
                AmplificationFactor,
                AverageNumber,
                VoltageGate,
                GR1Si,
                GR1f,
                GR2Si,
                GR2f,
                GR3Si,
                GR3f,
                GR4Si,
                GR4f,
                GR5Si,
                GR5f,
                AFlicker,
                AlphaFlicker,
                fSiFlicker,
                fSiFlickerDivSqrI)
        {

        }
        public override string ToString()
        {
            const string StringFormat = "{0}\t{1}\t{2}\t{3}\t{4}\t{5}";
            return String.Format(new NumberFormatInfo() { NumberDecimalSeparator ="." ,NumberGroupSeparator=""},
                StringFormat,
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
                Gm = DoubleFromString(DataStrArray[UltimateMeasurDataHeader.gmIndex]);
                SuIntegrated = DoubleFromString(DataStrArray[UltimateMeasurDataHeader.SuIntegratedIndex]);
                SNR = DoubleFromString(DataStrArray[UltimateMeasurDataHeader.SNRIndex]);
                TresholdVoltage = DoubleFromString(DataStrArray[UltimateMeasurDataHeader.TresholdVoltageIndex]);
                OverdriveVoltage = DoubleFromString(DataStrArray[UltimateMeasurDataHeader.OverdriveVoltage]);
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
