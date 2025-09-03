using lawyer.api.leads.application.DTO;
using MediatR;

namespace lawyer.api.leads.application.UseCases.Lead.GetAll;

public class GetAllLeadQuery : IRequest<List<LeadDto>>, IRequest<LeadDto>
{
}
