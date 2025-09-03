using AutoMapper;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.LeadMessage;
using lawyer.api.leads.application.DTO;
using MediatR;

namespace lawyer.api.leads.application.UseCases.LeadMessage.GetAll;

public class GetAllLeadMessageQueryHandler : IRequestHandler<GetAllLeadMessageQuery, List<LeadMessageDto>>
{
    private readonly ILeadMessageQueryRepository _query;
    private readonly IMapper _mapper;

    public GetAllLeadMessageQueryHandler(
        IMapper mapper,
        ILeadMessageQueryRepository query)
    {
        _mapper = mapper;
        _query = query;
    }

    public async Task<List<LeadMessageDto>> Handle(GetAllLeadMessageQuery request, CancellationToken cancellationToken)
    {
        var entities = await _query.GetAllAsync();
        return _mapper.Map<List<LeadMessageDto>>(entities);
    }
}

