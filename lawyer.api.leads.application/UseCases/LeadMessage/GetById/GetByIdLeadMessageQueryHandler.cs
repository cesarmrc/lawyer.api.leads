using AutoMapper;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.LeadMessage;
using lawyer.api.leads.application.DTO;
using MediatR;

namespace lawyer.api.leads.application.UseCases.LeadMessage.GetById;

public class GetByIdLeadMessageQueryHandler : IRequestHandler<GetByIdLeadMessageQuery, LeadMessageDto>
{
    private readonly IMapper _mapper;
    private readonly ILeadMessageQueryRepository _query;

    public GetByIdLeadMessageQueryHandler(
        IMapper mapper,
        ILeadMessageQueryRepository query)
    {
        _mapper = mapper;
        _query = query;
    }

    public async Task<LeadMessageDto> Handle(GetByIdLeadMessageQuery request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetByIdAsync(request.Id);
        return _mapper.Map<LeadMessageDto>(entity);
    }
}

