
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McGreeninator_UI.Classes
{
    public struct ResourceValues
    {
        private float _phosphorus;
        private float _potassium;
        private float _nitrogen;
        private float _phUP;
        private float _phDOWN;

        public float Phosphorus { get { return _phosphorus; } set { _phosphorus = value; } }
        public float Potassium { get { return _potassium; } set { _potassium = value; } }
        public float Nitrogen { get { return _nitrogen; } set { _nitrogen = value; } }
        public float PHUP { get { return _phUP; } set { _phUP = value; } }
        public float PHDOWN { get { return _phDOWN; } set { _phDOWN = value; } }


    }

    public class cSettings
    {
        
        public struct Settings {

            private float _waterFlow;
            private float _phUPFlow;
            private float _phDOWNFlow;
            private float _nitrogenFlow;
            private float _potassiumFlow;
            private float _phosphorusFlow;

            private timeLists _scheduler;

            private pumpMode _currentPumpMode;

            public float PhosphorusFlow { get { return _phosphorusFlow; } set { _phosphorusFlow = value; } }
            public float PotassiumFlow { get { return _potassiumFlow; } set { _potassiumFlow = value; } }
            public float NitrogenFlow { get { return _nitrogenFlow; } set { _nitrogenFlow = value; } }
            public float PHUPFlow { get { return _phUPFlow; } set { _phUPFlow = value; } }
            public float PHDOWNFlow { get { return _phDOWNFlow; } set { _phDOWNFlow = value; } }
            public float WaterFlow { get { return _waterFlow; } set { _waterFlow = value; } }

            public timeLists Scheduler { get { return _scheduler; } set { _scheduler = value; } }
            public pumpMode CurrentPumpMode { get { return _currentPumpMode; } set { _currentPumpMode = value; } }

            public Settings()
            {
                _waterFlow = 0;
                _phUPFlow = 0;
                _phDOWNFlow = 0;
                _nitrogenFlow = 0;
                _potassiumFlow = 0;
                _phosphorusFlow = 0;

                _scheduler = new timeLists();

                _currentPumpMode = pumpMode.Frequency;
            }
        }

        public Settings CurrentSettings = new Settings();
        public ResourceValues TargetResourceVal;

        public void LoadSettings()
        {
            CurrentSettings = new Settings(); 

            // load the saved settings from the json file
        }

        public void SaveSettings()
        {
            // save the settings to the json file
        }
        

    }
}
