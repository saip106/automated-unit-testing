using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace UnitTesting.Sample
{
    public class PatientRepository
    {
        private readonly Logger _logger = new Logger();

        public Patient GetPatientById(int id)
        {
            _logger.Log($"Finding patient by id {id} from file");
            var patientsJson = File.ReadAllText(@"c:\temp\patients.json");
            var patients = JsonConvert.DeserializeObject<Patient[]>(patientsJson);
            return patients.Single(x => x.Id == id);
        }

        public void AddPatient(Patient patient)
        {
            _logger.Log("Adding new patient");

            var patientsJson = File.ReadAllText(@"c:\temp\patients.json");
            var patients = JsonConvert.DeserializeObject<List<Patient>>(patientsJson);
            patients.Add(patient);
            var updatedPatientJson = JsonConvert.SerializeObject(patients);
            File.WriteAllText(@"c:\temp\patients.json", updatedPatientJson);
        }

        public Patient[] GetAll()
        {
            _logger.Log("Getting all patients");

            var patientsJson = File.ReadAllText(@"c:\temp\patients.json");
            return JsonConvert.DeserializeObject<Patient[]>(patientsJson);
        }
    }
}