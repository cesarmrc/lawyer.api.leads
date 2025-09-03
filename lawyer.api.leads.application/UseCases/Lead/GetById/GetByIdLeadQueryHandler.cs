using AutoMapper;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.Lead;
using lawyer.api.leads.application.DTO;
using MediatR;

namespace lawyer.api.leads.application.UseCases.Lead.GetById;

public class GetByIdLeadQueryHandler : IRequestHandler<GetByIdLeadQuery, LeadDto>
{
    private readonly IMapper _mapper;
    private readonly ILeadQueryRepository _query;

    public GetByIdLeadQueryHandler(
        IMapper mapper,
        ILeadQueryRepository query)
    {
        _mapper = mapper;
        _query = query;
    }

    public async Task<LeadDto> Handle(GetByIdLeadQuery request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetByIdAsync(request.Id);
        return _mapper.Map<LeadDto>(entity);
    }
}
