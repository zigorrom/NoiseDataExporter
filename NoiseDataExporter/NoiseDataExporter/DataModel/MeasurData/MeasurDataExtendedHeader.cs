using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseDataExporter.DataModel
{
    public class MeasurDataExtendedHeader:MeasurDataHeader
    {
        public const int GR1Si0Index = 15;
        public const int GR1f0Index = 16;

        public const int GR2Si0Index = 17;
        public const int GR2f0Index = 18;

        public const int GR3Si0Index = 19;
        public const int GR3f0Index = 20;

        public const int GR4Si0Index = 21;
        public const int GR4f0Index = 22;

        public const int GR5Si0Index = 23;
        public const int GR5f0Index = 24;

        public const int AflickerIndex = 25;
        public const int AlphaFlickerIndex = 26;
        public const int fSiFlicker = 27;
        public const int fSiFlickerDivSqrI = 28;

        public MeasurDataExtendedHeader()
        {

        }
    }
}
