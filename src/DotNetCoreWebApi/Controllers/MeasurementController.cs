﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreWebApi.Model;
using DotNetCoreWebApi.Repozytorium;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebApi.Controllers
{
    [Route("api/measurement")]
    [ApiController]
    public class MeasurementController : Controller
    {
        private readonly IMeasurementRepository<Measurement> _measurementRepository;

        public MeasurementController(IMeasurementRepository<Measurement> measurementRepository)
        {
            _measurementRepository = measurementRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var measurements = await _measurementRepository.GetAll();

            return Ok(measurements);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(long id)
        {
            var measurement = await _measurementRepository.Get(id);

            if(measurement == null)
            {
                return NotFound("The measurement record couldnt be found.");
            }

            return Ok(measurement);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Measurement measurement)
        {
            if (measurement == null)
            {
                return BadRequest("Measurement is null");
            }

            await _measurementRepository.Add(measurement);

            return CreatedAtAction(nameof(Get), new { id = measurement.Id }, measurement);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Measurement measurement)
        {
            var measurementToUpdate = await _measurementRepository.Get(id);

            if (measurementToUpdate == null)
            {
                return NotFound("The measurement record couldnt be found.");
            }

            await _measurementRepository.Update(measurementToUpdate, measurement);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var measurementToDelete = await _measurementRepository.Get(id);

            if (measurementToDelete == null)
            {
                return NotFound("The measurement record couldnt be found.");
            }

            await _measurementRepository.Delete(measurementToDelete);

            return NoContent();
        }
    }
}