using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services
{
    public class PatientService
    {
        private readonly ApplicationContext _context;

        public PatientService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetPrescritpion> GetPatientInfo(int id)
        {
            var patient = await _context.Patients
                .Where(p => p.IdPatient == id)
                .Select(p => new GetPrescritpion()
                {
                    IdPatient = p.IdPatient,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    BirthDate = p.BirthDate,
                    
                    PrescriptionDto = p.Prescription
                        .OrderBy(pre => pre.DueDate)
                        .Select(pre => new PrescriptionDTO()
                        {
                            IdPrescription = pre.IdPrescription,
                            Date = pre.Date,
                            DueDate = pre.DueDate,
                            
                            MedicamentsList = pre.Prescription_Medicaments
                                .Select(pm => new MedicamentsDTO()
                                {
                                    IdMedicament = pm.Medicament.IdMedicament,
                                    Name = pm.Medicament.Name,
                                    Description = pm.Medicament.Description,
                                    Dose = pm.Dose
                                }).ToList(),
                            
                            Doctor = new DoctorDTO()
                            {
                                IdDoctor = pre.Doctor.IdDoctor,
                                FirstName = pre.Doctor.FirstName
                            }
                        }).ToList()
                })
                .FirstOrDefaultAsync();

            return patient;
        }

        public async Task<bool> DoesPatientExist(int id)
        {
            var possiblePatient = await _context.Patients.FindAsync(id);
            return possiblePatient != null;
        }
    }
}
