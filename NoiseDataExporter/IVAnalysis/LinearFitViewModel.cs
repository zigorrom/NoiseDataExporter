using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LinearFit
{
    public class LinearFitViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (null != PropertyChanged)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double m_DSvoltage;

        public double DSVoltage
        {
            get { return m_DSvoltage; }
            set {
                if (m_DSvoltage == value)
                    return;
                m_DSvoltage = value;
                OnPropertyChanged("DSVoltage");
            }
        }

        private double m_TresholdVoltage;

        public double TresholdVoltage
        {
            get { return m_TresholdVoltage; }
            set {
                if (m_TresholdVoltage == value)
                    return;
                m_TresholdVoltage = value;
                OnPropertyChanged("TresholdVoltage");
            }
        }


        private Point m_LeftDraggablePointPosition;

        public Point LeftDraggablePointPosition
        {
            get { return m_LeftDraggablePointPosition; }
            set {
                if (m_LeftDraggablePointPosition == value)
                    return;
                if (value.X > m_RightDraggablePointPosition.X)
                    m_LeftDraggablePointPosition = new Point(m_LeftDraggablePointPosition.X, value.Y);
                m_LeftDraggablePointPosition = value;
                m_LeftMarkerPosition = m_LeftDraggablePointPosition.X;
                OnPropertyChanged("LeftDraggablePointPosition");
            }
        }

        private Point m_RightDraggablePointPosition;

        public Point RightDraggablePointPosition
        {
            get { return m_RightDraggablePointPosition; }
            set {
                if (m_RightDraggablePointPosition == value)
                    return;
                if (value.X < m_LeftDraggablePointPosition.X)
                    m_RightDraggablePointPosition = new Point(m_RightDraggablePointPosition.X, value.Y);
                m_RightDraggablePointPosition = value;
                m_RightMarkerPosition = m_RightDraggablePointPosition.X;
                OnPropertyChanged("RightDraggablePointPosition");
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







    }
}
