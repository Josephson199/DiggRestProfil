using DiggRestProfil.Core.Interfaces;
using DiggRestProfil.Core.ProjectAggregates;

namespace DiggRestProfil.Core.Services
{
    public class LabReportSearchService : ILabReportSearchService
    {
        public Task<LabReport> GetAsync(Guid labReportId)
        {
            throw new NotImplementedException();
        }

        public Task<List<LabReport>> GetAsync(LabReportFilter filter)
        {
            throw new NotImplementedException();
        }
    }
}
