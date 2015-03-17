﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public override string ToString()
        {
            string StringFormat = "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}";
            return String.Format(StringFormat,
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
                fSiFlickerDivSqrI,
                base.ToString()
                );
        }

        private void InitData(string[] DataStrArray)
        {

            try
            {
                GR1f = double.Parse(DataStrArray[MeasurDataExtendedHeader.GR1f0Index]);
                GR1Si = double.Parse(DataStrArray[MeasurDataExtendedHeader.GR1Si0Index]);
                GR2f = double.Parse(DataStrArray[MeasurDataExtendedHeader.GR2f0Index]);
                GR2Si = double.Parse(DataStrArray[MeasurDataExtendedHeader.GR2Si0Index]);
                GR3f = double.Parse(DataStrArray[MeasurDataExtendedHeader.GR3f0Index]);
                GR3Si = double.Parse(DataStrArray[MeasurDataExtendedHeader.GR3Si0Index]);
                GR4f = double.Parse(DataStrArray[MeasurDataExtendedHeader.GR4f0Index]);
                GR4Si = double.Parse(DataStrArray[MeasurDataExtendedHeader.GR4Si0Index]);
                GR5f = double.Parse(DataStrArray[MeasurDataExtendedHeader.GR5f0Index]);
                GR5Si = double.Parse(DataStrArray[MeasurDataExtendedHeader.GR5Si0Index]);
                AFlicker = double.Parse(DataStrArray[MeasurDataExtendedHeader.AflickerIndex]);
                AlphaFlicker = double.Parse(DataStrArray[MeasurDataExtendedHeader.AlphaFlickerIndex]);
                fSiFlicker = double.Parse(DataStrArray[MeasurDataExtendedHeader.fSiFlicker]);
                fSiFlickerDivSqrI = double.Parse(DataStrArray[MeasurDataExtendedHeader.fSiFlickerDivSqrI]);
            }
            
            catch (Exception e)
            {

                throw;
            }

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
