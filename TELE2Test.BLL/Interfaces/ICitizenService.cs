using TELE2Test.BLL.DTO_s;
using TELE2Test.DAL.Tools;

namespace TELE2Test.BLL.Interfaces;

public interface ICitizenService
{
    Task<IEnumerable<CitizenDTO>> GetAllAsync();
    Task<IEnumerable<CitizenDTO>> GetAllByAge();
    Task<IEnumerable<CitizenDTO>> GetAllBySex(SexType? sex);
    Task<CitizenDTO> GetCitizenAsync(string id);
    Task CreateCitizenAsync(CitizenDTO employee);
    Task UpdateCitizenAsync(JsonCitizenDto jsonCitizenDto);
    Task UpdateCitizenAsync(CitizenDTO employee);
    Task DeleteCitizenAsync(Guid id);
    Task AddManyCitizens(string json);
}