using InterfaceTestingDocument_Api.Models;

namespace InterfaceTestingDocument_Api.Repository
{
    public interface ITestRepository
    {
        Task<bool> SaveTestData(SRTestRequest request);
        Task<bool> SaveOqcInspectionAsync(OqcInspection oqcInspection);
    }
}
