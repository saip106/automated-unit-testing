using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace UnitTesting.Sample.Tests
{
    [TestClass]
    public class when_retrieving_a_patient_by_invalid_id
    {
        [TestMethod]
        public void it_should_throw_an_exception()
        {
            var logger = Substitute.For<ILogger>();
            var patientRepository = Substitute.For<IPatientRepository>();

            //Arrange
            var patientRetriever = new PatientRetriever(logger, patientRepository);
            var patientDto = patientRetriever.Retrieve(0);
            patientDto.Should().BeNull();
        }
    }
}
