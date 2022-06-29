﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F0rk.Models.Methods.ServiceHandler;

namespace F0rk.Models.Classes
{
    public static class Pinpad
    {
        private static readonly string[] UnregistrationCommands;
        private static readonly string[] RegistrationCommands;
        private static readonly string PinpadServiceName;
        


        static Pinpad()
        {
            PinpadServiceName = "Upos2Agent";

            UnregistrationCommands = new[]
            {
                @"sc delete Upos2Agent",
                @"regsvr32 /u D:\Programs\UPOS\sbrf.dll",
                @"regsvr32 /u D:\Programs\UPOS\SBRFCOM.dll"
            };

            RegistrationCommands = new[]
            {
                @"D:\Programs\UPOS\Agent.exe /reg",
                @"regsvr32 D:\Programs\UPOS\sbrf.dll",
                @"regsvr32 D:\Programs\UPOS\SBRFCOM.dll"
            };
        }

        public static void StopUpos2Agent() => ServiceHandler.ServiceStop(PinpadServiceName);

        public static void StartUpos2Agent() => ServiceHandler.ServiceStart(PinpadServiceName);
        
    }
}
