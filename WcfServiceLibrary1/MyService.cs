using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Timers;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MyService : IMyService
    {
        private static Timer mytimer = new Timer(100);

        private static string msg = string.Empty;

        private Random rand = new Random(DateTime.Now.Millisecond);

        public void TimerInit()
        {
            mytimer.Elapsed += new ElapsedEventHandler(TimerTickEvent);

            mytimer.AutoReset = true;

            mytimer.Interval = 200;

            mytimer.Enabled = false;
        }

        private void TimerTickEvent(object sender, ElapsedEventArgs e)
        {
            msg = string.Format("return code：{0}", rand.Next(1000));
        }

        public bool TimerStart()
        {
            if (!mytimer.Enabled)
            {
                mytimer.Enabled = true;
            }

            return mytimer.Enabled;
        }

        public bool TimerStop()
        {
            if (mytimer.Enabled)
            {
                mytimer.Enabled = false;
            }

            return mytimer.Enabled;
        }


        public string GetData(int value)
        {
            //return string.Format("You entered: {0}", value);
            return msg;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
