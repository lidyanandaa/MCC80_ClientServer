﻿using API.DTOs.AccountRoles;
using API.DTOs.Universities;
using API.Models;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/accountroles")]
    [Authorize]
    public class AccountRoleController : ControllerBase
    {
        private readonly AccountRoleService _accountRoleService;

        public AccountRoleController(AccountRoleService accountRoleService)
        {
            _accountRoleService = accountRoleService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _accountRoleService.GetAll();
            if (!result.Any())
            {
                return NotFound(new ResponseHandler<IEnumerable<AccountRoleDto>>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Guid is not found"
                });
            }

            return Ok(new ResponseHandler<IEnumerable<AccountRoleDto>>
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
            var result = _accountRoleService.GetByGuid(guid);
            if (result is null)
            {
                return NotFound(new ResponseHandler<AccountRoleDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Guid is not found",
                    Data = result
                });
            }

            return Ok(new ResponseHandler<AccountRoleDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data",
                Data = result
            });
        }

        [HttpPost]
        public IActionResult Insert(NewAccountRoleDto newAccountRoleDto)
        {
            var result = _accountRoleService.Create(newAccountRoleDto);
            if (result is null)
            {
                return StatusCode(500, new ResponseHandler<NewAccountRoleDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Error retrieve from database"
                });
            }

            return Ok(new ResponseHandler<NewAccountRoleDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data",
                Data = newAccountRoleDto
            });
        }

        [HttpPut]
        public IActionResult Update(AccountRoleDto accountRoleDto)
        {
            var result = _accountRoleService.Update(accountRoleDto);

            if (result is -1)
            {
                return NotFound(new ResponseHandler<AccountRoleDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Guid is not found"
                });
            }

            if (result is 0)
            {
                return StatusCode(500, new ResponseHandler<AccountRoleDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Error retrieve from database"
                });
            }

            return Ok(new ResponseHandler<AccountRoleDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success update data"
            });
        }

        [HttpDelete]
        public IActionResult Delete(Guid guid)
        {
            var result = _accountRoleService.Delete(guid);


            if (result is -1)
            {
                return NotFound(new ResponseHandler<AccountRoleDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Guid is not found"
                });
            }

            if (result is 0)
            {
                return StatusCode(500, new ResponseHandler<AccountRoleDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Error retrieve from database"
                });
            }

            return Ok(new ResponseHandler<AccountRoleDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success delete data"
            });
        }
    }
}
