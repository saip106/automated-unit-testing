using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting.Sample.Tests
{
    [TestClass]
    public class when_retrieving_a_patient_by_invalid_id
    {
        [TestMethod]
        public void it_should_throw_an_exception()
        {
            //Arrange
            var patientRetriever = new PatientRetriever();
            var patientDto = patientRetriever.Retrieve(0);
            patientDto.Should().BeNull();
        }
    }
}
