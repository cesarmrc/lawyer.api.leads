using lawyer.api.leads.application.DTO;
using MediatR;

namespace lawyer.api.leads.application.UseCases.LeadMessage.GetById;

public class GetByIdLeadMessageQuery : IRequest<LeadMessageDto>
{
    public GetByIdLeadMessageQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}

