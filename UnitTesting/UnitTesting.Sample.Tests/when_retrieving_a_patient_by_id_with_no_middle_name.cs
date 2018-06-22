using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstituteAutoMocker;

namespace UnitTesting.Sample.Tests
{
    [TestClass]
    public class when_retrieving_a_patient_by_id_with_no_middle_name
    {
        private PatientRetriever _patientRetriever;

        [TestInitialize]
        public void Initialize()
        {
            var autoMocker = new NSubstituteAutoMocker<PatientRetriever>();

            autoMocker
                .Get<IPatientRepository>()
                .GetPatientById(5)
                .Returns(new Patient
                {
                    FirstName = "John5",
                    LastName = "Nath5"
                });

            //Arrange
            _patientRetriever = autoMocker.ClassUnderTest;
        }

        [TestMethod]
        public void it_should_not_have_middle_initial()
        {
            //Act
            var _patientDto = _patientRetriever.Retrieve(5);

            //Assert
            _patientDto.FullName.Should().Be("Nath5, John5");
        }
    }
}
