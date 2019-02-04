using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestManager.Models
{
    /// <summary>
    ///     Class representing basic test object.
    /// </summary>
    public class SharedTestModel
    {
        public SharedTestModel()
        {
            IsActive = true;
            IsVisible = "Visible";
        }

        public bool IsSelected { get; set; }

        public bool IsActive { get; set; }

        public string IsVisible { get; set; }

        public string TestName { get; set; }

        public string TestMethod { get; set; }
    }

    /// <summary>
    ///     Class representing conatainer for all tests.
    /// </summary>
    public class TestsContainter
    {

        public ObservableCollection<SharedTestModel> UIElementsList { get; private set; }
        public List<string> TestsNameList { get; private set; } = new List<string>();

        /// <summary>
        ///     List of all tests.
        /// </summary>
        private readonly List<SharedTestModel> HardwareTestList = new List<SharedTestModel>
            {
                new SharedTestModel
                {
                    TestName = "Interface Test",
                   
                },
                new SharedTestModel
                {
                    TestName = "Login Test",
                   
                },
                new SharedTestModel
                {
                    TestName = "Rename Test",
                    
                },
                new SharedTestModel
                {
                    TestName = "Test Calib",
                    
                },
                new SharedTestModel
                {
                    TestName = "Delete Test",
                    
                },
                new SharedTestModel
                {
                    TestName = "Save",
                    
                }
            };
    }
}
