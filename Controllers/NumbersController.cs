using Microsoft.AspNetCore.Mvc;
using PortaTestTaskApi.Calculate;

namespace PortaTestTaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [DisableRequestSizeLimit]
    public class NumbersController : ControllerBase
    {
        [HttpPost("upload")]
        public IActionResult UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid file");
            }

            try
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    var content = reader.ReadToEnd();
                    var numbers = content.Split('\n')
                        .Select(str => int.TryParse(str, out int num) ? num : 0)
                        .ToList();

                    Calculation calculation = new Calculation();

                    var result = new
                    {
                        Max = numbers.Max(),
                        Min = numbers.Min(),
                        LongestIncreasingSequence = calculation.FindLongestIncreasingSequence(numbers),
                        LongestDecreasingSequence = calculation.FindLongestDecreasingSequence(numbers),
                        Median = calculation.CalculateMedian(numbers),
                        Average = numbers.Average()
                    };

                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}