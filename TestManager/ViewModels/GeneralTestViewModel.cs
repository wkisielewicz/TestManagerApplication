using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TestManager.Models;


namespace TestManager.ViewModels
{   /// <summary>
    ///    Class cointaning logic for General test view.
    /// </summary>
    internal class GeneralTestViewModel : SharedPageViewModel
    {
        public GeneralTestViewModel()
        {
            CreateGeneralTestCheckBoxList();
        }

        public RelayCommand TestSetWithFusedImageCalibrationObjectCommand { get; set; }
        public ObservableCollection<SharedTestModel> GeneralTestList { get; set; }
        public TestsContainter TestsContainter { get; set; }

        /// <summary>
        ///     Creating list of checkboxes for First page view
        /// </summary>
        public void CreateGeneralTestCheckBoxList()
        {
            GeneralTestList = new ObservableCollection<SharedTestModel>();
            GeneralTestList = TestsContainter.UIElementsList;
        }

        public void CheckTestList(object obj)
        {
            var test =
                    from item in GeneralTestList
                    //where item.ScannerType.Contains("Checklist")
                    select item;
            foreach (var SelectedTests in test)
                SelectedTests.IsSelected = true;
        }



        #region Commands

        private ICommand _getSelectedCheckBoxesCommand;
        

        public ICommand GetSelectedCheckBoxesCommand
        {
            get
            {
                if (_getSelectedCheckBoxesCommand == null)
                    _getSelectedCheckBoxesCommand = new RelayCommand(param => GetSelectedCheckBoxes());

                return _getSelectedCheckBoxesCommand;
            }
        }

        public void GetSelectedCheckBoxes()
        {
            var testCommand =
                from item in GeneralTestList
                where item.IsSelected
                select item.TestMethod;
            new CreateTestProcess().TestProcess(string.Join("\r&", new List<string>(testCommand)));
        }

        #endregion
    }
}


