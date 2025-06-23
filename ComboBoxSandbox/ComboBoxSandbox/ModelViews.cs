using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;

namespace ComboBoxSandbox
{
    partial class FormMVVM : ObservableObject
    {
        [ObservableProperty]
        string currentSelection;
    }

    struct ItemMVVM
    {
        public ItemMVVM(string internalValue, string displayValue)
        {
            ActualValueToBeSet = internalValue;
            LocalizedDisplayText = displayValue;
        }


        public string ActualValueToBeSet { get; set; } = "2";
        public string LocalizedDisplayText { get; set; }
    }
}
