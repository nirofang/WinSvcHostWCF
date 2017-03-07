using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfServiceLibrary1;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                MyService ms = new MyService();
                ms.TimerInit();
                ms.TimerStart();

                ms.TimerStop();


                if (!IsAdministrator())
                {
                    MessageBox.Show("Not Admin!");
                }

                Process exep = new Process();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = @"D:\temp\test\amd64\Inspect1.exe";
                psi.UseShellExecute = true;
                //psi.WorkingDirectory = @"D:\temp\test\x86";
                exep.StartInfo = psi;
                exep.Start();
                exep.WaitForExit();
                //Process.Start("notepad");
                
            }
            catch(Exception ex)
            {
                EventLog el = new EventLog();
                el.WriteEntry("TestApp: " + ex.Message);
            }

            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
