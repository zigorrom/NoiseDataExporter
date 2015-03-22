using Microsoft.Research.DynamicDataDisplay.DataSources;
using Microsoft.Research.DynamicDataDisplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LinearFitControl
{
    public class PointDataContainer:List<Point>, IPointDataSource
    {
        public event EventHandler DataChanged;

        public IPointEnumerator GetEnumerator(System.Windows.DependencyObject context)
        {
            throw new NotImplementedException();
        }

        private void OnDataChanged()
        {

        }
    }

    public class PointDataEnumerator : IPointEnumerator
    {

        private PointDataContainer m_data;
        public void ApplyMappings(DependencyObject target)
        {
            throw new NotImplementedException();
        }

        public void GetCurrent(ref Point p)
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

}
