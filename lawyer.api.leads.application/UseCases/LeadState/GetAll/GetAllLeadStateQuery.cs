using lawyer.api.leads.application.DTO;
using MediatR;

namespace lawyer.api.leads.application.UseCases.LeadState.GetAll;

public class GetAllLeadStateQuery : IRequest<List<LeadStateDto>>, IRequest<LeadStateDto>
{
}

