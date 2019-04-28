using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EmergencyAppSL.Models
{
    public enum ReportType
    {
        [Description("Suspicious Object")]
        SuspiciousObject,
        [Description("Suspicious Place")]
        SuspiciousPlace,
        [Description("Suspicious Person")]
        SuspiciousPerson,
        [Description("Suspicious Activity")]
        SuspiciousActivity,
    }
}
