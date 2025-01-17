using InterfaceTestingDocument_Api.Models;
using System.Threading.Tasks;

namespace InterfaceTestingDocument_Api.Repository
{
    public interface ITestService
    {
        Task<ApiResponse> SaveSRTest(SRTestRequest request);
    }
}
