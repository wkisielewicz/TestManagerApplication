using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestManager.Models;

namespace TestManager.ViewModels
{
    internal class MainWindowViewModel : SharedPageViewModel
    {
        #region fields

        private object _currentView;

        public RelayCommand ScanSuiteTriosClickCommand { get; set; }
        public RelayCommand TriosHardwareTestClickCommand { get; set; }
        public RelayCommand LabHardwareTestClickCommand { get; set; }
        public RelayCommand DashboardClickCommand { get; set; }
        public RelayCommand CloseWindowCommand { get; set; }
        #endregion

        public MainWindowViewModel()
        {
            CurrentView = new DashboardViewModel();
            TriosHardwareTestClickCommand = new RelayCommand(FirstPageTestClicked, CanExecute);
            LabHardwareTestClickCommand = new RelayCommand(SecondPageTestClicked, CanExecute);
            DashboardClickCommand = new RelayCommand(DashboardClicked, CanExecute);
            CloseWindowCommand = new RelayCommand(WindowCloseClick, CanExecute);
        }

        #region INotifyPropertyChanged

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }

        #endregion

        #region Commands

        private void DashboardClicked(object obj)
        {
            CurrentView = new DashboardViewModel();
        }

        private void FirstPageTestClicked(object obj)
        {
            CurrentView = new GeneralTestViewModel();
        }

        private void SecondPageTestClicked(object obj)
        {
            CurrentView = new NonGeneralTestViewModel();
        }

        private void WindowCloseClick(object obj)
        {
            var window = obj as Window;
            window.Close();
        }

        #endregion
    }
}

