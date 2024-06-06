using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly PatientService _patientService;

    public PatientController(PatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet]
    [Route("/{id}")]
    public async Task<IActionResult> GetPatient(int id)
    {

        if (!await _patientService.DoesPatientExist(id))
        {
            return NotFound("Patient with given Id does not exist");
        }

        var res = await _patientService.GetPatientInfo(id);
        
        return Ok(res);

    }
}

