using AutoMapper;
using Newtonsoft.Json;
using TELE2Test.BLL.DTO_s;
using TELE2Test.BLL.Interfaces;
using TELE2Test.DAL.Context;
using TELE2Test.DAL.Entities;
using TELE2Test.DAL.Interfaces;
using TELE2Test.DAL.Repositories;
using TELE2Test.DAL.Tools;

namespace TELE2Test.BLL.Services;

public class CitizenService : ICitizenService
{
    private readonly IMapper _mapper;
    private readonly ICitizenRepository _repository;

    public CitizenService(IMapper mapper, TELE2TestContext context)
    {
        _mapper = mapper;
        _repository = new CitizenRepository(context);
    }

    public async Task<IEnumerable<CitizenDTO>> GetAllAsync()
    {
        var citizensDal = await _repository.GetAllAsync();
        return citizensDal
            .Select(citizensDAL => _mapper.Map<CitizenDTO>(citizensDAL))
            .ToList();
    }

    public Task<IEnumerable<CitizenDTO>> GetAllByAge()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CitizenDTO>> GetAllBySex(SexType? sex)
    {
        var citizensDal = await _repository.GetAllBySex(sex);
        return citizensDal
            .Select(citizensDAL => _mapper.Map<CitizenDTO>(citizensDAL))
            .ToList();
    }

    public async Task<CitizenDTO> GetCitizenAsync(string id)
    {
        var citizen = await _repository.GetByIdAsync(id);
        return _mapper.Map<CitizenDTO>(citizen);
    }

    public async Task CreateCitizenAsync(CitizenDTO citizenDto)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateCitizenAsync(CitizenDTO citizenDto)
    {
        var citizen = _mapper.Map<Citizen>(citizenDto);
        await _repository.UpdateAsync(citizen);
        await _repository.SaveAsync();
    }

    public async Task UpdateCitizenAsync(JsonCitizenDto jsonCitizen)
    {
        var citizenEntity = _mapper.Map<Citizen>(jsonCitizen);
        await _repository.UpdateAsync(citizenEntity);
        await _repository.SaveAsync();
    }

    public Task DeleteCitizenAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task AddManyCitizens(string json)
    {
        var citizensDto = JsonConvert.DeserializeObject<List<CitizenDTO>>(json);
        var citizensEntities = _mapper.Map<List<Citizen>>(citizensDto);
        await _repository.InsertManyAsync(citizensEntities);
        await _repository.SaveAsync();
    }

    public async Task UpdateManyCitizens(string json)
    {
        var citizensDto = JsonConvert.DeserializeObject<List<CitizenDTO>>(json);
        var citizensEntities = _mapper.Map<List<Citizen>>(citizensDto);
        await _repository.UpdateManyAsync(citizensEntities);
        await _repository.SaveAsync();
    }
}