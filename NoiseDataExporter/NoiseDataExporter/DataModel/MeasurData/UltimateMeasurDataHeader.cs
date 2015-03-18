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
    }
}
