using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseDataExporter.DataModel
{
    public class MeasurDataHeader
    {
        public const int USampleIndex = 0;
        public const int CurrentIndex = 1;
        public const int ReqIndex = 2;
        public const int FileNameIndex = 3;
        public const int RloadIndex = 4;
        public const int UwholeIndex = 5;
        public const int U0sampleIndex = 6;
        public const int U0wholeIndex = 7;
        public const int R0sampleIndex = 8;
        public const int ResampleIndex = 9;
        public const int Temperature0Index = 10;
        public const int TemperatureEIndex = 11;
        public const int KamplIndex = 12;
        public const int NaverIndex = 13;
        public const int VGateIndex = 14;
        public const string StrFormat = "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}";

        public virtual string HeaderString()
        {
            return String.Format(
                StrFormat,
                "U\\-(sample)",
                "Current",
                "R\\-(Eq)",
                "Filename",
                "R\\-(load)",
                "U\\-(Whole)",
                "U\\-(0sample)",
                "U\\-(0Whole)",
                "R\\-(0sample)",
                "R\\-(Esample)",
                "Temperature\\-(0)",
                "Temperature\\-(E)",
                "k\\-(ampl)",
                "N\\-(aver)",
                "V\\-(Gate)"
                );
        }
        public virtual string UnitString()
        {
            return String.Format(
                StrFormat,
                "V",
                "A",
                "\\g(W)",
                "",
                "\\g(W)",
                "V",
                "V",
                "V",
                "\\g(W)",
                "\\g(W)",
                "K",
                "K",
                "",
                "",
                "V"
                );
        }
    }
    
}
