using Avalonia.Layout;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McGreeninator_UI.Classes
{
    public static class commands
    {
        // the water pump. defined as time to turn on and amount to disperse.
        // can be set in a continuous mode where water will be added slowly as a mL / day value
        static readonly string PAdd = "AP";// add Pump
        static readonly string PRem = "RP"; // remove Pump
        static readonly string PRes = "XP"; // reset Pump
        static readonly string PAddMult = "NP"; // sends List of pump
        static readonly string PMode = "MP";

        // Grow Light defined as a times the light will turn on 
        static readonly string LAdd = "AL";// add Light 
        static readonly string LRem = "RL"; // remove Light
        static readonly string LRes = "XL"; // reset Light
        static readonly string LAddMult = "NL"; // sends List of Light

        // temperature of the system
        static readonly string TSet = "ST";  // set temperature range - sets temperature range
        static readonly string TRes = "RT"; // reset temperature range - resets to default temp

        // Relative Humidity of the sytem
        static readonly string HSet = "SH"; // set humidity
        static readonly string HRes = "RH"; // reset humidity

        // Nutrition in the system - defined as mL / L of water
        static readonly string NSet = "SN";// set nutrition
        static readonly string NRes = "RN";// reset nutrition

        // Status Returns the current state of the machine, this will be a string of data containing current
        // temperature, humidity, and active devices 
        static readonly string SGet = "GS"; // get status

        // get pumps
        static readonly string PGet = "GP";
    }

    public enum pumpMode
    {
        Continuous,
        Timed,
        Frequency
    }

    public struct timeRange
    {
        public int Start;
        public int End;

        public timeRange(int s, int e)
        {
            Start = s;
            End = e;
        }
        public timeRange(string commandArray)
        {
            string[] splitCommand = commandArray.Split(",");
            Start = int.Parse(splitCommand[0]);
            End = int.Parse(splitCommand[1]);
        }
    }

    public struct timeLists
    {
        public List<timeRange> pumpList;
        public List<timeRange> lightList;

        public timeLists(List<timeRange> pump, List<timeRange> light)
        {
            pumpList = pump;
            lightList = light;
        }
        
    }

    public struct status
    {
        public int waterLevel;
        public int nutritionLevel;
        public int temperature;
        public int humidity;
        public bool lightOn;
        public bool WpumpOn;
        public bool NpumpOn;

        public status(int wl, int nl, int t, int h, bool l, bool w, bool n)
        {
            waterLevel = wl;
            nutritionLevel = nl;
            temperature = t; humidity = h;
            lightOn = l; WpumpOn = w; NpumpOn = n;
        }

    }

    internal class cSerialHandler
    {
        // Create the serial port with basic settings
        private readonly SerialPort port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);

        cSerialHandler()
        {
            
            // Attach a method to be called when there
            // is data waiting in the port's buffer
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);

            // Begin communications
            port.Open();
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            parseCommand(port.ReadExisting());
        }

        private int parseCommand(string command)
        {
            return 0;
        }

        private int sendCommand(string command)
        {
            port.WriteLine(command);
            return 0;
        }

        private int statusCommand(string command)
        {
            return 0;
        }

        // Pump
        private int addPump(timeRange pumpRange = new timeRange(), int amount = 0)
        {
            /* dummy code untill global pumpmode is added */ pumpMode currentPumpMode = pumpMode.Continuous;

            if (currentPumpMode == pumpMode.Continuous)
            {

            }
            else if (currentPumpMode == pumpMode.Timed)
            {

            }
            else if (currentPumpMode == pumpMode.Frequency)
            {

            }
            
            
            return 0;
        }

        private int removePump(int pumpNo)
        {
            return 0;
        }

        private int resetPump()
        {
            return 0;
        }
        
        private int addMultPump(List<timeRange> pumpList)
        {
            return 0;
        }

        private int setPumpMode(pumpMode mode)
        {
            return 0;
        }

        // Light

        private int addLight(timeRange lightRange)
        {
            return 0;
        }

        private int removeLight(int lightNo)
        {
            return 0;
        }

        private int resetLight()
        {
            return 0;
        }

        private int addMultLight(List<timeRange> pumpList)
        {
            return 0;
        }

        // temp
        private int setTemp(int temperature, int tolerance)
        { 
            return 0;
        }
        private int resetTemp()
        {
            return 0;
        }
        // humidity
        private int setHumidity(int humidity, int tolerance)
        {
            return 0;
        }
        private int resetHumidity()
        {
            return 0;
        }
        // nutrition
        private int setNutrition(int nutrition, int tolerance)
        {
            return 0;
        }
        private int resetNutrition()
        {
            return 0;
        }

        // status
        private status getStatus()
        {
            int wl, nl, t, h;
            bool l, w, n;
            string receivedMessage = "";

            // grab return string

            string[] parsedMessage = receivedMessage.Split("|");
            if (parsedMessage.Length == 7) {
                wl = int.Parse(parsedMessage[0]);
                nl = int.Parse(parsedMessage[1]);
                t = int.Parse(parsedMessage[2]);
                h = int.Parse(parsedMessage[3]);
                l = bool.Parse(parsedMessage[4]);
                w = bool.Parse(parsedMessage[5]);
                n = bool.Parse(parsedMessage[6]);

                return new status(wl, nl, t, h, l, w, n);
            }

            return  new status();
        }
        // update pump / light
        private timeLists updateLists()
        {
            List <timeRange> pumpList = new List<timeRange>();
            List <timeRange> lightList = new List<timeRange>();

            string Message = "";
            string[] splitMessage;
            string[] pumpCommands;
            string[] lightCommands;

            splitMessage = Message.Split(";");
            if (splitMessage.Length != 0)
            {
                pumpCommands = splitMessage[0].Split("|");
                lightCommands = splitMessage[1].Split("|");

                foreach (string command in pumpCommands ) 
                {
                    pumpList.Add(new timeRange(command));
                }

                foreach (string command in lightCommands)
                {
                    lightList.Add(new timeRange(command));
                }

                return new timeLists(pumpList, lightList);
            }


            return new timeLists();
        }

    }
}
