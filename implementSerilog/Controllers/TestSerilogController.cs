using implement.Core.Helpers;
using implement.Core.Model.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Serilog;
using System.Net;

namespace implementSerilog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestSerilogController : ControllerBase
    {
        private readonly AppSettings _appSettings;

        public TestSerilogController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        [HttpGet("TestErrorLogging")]
        public async Task<IActionResult> TestErrorLogging()
        {
            try
            {
                object obj = null;
                var test = obj.ToString(); 

                return Ok("No error occurred");
            }
            catch (Exception ex)
            {
                SecurityHelpers.InsertToLog(_appSettings.InsertLog, "TestErrorLogging - " + ex.ToString());
                return Ok(new
                {
                    TimeStamp = DateTime.Now,
                    ResponseCode = HttpStatusCode.InternalServerError,
                    Message = "خطا داخلی سرور رخ داده است",
                    Value = new { },
                    Error = new { message = ex.ToString() }
                });
            }
        }
    }
}
