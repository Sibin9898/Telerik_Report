
using APIhub.JWT;
using APIhub.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace APIhub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {

        private readonly TokenGeneration _tokenGeneration;

        public ReportController(TokenGeneration tokenGeneration)
        {
            _tokenGeneration = tokenGeneration;
        }

        [HttpGet ("GetToken")]
        public async Task<IActionResult>GetToken(string key)
        {
            key = "lNpA9a3lciOa+IExVrveH5rWvRbV3qK68Ll06LK2Xnw=";
            var result = await _tokenGeneration.JWTTokenAsync(key).ConfigureAwait(false);
            return Ok(new { token = result });
        }

        [Authorize]
        [HttpPost]
        [Route("GetItemMasterReports")]
        public ActionResult GetItemMasterReports([FromBody] RequestModel request)
        {
            CompanyHeader company = new CompanyHeader
            {
                Name = "TechCorp",
                Image = new byte[] { 255, 0, 255 }, 
                Addrs = "123 Silicon Valley, CA",
                Items = new List<ItemDetails>
                {
                    new ItemDetails { ItemCode = "ITM001", ItemName = "Laptop", DateOfPurchase = DateTime.Now.AddMonths(-2), Quantity = 10 },
                    new ItemDetails { ItemCode = "ITM002", ItemName = "Printer", DateOfPurchase = DateTime.Now.AddMonths(-1), Quantity = 5 }
                }
            };

            return Ok(company);
        }
    }
}
