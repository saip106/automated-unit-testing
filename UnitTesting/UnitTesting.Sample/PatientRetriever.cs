using System;

namespace UnitTesting.Sample
{
    public class PatientRetriever
    {
        public PatientDto Retrieve(int id)
        {
            new Logger().Log($"Finding patient by id {id}");

            var patientRepository = new PatientRepository();
            var dbPatient = patientRepository.GetPatientById(id);
            if (dbPatient == null) return null;
            {
                
            }
            return new PatientDto
            {
                FullName = $"{dbPatient.LastName}, {dbPatient.FirstName} {dbPatient.MiddleName}".Trim(),
                Age = DateTime.Now.Year - dbPatient.DateOfBirth.Year
            };
        }
    }
}
