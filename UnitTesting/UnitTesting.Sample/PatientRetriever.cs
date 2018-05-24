using System;

namespace UnitTesting.Sample
{
    public class PatientRetriever
    {
        public PatientDto Retrieve(int id)
        {
            var patientRepository = new PatientRepository();
            var dbPatient = patientRepository.GetPatientById(id);

            return new PatientDto
            {
                FullName = $"{dbPatient.LastName}, {dbPatient.FirstName} {dbPatient.MiddleName}",
                Age = DateTime.Now.Year - dbPatient.DateOfBirth.Year
            };
        }
    }
}
