using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace F0rk.Methods.ServiceStopper
{
    public static class ServiceHandler
    {
        public static void ServicesStop(string[] services)
        {
            try
            {
                foreach (string service in services)
                {
                    var sc = new ServiceController(service);
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped);
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public static void ServicesStart(string[] services)
        {
            try
            {
                foreach (string service in services)
                {
                    var sc = new ServiceController(service);
                    sc.Start();
                    sc.WaitForStatus(ServiceControllerStatus.Running);
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
