using System.IO;
using System.Windows;
using F0rk.Models.Methods.TasksHandler;

namespace TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string PathToLanguageBarDirectory = @"C:\Windows\Svyaznoy\LanguageBar";

            Directory.CreateDirectory(PathToLanguageBarDirectory);

            FileInfo fi = new FileInfo(PathToLanguageBarDirectory + "\\MsCtfMonitor.xml");

            using (StreamWriter sw = fi.CreateText())
            {
                string logic = @"<?xml version=""1.0"" encoding=""UTF-16""?>
<Task version=""1.3"" xmlns=""http://schemas.microsoft.com/windows/2004/02/mit/task"">
  <RegistrationInfo>
    <Source>Microsoft Corporation</Source>
    <Description>TextServicesFramework monitor task</Description>
    <URI>Microsoft\Windows\TextServicesFramework\MsCtfMonitor</URI>
    <SecurityDescriptor>D:(A;;FA;;;BA)(A;;FA;;;SY)(A;;FR;;;BU)</SecurityDescriptor>
  </RegistrationInfo>
  <Triggers>
    <LogonTrigger>
      <Enabled>true</Enabled>
    </LogonTrigger>
  </Triggers>
  <Principals>
    <Principal id=""AnyUser"">
      <GroupId>S-1-5-32-545</GroupId>
      <RunLevel>LeastPrivilege</RunLevel>
    </Principal>
  </Principals>
  <Settings>
    <MultipleInstancesPolicy>Parallel</MultipleInstancesPolicy>
    <DisallowStartIfOnBatteries>false</DisallowStartIfOnBatteries>
    <StopIfGoingOnBatteries>false</StopIfGoingOnBatteries>
    <AllowHardTerminate>true</AllowHardTerminate>
    <StartWhenAvailable>false</StartWhenAvailable>
    <RunOnlyIfNetworkAvailable>false</RunOnlyIfNetworkAvailable>
    <IdleSettings>
      <StopOnIdleEnd>true</StopOnIdleEnd>
      <RestartOnIdle>false</RestartOnIdle>
    </IdleSettings>
    <AllowStartOnDemand>true</AllowStartOnDemand>
    <Enabled>true</Enabled>
    <Hidden>true</Hidden>
    <RunOnlyIfIdle>false</RunOnlyIfIdle>
    <DisallowStartOnRemoteAppSession>false</DisallowStartOnRemoteAppSession>
    <UseUnifiedSchedulingEngine>true</UseUnifiedSchedulingEngine>
    <WakeToRun>false</WakeToRun>
    <ExecutionTimeLimit>PT0S</ExecutionTimeLimit>
    <Priority>7</Priority>
  </Settings>
  <Actions Context=""AnyUser"">
    <ComHandler>
      <ClassId>{01575CFE-9A55-4003-A5E1-F38D1EBDCBE1}</ClassId>
    </ComHandler>
  </Actions>
</Task>";
                sw.WriteLine(logic);
            }

            string LanguageBarCmd = @"SCHTASKS /Create /XML C:\Windows\Svyaznoy\LanguageBar\MsCtfMonitor.xml /tn LanguageBar";

            TasksHandler.StartTaskWithCommands("cmd", LanguageBarCmd);

            MessageBox.Show(fi.FullName);
        }
    }
}