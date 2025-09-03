using AutoMapper;
using lawyer.api.leads.application.DTO;
using lawyer.api.leads.application.UseCases.Lead.Create;
using lawyer.api.leads.application.UseCases.Lead.Update;
using lawyer.api.leads.domain;

namespace lawyer.api.leads.application.Common.MappingProfiles;

public class LeadProfile : Profile
{
    public LeadProfile()
    {
        CreateMap<LeadDto, Lead>().ReverseMap();
        CreateMap<CreateLeadCommand, Lead>().ReverseMap();
        CreateMap<UpdateLeadCommand, Lead>().ReverseMap();
    }
}
