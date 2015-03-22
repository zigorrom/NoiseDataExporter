using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseDataExporter.DataModel
{
    public class DataFileHeader
    {
        public const int FrequencyIndex = 0;
        public const int VoltageSpectralDensityIndex = 1;

        private const string StrFormat = "{0}\t{1}";
        public virtual string HeaderString()
        {
            return String.Format(StrFormat, "Frequency", "Sv");
        }

        public virtual string UnitString()
        {
            return String.Format(StrFormat, "Hz", "V^2/Hz");
        }

    }
}
