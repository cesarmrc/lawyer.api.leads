using AutoMapper;
using lawyer.api.leads.application.DTO;
using lawyer.api.leads.application.UseCases.LeadState.Create;
using lawyer.api.leads.application.UseCases.LeadState.Update;
using lawyer.api.leads.domain;

namespace lawyer.api.leads.application.Common.MappingProfiles;

public class LeadStateProfile : Profile
{
    public LeadStateProfile()
    {
        CreateMap<LeadStateDto, LeadState>().ReverseMap();
        CreateMap<CreateLeadStateCommand, LeadState>().ReverseMap();
        CreateMap<UpdateLeadStateCommand, LeadState>().ReverseMap();
    }
}

