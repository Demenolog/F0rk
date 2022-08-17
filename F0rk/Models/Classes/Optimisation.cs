using System.IO;
using F0rk.Models.Methods.TasksHandler;

namespace F0rk.Models.Classes
{
    public static class Optimisation
    {
        private static readonly string[] LanguageBarCommandsForCmd;
        private static readonly string PathToLanguageBarDirectory;
        private static readonly string PathToTimeSynchronizationDirectory;
        private static readonly string[] TimeSynchronizationBatchText;
        private static readonly string TimeSynchronizationCommandForCmd;
        private static readonly string[] WmicPagefileIncreaseCommands;

        static Optimisation()
        {
            WmicPagefileIncreaseCommands = new[]
            {
                @"wmic computersystem set AutomaticManagedPagefile=False /NOINTERACTIVE",
                @"wmic pagefileset delete /NOINTERACTIVE",
                @"wmic pagefileset create name=""C:\\pagefile.sys"" /NOINTERACTIVE",
                @"wmic pagefileset where name=""C:\\\\pagefile.sys"" set InitialSize=3546,MaximumSize=3546 /NOINTERACTIVE",
                @"wmic pagefileset create name=""D:\\pagefile.sys"" /NOINTERACTIVE",
                @"wmic pagefileset where name=""D:\\\\pagefile.sys"" set InitialSize=3546,MaximumSize=3546 /NOINTERACTIVE"
            };

            TimeSynchronizationBatchText = new[]
            {
                @"sc start W32Time",
                @"sc config W32Time start=auto",
                @"W32tm.exe /resync"
            };

            TimeSynchronizationCommandForCmd = @"SCHTASKS /Create /SC ONSTART /TN TimeSynchronization /TR " +
                                               @"C:\Windows\Svyaznoy\TimeSynchronization\TimeSynchronization.bat";

            PathToTimeSynchronizationDirectory = @"C:\Windows\Svyaznoy\TimeSynchronization";

            LanguageBarCommandsForCmd = new []
            {
                @"SCHTASKS /Create /XML C:\Windows\Svyaznoy\LanguageBar\MsCtfMonitor.xml /tn LanguageBar",
                @"SCHTASKS /run /tn LanguageBar"
            };

            PathToLanguageBarDirectory = @"C:\Windows\Svyaznoy\LanguageBar";
        }

        public static string[] GetWmicPagefileIncreaseCommands => WmicPagefileIncreaseCommands;

        public static void ReturnLanguageBar()
        {
            Directory.CreateDirectory(PathToLanguageBarDirectory);

            var fi = new FileInfo(PathToLanguageBarDirectory + "\\MsCtfMonitor.xml");

            using (StreamWriter sw = fi.CreateText())
            {
                sw.WriteLine(@"<?xml version=""1.0"" encoding=""UTF-16""?>
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
</Task>");
            }

            TasksHandler.StartTaskWithCommands("cmd", LanguageBarCommandsForCmd);
        }

        public static void TimeSynchronization()
        {
            Directory.CreateDirectory(PathToTimeSynchronizationDirectory);

            FileInfo fi = new FileInfo(PathToTimeSynchronizationDirectory + "\\TimeSynchronization.bat");

            using (StreamWriter sw = fi.CreateText())
            {
                foreach (string command in TimeSynchronizationBatchText)
                {
                    sw.WriteLine(command);
                }
            }

            TasksHandler.StartTaskWithCommands("cmd",TimeSynchronizationBatchText);

            TasksHandler.StartTaskWithCommands("cmd", TimeSynchronizationCommandForCmd);
        }
    }
}