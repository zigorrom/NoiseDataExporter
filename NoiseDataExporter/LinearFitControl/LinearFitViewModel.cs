using Microsoft.Research.DynamicDataDisplay.DataSources;
using Microsoft.Research.DynamicDataDisplay;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LinearFitControl
{
    public class LinearFitViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (null != PropertyChanged)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double m_MaxX;

        public double MaxX
        {
            get { return m_MaxX;; }
            set { m_MaxX = value; }
        }

        private double m_MinX;

        public double MinX
        {
            get { return m_MinX; }
            set { m_MinX = value; }
        }


        private Point m_LeftDraggablePoint;

        public Point LeftDraggablePoint
        {
            get { return m_LeftDraggablePoint; }
            set {
                if (value==m_LeftDraggablePoint)
                    return;
                m_LeftDraggablePoint = value;
                LeftMarkerPosition = m_LeftDraggablePoint.X;
                OnPropertyChanged("LeftDraggablePoint");
            }
        }

        private Point m_RightDraggablePoint;

        public Point RightDraggablePoint
        {
            get { return m_RightDraggablePoint; }
            set {
                if (m_RightDraggablePoint == value)
                    return;
                m_RightDraggablePoint = value;
                RightMarkerPosition = m_RightDraggablePoint.X;
                OnPropertyChanged("RightDraggablePoint");
            }
        }


        private double m_LeftMarkerPosition;

        public double LeftMarkerPosition
        {
            get { return m_LeftMarkerPosition; }
            set
            {
                if (m_LeftMarkerPosition == value)
                    return;
                m_LeftMarkerPosition = value;
                OnPropertyChanged("LeftMarkerPosition");

            }
        }

        private double m_RightMarkerPosition;

        public double RightMarkerPosition
        {
            get { return m_RightMarkerPosition; }
            set
            {
                if (m_RightMarkerPosition == value)
                    return;
                m_RightMarkerPosition = value;
                OnPropertyChanged("RightMarkerPosition");
            }
        }

        private List<Point> m_data;

        public List<Point> Data
        {
            get { return m_data; }
            set
            {
                if (value == null)
                    return;
                if (value.Count == 0)
                    return;
                m_data = value;
                m_data.Sort(new Comparison<Point>((a, b) =>
                {
                    if (a.X < b.X)
                        return 1;
                    if (a.X > b.X)
                        return -1;
                    return 0;
                }));
                DataSource = new EnumerableDataSource<Point>(m_data);
                MinX = Data[0].X;
                MaxX = Data[Data.Count - 1].X;
                LeftDraggablePoint = new Point(MinX, Data[0].Y);
                RightDraggablePoint = new Point(MaxX, Data[Data.Count - 1].Y);
                
                //LeftMarkerPosition = MinX;
                //RightMarkerPosition = MaxX;
                OnPropertyChanged("Data");
            }
        }

        private double[] m_DataXArray;

        public double[] DataXArray
        {
            get { return m_DataXArray; }
            set { m_DataXArray = value; }
        }

        private double[] m_DataYArray;

        public double[] DataYArray
        {
            get { return m_DataYArray; }
            set { m_DataYArray = value; }
        }


        private EnumerableDataSource<Point> m_dataSource;

        public EnumerableDataSource<Point> DataSource
        {
            get { return m_dataSource; }
            set
            {
                m_dataSource = value;
                m_dataSource.SetXYMapping(x => x);
                //m_dataSource.SetXMapping(x => x.X);
                //m_dataSource.SetYMapping(x => x.Y);
                m_dataSource.RaiseDataChanged();
                OnPropertyChanged("DataSource");
            }
        }



        private double m_intercept;

        public double Intercept
        {
            get { return m_intercept; }
            set { m_intercept = value; }
        }

        private double m_slope;

        public double Slope
        {
            get { return m_slope; }
            set { m_slope = value; }
        }

        private double m_ZeroCrossingPointX;

        public double ZeroCrossingPointX
        {
            get { return m_ZeroCrossingPointX; }
            set { m_ZeroCrossingPointX = value; }
        }





    }
}
