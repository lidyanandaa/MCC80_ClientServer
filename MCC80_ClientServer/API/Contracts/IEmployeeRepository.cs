﻿using API.Models;

namespace API.Contracts
{
    public interface IEmployeeRepository : IGeneralRepository<Employee>
    {
        //IEnumerable<Employee> GetByName(string name);
        bool isNotExist(string value);
        string GetAutoNik();
        Employee? GetByEmail(string email);
        Employee? CheckEmail(string email);
        Guid GetLastEmployeeGuid();
        //bool isSameGuid(Guid guid);
    }
}
