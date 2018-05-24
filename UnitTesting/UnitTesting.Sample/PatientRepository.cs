using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace UnitTesting.Sample
{
    public class PatientRepository
    {
        public Patient GetPatientById(int id)
        {
            var patientsJson = File.ReadAllText(@"c:\temp\patients.json");
            var patients = JsonConvert.DeserializeObject<Patient[]>(patientsJson);
            return patients.Single(x => x.Id == id);
        }

        public void AddPatient(Patient patient)
        {
            var patientsJson = File.ReadAllText(@"c:\temp\patients.json");
            var patients = JsonConvert.DeserializeObject<List<Patient>>(patientsJson);
            patients.Add(patient);
            var updatedPatientJson = JsonConvert.SerializeObject(patients);
            File.WriteAllText(@"c:\temp\patients.json", updatedPatientJson);
        }

        public Patient[] GetAll()
        {
            var patientsJson = File.ReadAllText(@"c:\temp\patients.json");
            return JsonConvert.DeserializeObject<Patient[]>(patientsJson);
        }
    }
}