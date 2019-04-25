using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyAppSL.Models
{
    public class SuspiciousReport : BindableBase
    {
        public string PhotoUrl { get; set; }
        public string ReportTitle { get; set; }
        public string ReportDescription { get; set; }
        public DateTime ReportDateTime { get; set; }
        public ReportType ReportType { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public double ReportLocationLatitude { get; set; }
        public double ReportLocationLongitude { get; set; }
        public string ReportAddress { get; set; }
    }
}
