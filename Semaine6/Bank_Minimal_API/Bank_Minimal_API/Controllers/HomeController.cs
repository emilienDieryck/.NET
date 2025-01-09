using Microsoft.AspNetCore.Mvc;

namespace Bank_Minimal_API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string TVA(double price, string country)
        {
            if (country.Equals("BE"))
            {
                return price + (price * 0.21).ToString();
            }
            else if (country.Equals("FR"))
            {
                return price + (price * 0.20).ToString();
            }
            else
            {
                return "Country not supported";
            }
        }
    }
}
