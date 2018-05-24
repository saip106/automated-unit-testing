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
    }
}