using InterfaceTestingDocument_Api.Models;

namespace InterfaceTestingDocument_Api.Repository
{
    public interface ITestService
    {
        Task<ApiResponse> SaveSRTest(SRTestRequest request);
        Task<ApiResponse> SaveOqcInspection(OqcInspection oqcInspection);
    }
}
