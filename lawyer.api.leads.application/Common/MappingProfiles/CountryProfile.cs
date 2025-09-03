using AutoMapper;
using lawyer.api.leads.application.DTO;
using lawyer.api.leads.application.UseCases.Country.Create;
using lawyer.api.leads.application.UseCases.Country.Update;
using lawyer.api.leads.domain;

namespace lawyer.api.leads.application.Common.MappingProfiles;

public class CountryProfile : Profile
{
    public CountryProfile()
    {
        CreateMap<CountryDto, Country>().ReverseMap();
        CreateMap<CountryQueryDto, Country>().ReverseMap();
        CreateMap<CreateCountryCommand, Country>().ReverseMap();
        CreateMap<UpdateCountryCommand, Country>().ReverseMap();
    }
}
