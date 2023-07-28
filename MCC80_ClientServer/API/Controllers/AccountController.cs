﻿using API.DTOs.Accounts;
using API.DTOs.Universities;
using API.Models;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly EmployeeService _employeeService;

        public AccountController(AccountService accountService, EmployeeService employee)
        {
            _accountService = accountService;
            _employeeService = employee;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _accountService.GetAll();
            if (!result.Any())
            {
                return NotFound(new ResponseHandler<IEnumerable<AccountDto>>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Guid is not found"
                });
            }

            return Ok(new ResponseHandler<IEnumerable<AccountDto>>
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
            var result = _accountService.GetByGuid(guid);
            if (result is null)
            {
                return NotFound(new ResponseHandler<AccountDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Guid is not found",
                    Data = result
                });
            }

            return Ok(new ResponseHandler<AccountDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data",
                Data = result
            });
        }

        [HttpPost]
        public IActionResult Insert(NewAccountDto newAccountDto)
        {
            var result = _accountService.Create(newAccountDto);
            if (result is null)
            {
                return StatusCode(500, new ResponseHandler<NewAccountDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Error retrieve from database"
                });
            }

            return Ok(new ResponseHandler<NewAccountDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data",
                Data = newAccountDto
            });
        }

        [HttpPut]
        public IActionResult Update(AccountDto accountDto)
        {
            var result = _accountService.Update(accountDto);

            if (result is -1)
            {
                return NotFound(new ResponseHandler<AccountDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Guid is not found"
                });
            }

            if (result is 0)
            {
                return StatusCode(500, new ResponseHandler<AccountDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Error retrieve from database"
                });
            }

            return Ok(new ResponseHandler<AccountDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success update data"
            });
        }

        [HttpDelete]
        public IActionResult Delete(Guid guid)
        {
            var result = _accountService.Delete(guid);


            if (result is -1)
            {
                return NotFound(new ResponseHandler<AccountDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Guid is not found"
                });
            }

            if (result is 0)
            {
                return StatusCode(500, new ResponseHandler<AccountDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Error retrieve from database"
                });
            }

            return Ok(new ResponseHandler<AccountDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success delete data"
            });
        }

        [HttpPost("login")] //kenapa login pake http post karena ada validasi untuk inputannya
        public IActionResult Login(LoginDto loginDto)
        {
            var result = _accountService.Login(loginDto);

            if (result is 0)
            {
                return NotFound(new ResponseHandler<LoginDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Email or Password is incorrect"
                });
            }

            return Ok(new ResponseHandler<LoginDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Login Success"
            });
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            var result = _accountService.Register(registerDto);
            if (result == 0)
            {
                return StatusCode(500, new ResponseHandler<RegisterDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Email or PhoneNumber is already registered."
                });
            }

            if (result == 1)
            {
                return Ok(new ResponseHandler<RegisterDto>
                {
                    Code = StatusCodes.Status200OK,
                    Status = HttpStatusCode.OK.ToString(),
                    Message = "Registration success"
                });
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<RegisterDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Error retrive from database"
            });
        }

        [HttpPost("forgotpassword")]
        public IActionResult ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            var isUpdated = _accountService.ForgotPasswordDto(forgotPasswordDto);
            if (isUpdated == 0)
                return NotFound(new ResponseHandler<ForgotPasswordDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Email not found"
                });

            if (isUpdated is -1)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<ForgotPasswordDto>
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Error retrieving data from the database"
                });

            return Ok(new ResponseHandler<ForgotPasswordDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Otp has been sent to your email"
            });
        }


        [HttpPost("changepassword")]
        public IActionResult UpdatePassword(ChangePasswordDto changePasswordDto)
        {
            var update = _accountService.ChangePassword(changePasswordDto);
            if (update == 0)
            {
                return NotFound(new ResponseHandler<ChangePasswordDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Email not found"
                });
            }

            if (update == -1)
            {
                return NotFound(new ResponseHandler<ChangePasswordDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "OTP doesn't match"
                });
            }

            if (update == -2)
            {
                return NotFound(new ResponseHandler<ChangePasswordDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "OTP is used"
                });
            }

            if (update == -3)
            {
                return NotFound(new ResponseHandler<ChangePasswordDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Otp Already Expired"
                });
            }

            return Ok(new ResponseHandler<ChangePasswordDto>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Succesfuly Updated"
            });
        }
    }
}
