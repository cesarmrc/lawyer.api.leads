using lawyer.api.leads.application.DTO;
using MediatR;

namespace lawyer.api.leads.application.UseCases.Lead.GetById;

public class GetByIdLeadQuery : IRequest<LeadDto>
{
    public GetByIdLeadQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
