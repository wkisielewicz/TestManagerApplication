using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using TestManager.Properties;

namespace TestManager.Views
{
    /// <summary>
    /// Interaction logic for SharedHardwareTestView.xaml
    /// </summary>
    public partial class SharedPageView : UserControl
    {       
        public SharedPageView()
        {
            InitializeComponent();
        }

        private void ScrollConsoleOutput(object sender, TextChangedEventArgs e)
        {
            ConsoleOutput.ScrollToEnd();
        }

    }
}
