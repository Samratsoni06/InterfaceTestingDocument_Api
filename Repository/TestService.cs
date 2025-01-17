using InterfaceTestingDocument_Api.Models;

namespace InterfaceTestingDocument_Api.Repository
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _repository;
        public TestService(ITestRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse> SaveSRTest(SRTestRequest request)
        {
            if (request == null)
            {
                return new ApiResponse
                {
                    Success = false,
                    Error = "Invalid request data.",
                    UnAuthorizedRequest = false,
                    __abp = true
                };
            }

            var success = await _repository.SaveTestData(request);
            if (success)
            {
                return new ApiResponse
                {
                    Result = null,
                    TargetUrl = null,
                    Success = true,
                    Error = null,
                    UnAuthorizedRequest = false,
                    __abp = true
                };
            }

            return new ApiResponse
            {
                Result = null,
                TargetUrl = null,
                Success = false,
                Error = "An error occurred while saving the data.",
                UnAuthorizedRequest = false,
                __abp = true
            };
        }
    }
}
