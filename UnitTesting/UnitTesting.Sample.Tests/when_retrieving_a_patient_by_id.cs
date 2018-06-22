using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstituteAutoMocker;

namespace UnitTesting.Sample.Tests
{
    [TestClass]
    public class when_retrieving_a_patient_by_id
    {
        private PatientRetriever _patientRetriever;

        [TestInitialize]
        public void Initialize()
        {
            var autoMocker = new NSubstituteAutoMocker<PatientRetriever>();

            autoMocker
                .Get<IPatientRepository>()
                .GetPatientById(1)
                .Returns(new Patient
                {
                    FirstName = "John1",
                    LastName = "Nath1",
                    MiddleName = "K1",
                    DateOfBirth = DateTime.Parse("1971-01-01")
                });

            //Arrange
            _patientRetriever = autoMocker.ClassUnderTest;
        }

        [TestMethod]
        public void it_should_get_valid_fullname()
        {
            //Act
            var _patientDto = _patientRetriever.Retrieve(1);

            //Assert
            _patientDto.FullName.Should().Be("Nath1, John1 K1");
        }

        [TestMethod]
        public void it_should_get_valid_age()
        {
            //Act
            var patient = _patientRetriever.Retrieve(1);

            //Assert
            patient.Age.Should().Be(47);
        }
    }
}