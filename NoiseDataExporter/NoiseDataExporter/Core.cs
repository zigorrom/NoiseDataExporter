using NoiseDataExporter.DataModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoiseDataExporter
{
    public class Core
    {
        public Core()
        {
            m_viewModel = new ViewModel();
            CanProcessData = false;
        }

        private ViewModel m_viewModel;

        public ViewModel CoreViewModel
        {
            get { return m_viewModel; }
            //set { m_viewModel = value; }
        }
        private bool CanProcessData;
        private const string MeasureDataFilename = "MeasurData";
        private const string MeasureDataExtendedFileName = "MeasurDataExtended";
        
        


        public bool PrepareToProcessData()
        {
            var MeasurDatafn = String.Concat(m_viewModel.WorkingDirectory,"\\",MeasureDataFilename);
            var MeasurDataExtendedfn = String.Concat(m_viewModel.WorkingDirectory,"\\",MeasureDataExtendedFileName);
            if (!File.Exists(MeasurDataExtendedfn))
            {
                if (File.Exists(MeasurDatafn))
                    MessageBox.Show("You should firstly analyze data with NoiseAll program.");
                else
                    MessageBox.Show("No main files found");
                CanProcessData = false;
            }
            CanProcessData = true;
            return CanProcessData;
        }

        public void ProcessData()
        {

        }

       



    }
}
