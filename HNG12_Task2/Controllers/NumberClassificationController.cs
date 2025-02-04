using HNG12_Task2.DTOs;
using HNG12_Task2.Services;
using Microsoft.AspNetCore.Mvc;

namespace HNG12_Task2.Controllers;

[ApiController]
[Route("api/classify-number")]
public class NumberClassificationController : ControllerBase
{
    private readonly INumberClassificationService _numberClassificationService;

    public NumberClassificationController(INumberClassificationService numberClassificationService)
    {
        _numberClassificationService = numberClassificationService;
    }

    [HttpGet]
    public async Task<IActionResult> ClassifyNumber([FromQuery] NumberClassificationRequest request)
    {
        if (!int.TryParse(request.Number.ToString(), out int parsedNumber))
        {
            return BadRequest(new { 
                number = "The number must be a valid integer.", error = true });
        }

        var response = await _numberClassificationService.ClassifyNumberAsync(parsedNumber);
        return Ok(response);
    }
}
