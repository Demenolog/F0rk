using System;
using System.ServiceProcess;
using System.Windows;

namespace F0rk.Models.Methods.ServiceHandler
{
    public static class ServiceHandler
    {
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

        public static void ServiceStart(string[] services)
        {
            foreach (string service in services)
            {
                try
                {
                    var sc = new ServiceController(service);
                    if (sc.CanPauseAndContinue)
                    {
                        sc.Start();
                        sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(5));
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public static void ServiceStart(string service)
        {
            try
            {
                var sc = new ServiceController(service);
                if (sc.CanPauseAndContinue)
                {
                    sc.Start();
                    sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(5));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void ServiceStop(string[] services)
        {
            foreach (string service in services)
            {
                try
                {
                    var sc = new ServiceController(service);
                    if (sc.CanStop)
                    {
                        sc.Stop();
                        sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(5));
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public static void ServiceStop(string service)
        {
            try
            {
                var sc = new ServiceController(service);
                if (sc.CanStop)
                {
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(5));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}