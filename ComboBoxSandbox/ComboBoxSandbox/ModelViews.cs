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
        int currentSelection = 2;
    }

    struct ItemMVVM
    {
        public ItemMVVM(string internalValue, string displayValue)
        {
            ActualValueToBeSet = int.Parse(internalValue);
            LocalizedDisplayText = displayValue;
        }


        public int ActualValueToBeSet { get; set; }
        public string LocalizedDisplayText { get; set; }
    }
}
