using AutoMapper;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.LeadMessage;
using MediatR;

namespace lawyer.api.leads.application.UseCases.LeadMessage.Create;

public class CreateLeadMessageCommandHandler : IRequestHandler<CreateLeadMessageCommand, Guid>
{
    private readonly ILeadMessageCommandRepository _command;
    private readonly IMapper _mapper;

    public CreateLeadMessageCommandHandler(
        ILeadMessageCommandRepository command,
        IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateLeadMessageCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<domain.LeadMessage>(request);
        await _command.CreateAsync(entity);
        return entity.Id;
    }
}

