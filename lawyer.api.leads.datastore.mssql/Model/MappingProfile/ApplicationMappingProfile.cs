using AutoMapper;
using lawyer.api.leads.domain;
using lawyer.api.leads.datastore.mssql.Model;

namespace lawyer.api.leads.datastore.mssql.Model.MappingProfile;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<Example, ExampleEntity>().ReverseMap();
        CreateMap<City, CityEntity>().ReverseMap();
        CreateMap<Country, CountryEntity>().ReverseMap();
        CreateMap<LeadState, LeadStateEntity>().ReverseMap();
    }
}
