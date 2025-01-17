using InterfaceTestingDocument_Api.Models;
using InterfaceTestingDocument_Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterfaceTestingDocument_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ITestService _testService;
        public HomeController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpPost("SaveSRTest")]
        public async Task<IActionResult> SaveSRTest([FromBody] SRTestRequest request)
        {
            var response = await _testService.SaveSRTest(request);
            if (response.Success)
            {
                return Ok(response);
            }

            return StatusCode(500, response);
        }
    }
}
