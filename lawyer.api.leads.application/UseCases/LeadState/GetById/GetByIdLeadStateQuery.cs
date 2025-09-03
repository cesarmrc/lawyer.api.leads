using lawyer.api.leads.application.DTO;
using MediatR;

namespace lawyer.api.leads.application.UseCases.LeadState.GetById;

public class GetByIdLeadStateQuery : IRequest<LeadStateDto>
{
    public GetByIdLeadStateQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}

