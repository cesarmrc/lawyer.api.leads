using AutoMapper;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.Lead;
using lawyer.api.leads.application.DTO;
using MediatR;

namespace lawyer.api.leads.application.UseCases.Lead.GetAll;

public class GetAllLeadQueryHandler : IRequestHandler<GetAllLeadQuery, List<LeadDto>>
{
    private readonly ILeadQueryRepository _query;
    private readonly IMapper _mapper;

    public GetAllLeadQueryHandler(IMapper mapper, ILeadQueryRepository query)
    {
        _mapper = mapper;
        _query = query;
    }

    public async Task<List<LeadDto>> Handle(GetAllLeadQuery request, CancellationToken cancellationToken)
    {
        var entities = await _query.GetAllAsync();
        return _mapper.Map<List<LeadDto>>(entities);
    }
}
