using AutoMapper;
using lawyer.api.leads.application.DTO;
using lawyer.api.leads.application.UseCases.LeadMessage.Create;
using lawyer.api.leads.application.UseCases.LeadMessage.Update;
using lawyer.api.leads.domain;

namespace lawyer.api.leads.application.Common.MappingProfiles;

public class LeadMessageProfile : Profile
{
    public LeadMessageProfile()
    {
        CreateMap<LeadMessageDto, LeadMessage>().ReverseMap();
        CreateMap<CreateLeadMessageCommand, LeadMessage>().ReverseMap();
        CreateMap<UpdateLeadMessageCommand, LeadMessage>().ReverseMap();
    }
}

