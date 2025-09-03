using AutoMapper;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.LeadState;
using MediatR;

namespace lawyer.api.leads.application.UseCases.LeadState.Create;

public class CreateLeadStateCommandHandler : IRequestHandler<CreateLeadStateCommand, Guid>
{
    private readonly ILeadStateCommandRepository _command;
    private readonly IMapper _mapper;

    public CreateLeadStateCommandHandler(ILeadStateCommandRepository command, IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateLeadStateCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<domain.LeadState>(request);
        await _command.CreateAsync(entity);
        return entity.Id;
    }
}

