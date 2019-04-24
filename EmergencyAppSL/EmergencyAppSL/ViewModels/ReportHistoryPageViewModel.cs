using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EmergencyAppSL.ViewModels
{
	public class ReportHistoryPageViewModel : BindableBase
	{
        public ObservableCollection<string> ReportHistoryList { get; set; }

        public ReportHistoryPageViewModel()
        {
            ReportHistoryList = new ObservableCollection<string>()
            {
                "Hello", "Cat", "Word", "Great", "Bin", "Lolita", "Karen"
            };
        }
	}
}
