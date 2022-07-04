using System;
using System.ServiceProcess;

namespace F0rk.Models.Methods.ServiceHandler
{
    public static class ServiceHandler
    {
        public static void ServiceStop(string[] services)
        {
            foreach (string service in services)
            {
                try
                {
                    var sc = new ServiceController(service);
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        public static void ServiceStop(string service)
        {
            try
            {
                var sc = new ServiceController(service);
                sc.Stop();
                sc.WaitForStatus(ServiceControllerStatus.Stopped);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public static void ServiceStart(string[] services)
        {
            foreach (string service in services)
            {
                try
                {
                    var sc = new ServiceController(service);
                    sc.Start();
                    sc.WaitForStatus(ServiceControllerStatus.Running);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        public static void ServiceStart(string service)
        {
            try
            {
                var sc = new ServiceController(service);
                sc.Start();
                sc.WaitForStatus(ServiceControllerStatus.Running);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public static void ServiceRestart(string[] services)
        {
            ServiceStop(services);
            ServiceStart(services);
        }

        public static void ServiceRestart(string service)
        {
            ServiceStop(service);
            ServiceStart(service);
        }
    }
}