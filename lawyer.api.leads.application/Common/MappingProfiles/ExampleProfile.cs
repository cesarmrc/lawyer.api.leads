using AutoMapper;
using lawyer.api.leads.application.DTO;
using lawyer.api.leads.application.UseCases.Example.Create;
using lawyer.api.leads.application.UseCases.Example.Update;
using lawyer.api.leads.domain;

namespace lawyer.api.leads.application.Common.MappingProfiles;

public class ExampleProfile : Profile
{
    public ExampleProfile()
    {
        CreateMap<ExampleDto, Example>().ReverseMap();
        CreateMap<CreateExampleCommand, Example>().ReverseMap();
        CreateMap<UpdateExampleCommand, Example>().ReverseMap();
    }
}
