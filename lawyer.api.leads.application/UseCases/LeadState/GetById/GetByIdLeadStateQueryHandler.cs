using AutoMapper;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.LeadState;
using lawyer.api.leads.application.DTO;
using MediatR;

namespace lawyer.api.leads.application.UseCases.LeadState.GetById;

public class GetByIdLeadStateQueryHandler : IRequestHandler<GetByIdLeadStateQuery, LeadStateDto>
{
    private readonly ILeadStateQueryRepository _query;
    private readonly IMapper _mapper;

    public GetByIdLeadStateQueryHandler(ILeadStateQueryRepository query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<LeadStateDto> Handle(GetByIdLeadStateQuery request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetByIdAsync(request.Id);
        return _mapper.Map<LeadStateDto>(entity);
    }
}

