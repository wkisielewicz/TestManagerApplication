using System;
using System.Xml;
using System.Windows;

namespace TestManager.Models
{
    /// <summary>
    ///     Settings data for xml configuration in AppData folder
    /// </summary>
    public class TestConfiguration
    {
        public string TestCounter { get; set; }

        public bool SingleTest { get; set; }

        public int ReturnCounter()
        {
            try
            {
                var config = new XmlDocument();
                config.Load(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\configuration.xml");
                var counter = Convert.ToInt32(config.SelectSingleNode("TestConfiguration/TestCounter").InnerText);
                return counter;
            }
            catch
            {
                MessageBox.Show("Test count should be a number grater than 0");
                return 0;
            }
        }

        public bool ReturnSingleTest()
        {
            var config = new XmlDocument();
            config.Load(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\configuration.xml");
            var SingleTest = Convert.ToBoolean(config.SelectSingleNode("TestConfiguration/SingleTest").InnerText);
            return SingleTest;
        }
    }
}
