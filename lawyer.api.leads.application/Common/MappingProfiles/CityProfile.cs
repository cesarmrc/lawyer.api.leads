using AutoMapper;
using lawyer.api.leads.application.DTO;
using lawyer.api.leads.application.UseCases.City.Create;
using lawyer.api.leads.application.UseCases.City.Update;
using lawyer.api.leads.domain;

namespace lawyer.api.leads.application.Common.MappingProfiles;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<CityDto, City>().ReverseMap();
        CreateMap<CreateCityCommand, City>().ReverseMap();
        CreateMap<UpdateCityCommand, City>().ReverseMap();
    }
}
