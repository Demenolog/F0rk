using System;
using System.ServiceProcess;

namespace F0rk.Methods.ServiceHandler
{
    public static class ServiceHandler
    {
        public static void ServicesStop(string[] services)
        {
            foreach (string service in services)
            {
                var sc = new ServiceController(service);

                try
                {
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        public static void ServicesStart(string[] services)
        {
            foreach (string service in services)
            {
                var sc = new ServiceController(service);

                try
                {
                    sc.Start();
                    sc.WaitForStatus(ServiceControllerStatus.Running);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }
    }
}