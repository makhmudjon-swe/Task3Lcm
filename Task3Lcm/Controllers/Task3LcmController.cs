using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Task3Lcm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Task3LcmController : Controller
    {
        [HttpGet("makhmudjon_swe_gmail_com")]
        public IActionResult GetLcm([FromQuery] string? x, [FromQuery] string? y)
        {
            if (!IsNatural(x) || !IsNatural(y))
                return Content("NaN", "text/plain");

            BigInteger a = BigInteger.Parse(x!);
            BigInteger b = BigInteger.Parse(y!);

            BigInteger result = Lcm(a, b);
            return Content(result.ToString(), "text/plain");
        }

        private static bool IsNatural(string? s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return false;

            if (!BigInteger.TryParse(s, out var n))
                return false;

            return n > 0;
        }

        private static BigInteger Gcd(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                var t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        private static BigInteger Lcm(BigInteger a, BigInteger b)
        {
            return (a / Gcd(a, b)) * b;
        }
    }
}
