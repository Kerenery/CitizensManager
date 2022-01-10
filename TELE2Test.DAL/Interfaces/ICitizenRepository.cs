using TELE2Test.DAL.Entities;
using TELE2Test.DAL.Tools;

namespace TELE2Test.DAL.Interfaces;

public interface ICitizenRepository : IRepository<Citizen>
{
    Task<IEnumerable<Citizen>> GetAllBySex(SexType? sex);
    Task<IEnumerable<Citizen>> GetAllByAge();
}