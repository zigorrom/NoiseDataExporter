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

        private const string StrFormat = "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}";

        public override string HeaderString()
        {
            return String.Format(
                StrFormat,
                base.HeaderString(),
                "GR1 S\\-(I)(0)",
                "GR1 f\\-(0)",
                "GR2 S\\-(I)(0)",
                "GR2 f\\-(0)",
                "GR3 S\\-(I)(0)",
                "GR3 f\\-(0)",
                "GR4 S\\-(I)(0)",
                "GR4 f\\-(0)",
                "GR5 S\\-(I)(0)",
                "GR5 f\\-(0)",
                "A\\-(flicker)",
                "AlphaFlicker",
                "fS\\=(I,Flicker)",
                "fS\\=(I,Flicker)/I\\+(2)"
                );
        }
        public override string UnitString()
        {

            return String.Format(StrFormat,
                base.UnitString(),
                "A\\+(2)/Hz",
                "Hz",
                "A\\+(2)/Hz",
                "Hz",
                "A\\+(2)/Hz",
                "Hz",
                "A\\+(2)/Hz",
                "Hz",
                "A\\+(2)/Hz",
                "Hz",
                "V\\+(2)",
                "",
                "A\\+(2)",
                ""
                );
        }

        public MeasurDataExtendedHeader()
        {

        }
    }
}
