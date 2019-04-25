using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using EmergencyAppSL.Models;

namespace EmergencyAppSL.Services
{
    public class ReportService : IReportService
    {
        private readonly List<SuspiciousReport> _fakerReportHistoryList;

        public ReportService()
        {
            var fakerReportHistory = new Faker<SuspiciousReport>()
                .RuleFor(bp => bp.ReportTitle, f => f.Lorem.Sentence())
                .RuleFor(bp => bp.ReportDescription, f => f.Lorem.Paragraphs())
                .RuleFor(bp => bp.ReportDateTime, f => f.Date.Past())
                .RuleFor(bp => bp.ReportType, f => f.PickRandomParam(new ReportType[] { ReportType.SuspiciousObject, ReportType.SuspiciousPlace, ReportType.SuspiciousPerson }))
                .RuleFor(bp => bp.ReportStatus, f => f.PickRandomParam(new ReportStatus[] { ReportStatus.Pending, ReportStatus.Investigating, ReportStatus.Resolved }))
                .RuleFor(bp => bp.ReportLocationLatitude, f => f.Address.Latitude())
                .RuleFor(bp => bp.ReportLocationLongitude, f => f.Address.Longitude())
                .RuleFor(bp => bp.ReportAddress, f => f.Address.FullAddress())
                .RuleFor(bp => bp.PhotoUrl, f => f.Image.PicsumUrl())
                .FinishWith((f, bp) => Console.WriteLine($"Fake ReportHistory generated!"));

            _fakerReportHistoryList = fakerReportHistory.Generate(20).ToList();
        }

        public List<SuspiciousReport> GetReportHistoryList()
        {
            return _fakerReportHistoryList;
        }

        public bool CreateReport(SuspiciousReport report)
        {
            return true;
        }
    }
}
