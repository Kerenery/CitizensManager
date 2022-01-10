using AutoMapper;
using TELE2Test.BLL.DTO_s;
using TELE2Test.DAL.Entities;

namespace TELE2Test.BLL.Mappers;

public class JsonCitizenMapper : Profile
{
    public JsonCitizenMapper()
    {
        CreateMap<JsonCitizenDto, Citizen>();
        CreateMap<Citizen, JsonCitizenDto>();
    }
}