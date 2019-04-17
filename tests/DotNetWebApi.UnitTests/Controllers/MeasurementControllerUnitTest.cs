using DotNetCoreWebApi.Controllers;
using DotNetCoreWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DotNetWebApi.UnitTests.Controllers
{
    public class MeasurementControllerUnitTest
    {
        [Fact]
        public async Task get_all_measurements()
        {
            // arange
            var repository = MeasurementContextMocker.GetInMemoryMeasurementsRepository(nameof(get_all_measurements));
            var controller = new MeasurementController(repository);

            // act
            var response = await controller.GetAll() as ObjectResult;
            var measurements = response.Value as List<Measurement>;

            // assert
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(5, measurements.Count);
        }

        [Fact]
        public async Task get_measurement_with_existing_id()
        {
            // arange
            var repository = MeasurementContextMocker.GetInMemoryMeasurementsRepository(nameof(get_measurement_with_existing_id));
            var controller = new MeasurementController(repository);
            var expectedValue = 0.25m;

            // act
            var response = await controller.Get(1) as ObjectResult;
            var measurements = response.Value as Measurement;

            // assert
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(expectedValue, measurements.Value);
        }

        //[Fact]
        //public async Task post_measurement_with_existing_id()
        //{
        //    // arange
        //    var repository = MeasurementContextMocker.GetInMemoryMeasurementsRepository(nameof(get_measurement_with_existing_id));
        //    var controller = new MeasurementController(repository);
        //    Measurement measurementToUpdate = new Measurement
        //    {
        //        Id = 1,
        //        Name = "Measurement_01",
        //        Value = 0.25m,
        //        CreatedBy = "Operator_01",
        //        CreatedAt = Convert.ToDateTime("2019/03/25 01:00:00 PM")
        //    }

        //    // act
        //    var response = await controller.Post(measurementToUpdate as ObjectResult;
        //    var measurements = response.Value as Measurement;

        //    // assert
        //    Assert.Equal(200, response.StatusCode);
        //    Assert.Equal(expectedValue, measurements.Value);
        //}
    }
}
