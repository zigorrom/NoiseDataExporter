﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseDataExporter.DataModel
{
    public class MeasurDataExtendedLine:MeasurDataLine
    {
        public MeasurDataExtendedLine(string[] DataStrArray):base(DataStrArray)
        {
            InitData(DataStrArray);
        }
        
        public MeasurDataExtendedLine            (            MeasurDataExtendedLine MeasurDataExtended            ):base(
            MeasurDataExtended.USample,
            MeasurDataExtended.Current,
            MeasurDataExtended.ResistanceEquivalent,
            MeasurDataExtended.FileName,
            MeasurDataExtended.Rload,
            MeasurDataExtended.Uwhole,
            MeasurDataExtended.U0Sample,
            MeasurDataExtended.U0whole,
            MeasurDataExtended.R0sample,
            MeasurDataExtended.Resample,
            MeasurDataExtended.Temperature0,
            MeasurDataExtended.TemperatureE,
            MeasurDataExtended.AmplificationFactor,
            MeasurDataExtended.AverageNumber,
            MeasurDataExtended.VoltageGate)
        {
            InitData(MeasurDataExtended.GR1Si, MeasurDataExtended.GR1f, MeasurDataExtended.GR2Si, MeasurDataExtended.GR2f, MeasurDataExtended.GR3Si, MeasurDataExtended.GR3f, MeasurDataExtended.GR4Si, MeasurDataExtended.GR4f, MeasurDataExtended.GR5Si, MeasurDataExtended.GR5f, MeasurDataExtended.AFlicker, MeasurDataExtended.AlphaFlicker, MeasurDataExtended.fSiFlicker, MeasurDataExtended.fSiFlickerDivSqrI);
        }
        public MeasurDataExtendedLine(
            MeasurDataLine MeasurData,
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
            double fSiFlickerDivSqrI
            ):base(MeasurData)
        {
            InitData(GR1Si, GR1f, GR2Si, GR2f, GR3Si, GR3f, GR4Si, GR4f, GR5Si, GR5f, AFlicker, AlphaFlicker, fSiFlicker, fSiFlickerDivSqrI);
        }

        public MeasurDataExtendedLine(
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
            double fSiFlickerDivSqrI)
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
                VoltageGate)
        {
            InitData(GR1Si, GR1f, GR2Si, GR2f, GR3Si, GR3f, GR4Si, GR4f, GR5Si, GR5f, AFlicker, AlphaFlicker, fSiFlicker, fSiFlickerDivSqrI);
        }

        
        private void InitData(string[] DataStrArray)
        {

            try
            {
                GR1f = DoubleFromString(DataStrArray[MeasurDataExtendedHeader.GR1f0Index]);
                GR1Si = DoubleFromString(DataStrArray[MeasurDataExtendedHeader.GR1Si0Index]);
                GR2f = DoubleFromString(DataStrArray[MeasurDataExtendedHeader.GR2f0Index]);
                GR2Si = DoubleFromString(DataStrArray[MeasurDataExtendedHeader.GR2Si0Index]);
                GR3f = DoubleFromString(DataStrArray[MeasurDataExtendedHeader.GR3f0Index]);
                GR3Si = DoubleFromString(DataStrArray[MeasurDataExtendedHeader.GR3Si0Index]);
                GR4f = DoubleFromString(DataStrArray[MeasurDataExtendedHeader.GR4f0Index]);
                GR4Si = DoubleFromString(DataStrArray[MeasurDataExtendedHeader.GR4Si0Index]);
                GR5f = DoubleFromString(DataStrArray[MeasurDataExtendedHeader.GR5f0Index]);
                GR5Si = DoubleFromString(DataStrArray[MeasurDataExtendedHeader.GR5Si0Index]);
                AFlicker = DoubleFromString(DataStrArray[MeasurDataExtendedHeader.AflickerIndex]);
                AlphaFlicker = DoubleFromString(DataStrArray[MeasurDataExtendedHeader.AlphaFlickerIndex]);
                fSiFlicker = DoubleFromString(DataStrArray[MeasurDataExtendedHeader.fSiFlicker]);
                fSiFlickerDivSqrI = DoubleFromString(DataStrArray[MeasurDataExtendedHeader.fSiFlickerDivSqrI]);
            }

            catch (Exception e)
            {

                throw;
            }

        }

        private void InitData(double GR1Si, double GR1f, double GR2Si, double GR2f, double GR3Si, double GR3f, double GR4Si, double GR4f, double GR5Si, double GR5f, double AFlicker, double AlphaFlicker, double fSiFlicker, double fSiFlickerDivSqrI)
        {
            m_gr1f = GR1f;
            m_gr2f = GR2f;
            m_gr3f = GR3f;
            m_gr4f = GR4f;
            m_gr5f = GR5f;
            m_gr1Si = GR1Si;
            m_gr2Si = GR2Si;
            m_gr3Si = GR3Si;
            m_gr4Si = GR4Si;
            m_gr5Si = GR5Si;
            m_Aflicker = AFlicker;
            m_Alphaflicker = AlphaFlicker;
            m_fSiFlicker = fSiFlicker;
            m_fSiFlickerDivSqrI = fSiFlickerDivSqrI;
        }
        public override string ToString()
        {
            string StringFormat = "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}";
            return String.Format(new NumberFormatInfo() { NumberDecimalSeparator ="." ,NumberGroupSeparator=""},
                StringFormat,
                base.ToString(),
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
                fSiFlickerDivSqrI
                );
        }

       

        private double m_gr1Si;
        public double GR1Si
        {
            get { return m_gr1Si; }
            set { m_gr1Si = value; }
        }

        private double m_gr2Si;
        public double GR2Si
        {
            get { return m_gr2Si; }
            set { m_gr2Si = value; }
        }

        private double m_gr3Si;
        public double GR3Si
        {
            get { return m_gr3Si; }
            set { m_gr3Si = value; }
        }

        private double m_gr4Si;
        public double GR4Si
        {
            get { return m_gr4Si; }
            set { m_gr4Si = value; }
        }

        private double m_gr5Si;
        public double GR5Si
        {
            get { return m_gr5Si; }
            set { m_gr5Si = value; }
        }

        private double m_gr1f;
        public double GR1f
        {
            get { return m_gr1f; }
            set { m_gr1f = value; }
        }

        private double m_gr2f;
        public double GR2f
        {
            get { return m_gr2f; }
            set { m_gr2f = value; }
        }

        private double m_gr3f;
        public double GR3f
        {
            get { return m_gr3f; }
            set { m_gr3f = value; }
        }

        private double m_gr4f;
        public double GR4f
        {
            get { return m_gr4f; }
            set { m_gr4f = value; }
        }

        private double m_gr5f;
        public double GR5f
        {
            get { return m_gr5f; }
            set { m_gr5f = value; }
        }

        private double m_Aflicker;
        public double AFlicker
        {
            get { return m_Aflicker; }
            set { m_Aflicker = value; }
        }

        private double m_Alphaflicker;
        public double AlphaFlicker
        {
            get { return m_Alphaflicker; }
            set { m_Alphaflicker = value; }
        }

        private double m_fSiFlicker;
        public double fSiFlicker
        {
            get { return m_fSiFlicker; }
            set { m_fSiFlicker = value; }
        }

        private double m_fSiFlickerDivSqrI;
        public double fSiFlickerDivSqrI
        {
            get { return m_fSiFlickerDivSqrI; }
            set { m_fSiFlickerDivSqrI = value; }
        }


    }
}
