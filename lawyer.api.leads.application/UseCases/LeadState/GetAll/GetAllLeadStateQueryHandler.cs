using AutoMapper;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.LeadState;
using lawyer.api.leads.application.DTO;
using MediatR;

namespace lawyer.api.leads.application.UseCases.LeadState.GetAll;

public class GetAllLeadStateQueryHandler : IRequestHandler<GetAllLeadStateQuery, List<LeadStateDto>>
{
    private readonly ILeadStateQueryRepository _query;
    private readonly IMapper _mapper;

    public GetAllLeadStateQueryHandler(IMapper mapper, ILeadStateQueryRepository query)
    {
        _mapper = mapper;
        _query = query;
    }

    public async Task<List<LeadStateDto>> Handle(GetAllLeadStateQuery request, CancellationToken cancellationToken)
    {
        var entities = await _query.GetAllAsync();
        return _mapper.Map<List<LeadStateDto>>(entities);
    }
}

