using DiggRestProfil.Core.ProjectAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiggRestProfil.Core.Interfaces
{
    public interface ILabReportSearchService
    {
        Task<LabReport> GetAsync(Guid labReportId);
        Task<List<LabReport>> GetAsync(LabReportFilter filter);
    }
}
