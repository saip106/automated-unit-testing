using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting.Sample.Tests
{
    [TestClass]
    public class when_retrieving_a_patient_by_id
    {
        private PatientRetriever _patientRetriever;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            _patientRetriever = new PatientRetriever();
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
            var _patientDto = _patientRetriever.Retrieve(1);

            //Assert
            _patientDto.Age.Should().Be(47);
        }
    }

    [TestClass]
    public class when_retrieving_a_patient_by_id_with_no_middle_name
    {
        private PatientRetriever _patientRetriever;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            _patientRetriever = new PatientRetriever();
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
