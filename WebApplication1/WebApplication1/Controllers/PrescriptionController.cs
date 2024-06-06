using Microsoft.AspNetCore.Mvc;
using WebApplication1.Context;
using WebApplication1.Models.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PrescriptionController : ControllerBase
{
   
    private readonly PrescriptionService _prescriptionService;
    public PrescriptionController(PrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody]InsertPrescription insertPrescription)
    {
        if (!await _prescriptionService.DoesPatientExist(insertPrescription))
        {
            await _prescriptionService.InsertPatient(insertPrescription);
        }

        if (!await _prescriptionService.DoesMedicamentExist(insertPrescription))
        {
            return NotFound("One of given medicines does not exist");
        }

        if (await _prescriptionService.DoesPrescriptionHaveMoreThan10Meds(insertPrescription))
        {
            return BadRequest("Prescription can not have more than 10 medicines");
        }

        if (!await _prescriptionService.DoesDueDateIsGreaterThanDate(insertPrescription))
        {
            return BadRequest("Date is greater than due date. Medicine probably expired");
        }
        

        await _prescriptionService.InsertPrescription(insertPrescription);
        return Ok("Given prescription has been added\n" + insertPrescription);
    }

}   