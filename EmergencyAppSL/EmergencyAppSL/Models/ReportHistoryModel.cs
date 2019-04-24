using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyAppSL.Models
{
    public class ReportHistoryModel : BindableBase
    {
        public string ReportTitle { get; set; }
        public string ReportDescription { get; set; }
        public DateTime ReportDateTime { get; set; }
        public int Status { get; set; }
        public long ReportLocationLatitude { get; set; }
        public long ReportLocationLongitude { get; set; }
    }
}
