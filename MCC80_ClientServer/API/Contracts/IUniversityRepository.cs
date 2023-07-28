using API.Models;

namespace API.Contracts
{
    public interface IUniversityRepository : IGeneralRepository<University> //buat interface IUniversityRepository yang mewarisi interface IGeneralRepository dari entity University
    {
        IEnumerable<University> GetByName(string name);
        Guid GetLastUniversityGuid();
        bool isNotExist(string value);
        University? GetByCode(string code); // panggil method yg dibuat di repository
    }
}
