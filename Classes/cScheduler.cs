using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McGreeninator_UI.Classes
{

    public struct timeRange
    {
        public int Start;

        // pump end is ml of water, light is end time
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

        public timeLists()
        {
            pumpList = new List<timeRange>();
            lightList = new List<timeRange>();  
        }

        public timeLists(List<timeRange> pump, List<timeRange> light)
        {
            pumpList = pump;
            lightList = light;
        }

    }

    public class cScheduler
    {
        //public timeLists scheduledItems = new timeLists();

        
        
    }
}
