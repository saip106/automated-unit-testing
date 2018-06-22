using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UnitTesting.Sample
{
    public interface IPatientRepository
    {
        Patient GetPatientById(int id);
        void AddPatient(Patient patient);
        Patient[] GetAll();
    }

    public class PatientRepository : IPatientRepository
    {
        private readonly Logger _logger;

        public PatientRepository()
        {
            _logger = new Logger();
        }

        public Patient GetPatientById(int id)
        {
            _logger.Log($"Finding patient by id {id} from file");
            var patientsJson = File.ReadAllText(@"c:\temp\patients.json");
            var patients = JsonConvert.DeserializeObject<Patient[]>(patientsJson);

            return patients.SingleOrDefault(x => x.Id == id);
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

    [Serializable]
    public class PatientNotFoundException : Exception
    {
        public PatientNotFoundException()
        {
        }

        public PatientNotFoundException(string message) : base(message)
        {
        }

        public PatientNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected PatientNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}