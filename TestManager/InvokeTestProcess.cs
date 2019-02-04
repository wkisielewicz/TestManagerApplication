using System;
using System.Diagnostics;
using System.IO;
using TestManager.Properties;
using TestManager.Models;

namespace TestManager
{
    /// <summary>
    /// Invoke test process from commandline for Trios or Lab
    /// </summary>
    public class CreateTestProcess
    {
        public void TestProcess(string commandArray)
        {
            var process = new Process();

            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = commandArray;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.OutputDataReceived += OutputHandler;
            process.ErrorDataReceived += OutputHandler;
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
        }

        private void OutputHandler(object sender, DataReceivedEventArgs outLine)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("{0}", outLine.Data);
        }
    }

    public class SetTestEnvironment
    {
        string currentPathValue;
        string newPath;
        public void EnvironmentVariableSettings()
        {
            string configurationPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            DirectoryInfo info = new DirectoryInfo(".");
            string nunitPath = Path.GetFullPath(Path.Combine(info.FullName, Settings.Default.nunitEnvironmentVariable));
            currentPathValue = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User);
            newPath = currentPathValue + ";" + nunitPath;

            if (currentPathValue.Contains(nunitPath) == false)
            {
                Environment.SetEnvironmentVariable("Path", newPath, EnvironmentVariableTarget.User);
            }

            var counterInfo = new TestConfiguration
            {
                TestCounter = "1",
                SingleTest = true
            };
            if (!File.Exists(configurationPath + @"\configuration.xml")) SaveData.SaveDataObject(counterInfo, configurationPath + @"\configuration.xml");
        }
        
       
    }
}

