using lawyer.api.leads.application.DTO;
using MediatR;

namespace lawyer.api.leads.application.UseCases.LeadMessage.GetAll;

public class GetAllLeadMessageQuery : IRequest<List<LeadMessageDto>>, IRequest<LeadMessageDto>
{
}

