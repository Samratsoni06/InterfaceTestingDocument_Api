using InterfaceTestingDocument_Api.Models;
using System.Threading.Tasks;

namespace InterfaceTestingDocument_Api.Repository
{
    public interface ITestRepository
    {
        Task<bool> SaveTestData(SRTestRequest request);
    }
}
