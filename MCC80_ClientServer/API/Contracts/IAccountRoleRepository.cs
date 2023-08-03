using API.Models;

namespace API.Contracts
{
    public interface IAccountRoleRepository : IGeneralRepository<AccountRole>
    {
        //IEnumerable<AccountRole> GetByName(string name);
        IEnumerable<string>? GetRoleNamesByAccountGuid(Guid guid);
    }
}
