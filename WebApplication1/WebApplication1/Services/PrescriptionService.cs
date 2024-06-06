using WebApplication1.Context;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services;

public class PrescriptionService
{
    private readonly ApplicationContext _context;

    public PrescriptionService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task InsertPrescription(InsertPrescription NewPresc)
    {

        var Prescription = new Prescription()
        {
            IdPatient = NewPresc.PatientDto.IdPatient,
            Date = NewPresc.Date,
            DueDate = NewPresc.DueDate,
        };

        await _context.Prescriptions.AddAsync(Prescription);
        await _context.SaveChangesAsync();

        foreach (var medicamentDTO in NewPresc.MedicamentDto)
        {
            var prescriptionMedicament = new Prescription_Medicament
            {
                IdMedicament = medicamentDTO.IdMedicament,
                Dose = medicamentDTO.Dose,
                Details = medicamentDTO.Description
            };

             _context.PrescriptionMedicaments.Add(prescriptionMedicament);
        }
        _context.SaveChanges();
    }

    public async Task InsertPatient(InsertPrescription insertPrescription)
    {
        var Patient = new Patient()
        {
            IdPatient = insertPrescription.PatientDto.IdPatient,
            FirstName = insertPrescription.PatientDto.FirstName,
            LastName = insertPrescription.PatientDto.LastName,
            BirthDate = insertPrescription.PatientDto.BirthDate
        };
        await _context.Patients.AddAsync(Patient);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DoesPatientExist(InsertPrescription insertPrescription)
    {
        var possiblePatient = await _context
            .Patients
            .FindAsync(insertPrescription.PatientDto.IdPatient);

        if (possiblePatient == null)
        {
            return false;
        }

        return true;
    }
    public async Task<bool> DoesMedicamentExist(InsertPrescription insertPrescription)
    {
        foreach (var medicamentDto in insertPrescription.MedicamentDto)
        {
            var possibleMedicament = await _context
                .Medicaments
                .FindAsync(medicamentDto.IdMedicament);

            if (possibleMedicament == null)
            {
                return false;
            }
        }

        return true;
    }

    public async Task<bool> DoesDueDateIsGreaterThanDate(InsertPrescription insertPrescription)
    {
        if (insertPrescription.DueDate >= insertPrescription.Date)
        {
            return true;
        }

        return false;
    }

    public async Task<bool> DoesPrescriptionHaveMoreThan10Meds(InsertPrescription insertPrescription)
    {
        if (insertPrescription.MedicamentDto.ToArray().Length > 10 )
        {
            return true;
        }

        return false;
    }

}