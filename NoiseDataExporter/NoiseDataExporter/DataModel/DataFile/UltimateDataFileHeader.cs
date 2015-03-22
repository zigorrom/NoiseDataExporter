using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseDataExporter.DataModel
{
    class UltimateDataFileHeader:DataFileHeader
    {
        public const int SiIndex = 2;
        public const int SiDivSqrI = 3;
        public const int SuIndex = 4;

        private const string StrFormat = "{0}\t{1}\t{2}\t{3}";
        public override string HeaderString()
        {
            return String.Format(StrFormat, base.HeaderString(), "Si", "Si/I^2", "Su");
        }
        public override string UnitString()
        {
            return String.Format(StrFormat, base.UnitString(), "A^2/Hz", "Hz^-1", "V^2");
        }
        
    }
}
