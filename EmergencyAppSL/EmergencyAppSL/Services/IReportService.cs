using System;
using System.Collections.Generic;
using System.Text;
using EmergencyAppSL.Models;

namespace EmergencyAppSL.Services
{
    public interface IReportService
    {
        List<SuspiciousReport> GetReportHistoryList();

        bool CreateReport(SuspiciousReport report);
    }
}
