using System;

namespace UnitTesting.Sample
{
    public class PatientRetriever
    {
        private ILogger _logger;
        private IPatientRepository _patientRepository;

        public PatientRetriever(ILogger logger, IPatientRepository patientRepository)
        {
            _logger = logger;
            _patientRepository = patientRepository;
        }

        public PatientDto Retrieve(int id)
        {
            _logger.Log($"Finding patient by id {id}");

            var dbPatient = _patientRepository.GetPatientById(id);
            if (dbPatient == null) return null;

            var age = DateTime.Now.Year - dbPatient.DateOfBirth.Year;
            var fullName = $"{dbPatient.LastName}, {dbPatient.FirstName} {dbPatient.MiddleName}".Trim();

            var patientDto = new PatientDto
            {
                FullName = fullName,
                Age = age
            };
            return patientDto;
        }
    }

    
}
