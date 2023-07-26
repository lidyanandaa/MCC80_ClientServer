using API.Contracts;
using API.Data;
using API.DTOs.Accounts;
using API.Models;
using API.Repositories;
using API.Utilities.Handlers;

namespace API.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEducationRepository _educationRepository;
        private readonly IUniversityRepository _universityRepository;
        private readonly BookingDbContext _dbContext;

        public AccountService(IAccountRepository accountRepository, IEmployeeRepository employeeRepository, IEducationRepository educationRepository, IUniversityRepository universityRepository, BookingDbContext dbContext)
        {
            _accountRepository = accountRepository;
            _employeeRepository = employeeRepository;
            _educationRepository = educationRepository;
            _universityRepository = universityRepository;
            _dbContext = dbContext;
        }

        public IEnumerable<AccountDto> GetAll()
        {
            var accounts = _accountRepository.GetAll();
            if (!accounts.Any())
            {
                return Enumerable.Empty<AccountDto>(); // account is null or not found;
            }

            var accountDtos = new List<AccountDto>();
            foreach (var account in accounts)
            {
                accountDtos.Add((AccountDto)account);
            }

            return accountDtos; // account is found;
        }

        public AccountDto? GetByGuid(Guid guid)
        {
            var account = _accountRepository.GetByGuid(guid);
            if (account is null)
            {
                return null; // account is null or not found;
            }

            return (AccountDto)account; // account is found;
        }

        public AccountDto? Create(NewAccountDto newAccountDto)
        {
            var account = _accountRepository.Create(newAccountDto);
            if (account is null)
            {
                return null; // account is null or not found;
            }

            return (AccountDto)account; // account is found;
        }

        public int Update(AccountDto accountDto)
        {
            var account = _accountRepository.GetByGuid(accountDto.Guid);
            if (account is null)
            {
                return -1; // account is null or not found;
            }

            Account toUpdate = accountDto;
            toUpdate.CreatedDate = account.CreatedDate;
            var result = _accountRepository.Update(toUpdate);

            return result ? 1 // account is updated;
                : 0; // account failed to update;
        }

        public int Delete(Guid guid)
        {
            var account = _accountRepository.GetByGuid(guid);
            if (account is null)
            {
                return -1; // account is null or not found;
            }

            var result = _accountRepository.Delete(account);

            return result ? 1 // account is deleted;
                : 0; // account failed to delete;
        }

        public int Login(LoginDto loginDto)
        {
            var getEmployee = _employeeRepository.GetByEmail(loginDto.Email);

            if (getEmployee is null)
            {
                return 0; // Employee not found
            }

            var getAccount = _accountRepository.GetByGuid(getEmployee.Guid);

            if (getAccount.Password == loginDto.Password)
            {
                return 1; // Login success
            }

            return 0;
        }
        public int Register(RegisterDto registerDto)
        {
            if (!_employeeRepository.IsNotExist(registerDto.Email) || !_employeeRepository.IsNotExist(registerDto.PhoneNumber))
            {
                return 0;
            }

            var newNik = GenerateHandler.Nik(_employeeRepository.GetLastNik());
            var employeeGuid = Guid.NewGuid(); 

            
            var employee = new Employee
            {
                Guid = employeeGuid,
                Nik = newNik,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                BirthDate = registerDto.BirthDate,
                Gender = registerDto.Gender,
                HiringDate = registerDto.HiringDate,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber
            };
            _dbContext.Employees.Add(employee);

            
            var education = new Education
            {
                Guid = employeeGuid, 
                Major = registerDto.Major,
                Degree = registerDto.Degree,
                Gpa = (float)registerDto.Gpa
            };
            _dbContext.Educations.Add(education);

            
            var existingUniversity = _universityRepository.GetByCode(registerDto.UniversityCode);
            if (existingUniversity is null)
            {
                
                var university = new University
                {
                    Code = registerDto.UniversityCode,
                    Name = registerDto.UniversityName
                };
                _dbContext.Universities.Add(university);

                
                education.UniversityGuid = university.Guid;
            }
            else
            {
                
                education.UniversityGuid = existingUniversity.Guid;
            }

            
            var account = new Account
            {
                Guid = employeeGuid,
                Otp = registerDto.Otp,
                Password = registerDto.Password
            };
            _dbContext.Accounts.Add(account);

            try
            {
                _dbContext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
