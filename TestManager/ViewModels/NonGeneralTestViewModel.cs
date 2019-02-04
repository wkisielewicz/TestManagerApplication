using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestManager.Models;

namespace TestManager.ViewModels
{
    internal class NonGeneralTestViewModel : SharedPageViewModel
    {
        public NonGeneralTestViewModel()
        {
            NonGeneralTestCheckBoxList();
        }

        public ObservableCollection<SharedTestModel> NonGeneralTestList { get; set; }
        public TestsContainter TestsContainter { get; set; }

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

        public void NonGeneralTestCheckBoxList()
        {
            NonGeneralTestList = new ObservableCollection<SharedTestModel>();
            NonGeneralTestList = TestsContainter.UIElementsList;
        }

        public void GetSelectedCheckBoxes()
        {
            var testCommand =
                from item in NonGeneralTestList
                where item.IsSelected
                select item.TestMethod;
            new CreateTestProcess().TestProcess(string.Join("\r&", new List<string>(testCommand)));
        }
    }
}
