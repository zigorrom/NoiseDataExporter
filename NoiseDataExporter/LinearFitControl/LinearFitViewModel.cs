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
        private ChartPlotter LinearFitPlotter;
        public LinearFitViewModel(ChartPlotter LinearFitPlotter)
        {
            // TODO: Complete member initialization
            this.LinearFitPlotter = LinearFitPlotter;
        }

        private double m_MaxX;

        public double MaxX
        {
            get { return m_MaxX;; }
            set {
                if (value == m_MaxX)
                    return;
                m_MaxX = value;
                OnPropertyChanged("MaxX");
            }
        }

        private double m_MinX;

        public double MinX
        {
            get { return m_MinX; }
            set {
                if (value == m_MinX)
                    return;
                m_MinX = value;
                OnPropertyChanged("MinX");
            }
        }


        private Point m_LeftDraggablePoint;

        public Point LeftDraggablePoint
        {
            get { return m_LeftDraggablePoint; }
            set {
                if (value==m_LeftDraggablePoint)
                    return;
                if (value.X < MinX)
                    value.X = MinX;
                if (value.X >= RightDraggablePoint.X)
                    value.X = RightDraggablePoint.X;
                m_LeftDraggablePoint = value;
                OnPropertyChanged("LeftDraggablePoint");
                OnRangeChanged();
            }
        }

        private Point m_RightDraggablePoint;

        public Point RightDraggablePoint
        {
            get { return m_RightDraggablePoint; }
            set {
                if (m_RightDraggablePoint == value)
                    return;
                if (value.X > MaxX)
                    value.X = MaxX;
                if (value.X <= LeftDraggablePoint.X)
                    value.X = LeftDraggablePoint.X;
                m_RightDraggablePoint = value;
                OnPropertyChanged("RightDraggablePoint");
                OnRangeChanged();
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
                        return -1;
                    if (a.X > b.X)
                        return 1;
                    return 0;
                }));
                Curve = new EnumerableDataSource<Point>(m_data);
                MinX = Data[0].X;
                MaxX = Data[Data.Count - 1].X;
                if (MaxX < MinX)
                    throw new ArgumentException("MaxX<MinX");
                LeftDraggablePoint = new Point(Data[0].X, Data[0].Y);
                RightDraggablePoint = new Point(Data[Data.Count - 1].X, Data[Data.Count - 1].Y);
                OnPropertyChanged("Data");
            }
        }

        private void OnRangeChanged()
        {
            var SelectedValues = m_data.Where(x => x.X >= LeftDraggablePoint.X && x.X <= RightDraggablePoint.X);
            double[] X = SelectedValues.Select(x => x.X).ToArray();
            double[] Y = SelectedValues.Select(x => x.Y).ToArray();
            if (X == null || Y == null)
                throw new ArgumentNullException("Either X or Y array is null");
            if (X.Length < 2 || Y.Length < 2)
                return;
            var res= MathNet.Numerics.Fit.Line(X, Y);
            Intercept = res.Item1;
            Slope = res.Item2;
            var fitLine = new List<Point>();
            fitLine.Add(new Point(LeftDraggablePoint.X, LineFunc(LeftDraggablePoint.X)));
            fitLine.Add(new Point(RightDraggablePoint.X,LineFunc(RightDraggablePoint.X)));
            FitCurve = new EnumerableDataSource<Point>(fitLine);
        }

        private double LineFunc(double x)
        {
            return Intercept + x * Slope;
        }

        private EnumerableDataSource<Point> m_curve;

        public EnumerableDataSource<Point> Curve
        {
            get { return m_curve; }
            set
            {
                m_curve = value;
                m_curve.SetXYMapping(x => x);
                m_curve.RaiseDataChanged();
                LinearFitPlotter.FitToView();
                OnPropertyChanged("Curve");
            }
        }

        private EnumerableDataSource<Point> m_fitCurve;

        public EnumerableDataSource<Point> FitCurve
        {
            get { return m_fitCurve; }
            set {
                m_fitCurve = value;
                m_fitCurve.SetXYMapping(x => x);
                m_fitCurve.RaiseDataChanged();
                LinearFitPlotter.FitToView();
                OnPropertyChanged("FitCurve");
            }
        }


        private double m_intercept;

        public double Intercept
        {
            get { return m_intercept; }
            set {
                if (m_intercept == value)
                    return;
                m_intercept = value;
                OnPropertyChanged("Intercept");
            }
        }

        private double m_slope;

        public double Slope
        {
            get { return m_slope; }
            set {
                if (m_slope == value)
                    return;
                m_slope = value;
                OnPropertyChanged("Slope");
                m_slope = value; }
        }

        private double m_ZeroCrossingPointX;
       

        public double ZeroCrossingPointX
        {
            get { return m_ZeroCrossingPointX; }
            set { m_ZeroCrossingPointX = value; }
        }





    }
}
