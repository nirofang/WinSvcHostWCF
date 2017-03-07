using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary1;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        private ServiceHost _host = new ServiceHost(typeof(MyService));

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _host.Open();
        }

        protected override void OnStop()
        {
            _host.Close();
        }
    }
}
