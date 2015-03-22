using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseDataExporter.DataModel
{
    class UltimateMeasurDataHeader : MeasurDataExtendedHeader
    {


        public const int gmIndex = 29;
        public const int SuIntegratedIndex = 30;
        public const int SNRIndex = 31;
        public const int TresholdVoltageIndex = 32;
        public const int OverdriveVoltage = 33;

        public const string StrFormat = "{0}\t{1}\t{2}\t{3}\t{4}\t{5}";
        public override string HeaderString()
        {
            return String.Format(StrFormat,
                base.HeaderString(),
                "gm",
                "Su",
                "SNR",
                "Treshold Voltage",
                "OverdriveVoltage"
                );
        }
        public override string UnitString()
        {
            return String.Format(StrFormat,
                base.UnitString(),
                "1/\\g(W)",
                "V",
                "",
                "V",
                "V"
                );

        }
    }
}
