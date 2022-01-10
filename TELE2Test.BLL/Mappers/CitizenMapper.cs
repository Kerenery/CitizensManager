using AutoMapper;
using TELE2Test.BLL.DTO_s;
using TELE2Test.DAL.Entities;

namespace TELE2Test.BLL.Mappers;

public class CitizenMapper : Profile
{
    public CitizenMapper()
    {
        CreateMap<CitizenDTO, Citizen>();
        CreateMap<Citizen, CitizenDTO>();
    }
}