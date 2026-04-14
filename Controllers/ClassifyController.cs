using Genderize.Dtos;
using Genderize.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Genderize.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassifyController : ControllerBase
    {
        private readonly IGenderizeService _genderizeService;
        private readonly ILogger<ClassifyController> _logger;

        public ClassifyController(IGenderizeService genderizeService, ILogger<ClassifyController> logger)
        {
            _genderizeService = genderizeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Classify(string name)
        {
            try
            {
                // Validate name parameter
                if (string.IsNullOrWhiteSpace(name))
                {
                    return BadRequest(new ErrorResponse
                    {
                        Message = "Missing or empty name parameter"
                    });
                }

                if (!name.GetType().Equals(typeof(string)))
                {
                    return UnprocessableEntity(new ErrorResponse
                    {
                        Message = "name is not a string"
                    });
                }

                // Call Genderize API
                var prediction = await _genderizeService.GetGenderPredictionAsync(name);

                if (prediction == null)
                {
                    return StatusCode(502, new ErrorResponse
                    {
                        Message = "Upstream API failure"
                    });
                }

                // Check if prediction is available
                if (string.IsNullOrEmpty(prediction.Gender) || prediction.Count == 0)
                {
                    return UnprocessableEntity(new ErrorResponse
                    {
                        Message = "No prediction available for the provided name"
                    });
                }

                // Calculate is_confident
                bool isConfident = (prediction.Probability >= 0.7 && prediction.Count >= 100);

                // Build response
                var response = new ClassifyResponse
                {
                    Data = new ClassifyData
                    {
                        Name = name.ToLower(),
                        Gender = prediction.Gender,
                        Probability = prediction.Probability,
                        SampleSize = prediction.Count,
                        IsConfident = isConfident,
                        ProcessedAt = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")
                    }
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error in classify endpoint");
                return StatusCode(500, new ErrorResponse
                {
                    Message = "Internal server error"
                });
            }

        }
    }
}
