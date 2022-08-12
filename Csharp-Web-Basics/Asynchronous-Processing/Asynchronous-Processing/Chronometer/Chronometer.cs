using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronometer
{
    internal class Chronometer : IChronometer
    {
        public Stopwatch timer;

        private List<string> laps;
        public Chronometer()
        {
            timer = new Stopwatch();
            laps = new List<string>();
        }
        public string GetTime => timer.Elapsed.ToString(@"mm\:ss\.ffff");

        public List<string> Laps => laps;

      

        public string Lap()
        {
            var lap = GetTime;
            laps.Add(lap);
            return lap;
        }

        public void Reset()
        {
           
            timer.Reset();
            laps.Clear();
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }
    }
}
