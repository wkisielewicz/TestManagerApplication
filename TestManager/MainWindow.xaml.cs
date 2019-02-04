using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TestManager.Properties;
using TestManager.ViewModels;
using TestManager.Views;

namespace TestManager
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HardwareTest_Clicked(object sender, RoutedEventArgs e)
        {
            this.Menu.Visibility = this.Menu.Visibility == Visibility.Visible
                ? Visibility.Collapsed
                : Visibility.Visible;                  
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void MinButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
