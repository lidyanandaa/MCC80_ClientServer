using API.DTOs.Universities;
using API.Models;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/univerities")]
    [Authorize(Roles = "Employee")]
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
                return NotFound(new ResponseHandler<IEnumerable<UniversityDto>>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Guid is not found"
                });
            }

            return Ok(new ResponseHandler<IEnumerable<UniversityDto>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data",
                Data = result
            });
        }

        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var result = _universityService.GetByGuid(guid);
            if (result is null)
            {
                return NotFound(new ResponseHandler<UniversityDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Guid is not found", 
                    Data = result
                });
            }

            return Ok(new ResponseHandler<UniversityDto>
            {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Success retrieve data", 
                    Data = result
            });  
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
                return StatusCode(500, new ResponseHandler<NewUniversityDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Error retrieve from database"
                });
            }

            //Mapping manual
            /*var universityDto = new UniversityDto();
            universityDto.Guid = result.Guid;
            universityDto.Code = result.Code;
            universityDto.Name = result.Name;*/

            return Ok(new ResponseHandler<NewUniversityDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data",
                Data = newUniversityDto
            });
        }

        [HttpPut]
        public IActionResult Update(UniversityDto universityDto)
        {
            var result = _universityService.Update(universityDto);

            if (result is -1)
            {
                return NotFound(new ResponseHandler<UniversityDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Guid is not found"
                });
            }

            if (result is 0)
            {
                return StatusCode(500, new ResponseHandler<UniversityDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Error retrieve from database"
                });
            }

            return Ok(new ResponseHandler<UniversityDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success update data"
            });
        }

        [HttpDelete]
        public IActionResult Delete(Guid guid)
        {
            var result = _universityService.Delete(guid);

            if (result is -1)
            {
                return NotFound(new ResponseHandler<UniversityDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Guid is not found"
                });
            }

            if (result is 0)
            {
                return StatusCode(500, new ResponseHandler<UniversityDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Error retrieve from database"
                });
            }

            return Ok(new ResponseHandler<UniversityDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success delete data"
            });
        }
    }
}
