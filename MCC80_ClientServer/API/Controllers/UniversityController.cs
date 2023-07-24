﻿using API.DTOs.Universities;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/univerities")]
    public class UniversityController : ControllerBase
    {
        private readonly UniversityService _universityService;

        public UniversityController(UniversityService universityService)
        {
            _universityService = universityService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _universityService.GetAll();
            if (!result.Any())
            {
                return NotFound("No Data Found");
            }

            return Ok(result);
        }

        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var result = _universityService.GetByGuid(guid);
            if (result is null)
            {
                return NotFound("Guid is not found");
            }

            return Ok(result);  
        }

        [HttpPost]
        public IActionResult Insert(NewUniversityDto newUniversityDto)
        {
            //Mapping manual
           /* var university = new University();
            university.Guid = Guid.NewGuid();
            university.Name = newUniversityDto.Name;
            university.Code = newUniversityDto.Code;
            university.CreatedDate = DateTime.Now;
            university.ModifiedDate = university.CreatedDate;*/

            var result = _universityService.Create(newUniversityDto);

            if (result is null)
            {
                return StatusCode(500, "Error Retrieve from database");
            }

            //Mapping manual
            /*var universityDto = new UniversityDto();
            universityDto.Guid = result.Guid;
            universityDto.Code = result.Code;
            universityDto.Name = result.Name;*/

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(UniversityDto universityDto)
        {
            var result = _universityService.Update(universityDto);

            if (result is -1)
            {
                return NotFound("Guid is not found");
            }

            if (result is 0)
            {
                return StatusCode(500, "Error Retrieve from database");
            }

            return Ok("Update success");
        }

        [HttpDelete]
        public IActionResult Delete(Guid guid)
        {
            var result = _universityService.Delete(guid);

            if (result is -1)
            {
                return NotFound("Guid is not found");
            }

            if (result is 0)
            {
                return StatusCode(500, "Error Retrieve from database");
            }

            return Ok("Delete success");
        }
    }
}
