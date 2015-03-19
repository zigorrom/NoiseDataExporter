using Microsoft.Research.DynamicDataDisplay.DataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace NoiseDataExporter
{
    public class PointDataSource:IPointDataSource
    {
        public event EventHandler DataChanged;

        public IPointEnumerator GetEnumerator(DependencyObject context)
        {
            return m_DataPoints.GetEnumerator(context);
        }

        private EnumerableDataSource<Point> m_DataPoints;
             
        public PointDataSource(List<Point> PointList)
        {
            m_DataPoints= new EnumerableDataSource<Point>(PointList);
        }
    }
}
