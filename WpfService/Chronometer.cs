using System;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Windows.Controls;
using System.Windows.Threading;
using WpfServices.Interface;


namespace WpfService
{
    public class Chronometer :DispatcherTimer , IChronometer
    {

        private Chronometer()
        {
            Initialize();
        }

        public int Seconds { private get; set; }

        public string Value
        {
            get
            {
                return TimeSpan.FromSeconds(Seconds).ToString();
            
            }
        
        }

        public static Chronometer ChronoNew(EventHandler eventHandler)
        {

            const int interval = 1;
            var chrono =new Chronometer();

            chrono.Interval= TimeSpan.FromSeconds(interval);
            chrono.Tick += eventHandler;

            return chrono;
        
        }


        public new void Start()
        { 
            base.Start();
        }

        public void Pause()
        { 
            base.Stop();
        
        }

        public new void Stop()
        {
            base.Stop();
            Initialize();
        
        }

        private void Initialize()
        {
            Seconds = 0;
        
        }
        public void AddSecond()
        {
            Seconds++;
        }
    }   
}
