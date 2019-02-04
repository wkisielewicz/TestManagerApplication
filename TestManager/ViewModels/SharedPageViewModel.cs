using System;
using System.Windows;
using System.Windows.Input;
using TestManager.Models;
using TestManager.Properties;
using System.IO;

namespace TestManager.ViewModels
{
    internal class SharedPageViewModel : ObservableObject
    {
        #region fields

        public RelayCommand SaveTestSequenceNumberCommand { get; set; }
        public RelayCommand RunAsATestSequenceCommand { get; set; }
        public RelayCommand RunAsAsingleTestCommand { get; set; }

        private readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private bool _fIsSelected;

        #endregion

        public SharedPageViewModel()
        {
            //calling the FindMax method and initializing needed settings
            SetTestEnvironment n = new SetTestEnvironment();
            n.EnvironmentVariableSettings();
            SaveTestSequenceNumberCommand = new RelayCommand(SaveTestSequenceNumber, CanExecute);
            RunAsATestSequenceCommand = new RelayCommand(RunAsATestSequence, CanExecute);
            RunAsAsingleTestCommand = new RelayCommand(RunAsAsingleTest, CanExecute);
            RunAsAsingleTestCommand = new RelayCommand(RunAsAsingleTest);
            InitialTestConfiguration();
        }

        private void InitialTestConfiguration()
        {
           var config = new TestConfiguration();
           if(config.ReturnSingleTest())
           {
                IsCheckedSingleTestCheckBox = true;
           }
           else
           {
                IsCheckedTestSequenceCheckBox = true;
                _textboxEnabled = true;
                TestCounter = config.ReturnCounter().ToString();
           }
        }

        #region Commands

        private void SaveTestSequenceNumber(object obj)
        {
            try
            {
                var info = new TestConfiguration
                {
                    TestCounter = _testCounter
                };
                SaveData.SaveDataObject(info, _path + @"\configuration.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveTestSequenceNumber()
        {
            try
            {
                var info = new TestConfiguration
                {
                    TestCounter = _testCounter,
                    SingleTest = false
                };
                SaveData.SaveDataObject(info, _path + @"\configuration.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool CanExecute(object obj)
        {
            return true;
        }

        public void RunAsAsingleTest(object obj)
        {
            var info = new TestConfiguration
            {
                TestCounter = _testCounter,
                SingleTest = true
            };
            TextboxEnabled = false;
            SaveData.SaveDataObject(info, _path + @"\configuration.xml");
        }

        public void RunAsATestSequence(object obj)
        {
            TextboxEnabled = true;
            TestCounter = new TestConfiguration().ReturnCounter().ToString();
            SaveTestSequenceNumber();
        }

        #endregion

        #region InotifyPropertyChanged

        public bool IsSelected
        {
            get => _fIsSelected;
            set
            {
                if (value != _fIsSelected)
                {
                    _fIsSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }

        private string _testCounter;

        public string TestCounter
        {
            get => _testCounter;
            set
            {
                if (!string.Equals(value, string.Empty))
                {
                    if (!string.Equals(_testCounter, value))
                    {
                        _testCounter = value;
                        SaveTestSequenceNumber();
                        OnPropertyChanged("TestCounter");
                    }
                }else MessageBox.Show("Test counter field can not be empty");
            }
        }

        private bool _textboxEnabled;

        public bool TextboxEnabled
        {
            get => _textboxEnabled;
            set
            {
                _textboxEnabled = value;
                OnPropertyChanged("TextboxEnabled");
            }
        }

        /// <summary>
        /// Uncheck checkbox when the second is selected. This logic reffers to Single Test and Test Sequence checkboxes.
        /// </summary>

        private bool _isCheckedSingleTestCheckBox;
        private bool _isCheckedTestSequenceCheckBox;

        public bool IsCheckedSingleTestCheckBox
        {
            get => _isCheckedSingleTestCheckBox;
            set
            {
                if (value)
                    IsCheckedTestSequenceCheckBox = false;


                _isCheckedSingleTestCheckBox = value;
                OnPropertyChanged("IsCheckedSingleTestCheckBox");
            }
        }

        public bool IsCheckedTestSequenceCheckBox
        {
            get => _isCheckedTestSequenceCheckBox;
            set
            {
                if (value)
                    IsCheckedSingleTestCheckBox = false;

                _isCheckedTestSequenceCheckBox = value;
                OnPropertyChanged("IsCheckedTestSequenceCheckBox");
            }
        }

        #endregion
    }

}
