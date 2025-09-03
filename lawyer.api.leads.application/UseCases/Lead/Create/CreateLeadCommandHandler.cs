using AutoMapper;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.Lead;
using MediatR;

namespace lawyer.api.leads.application.UseCases.Lead.Create;

public class CreateLeadCommandHandler : IRequestHandler<CreateLeadCommand, Guid>
{
    private readonly ILeadCommandRepository _command;
    private readonly IMapper _mapper;

    public CreateLeadCommandHandler(
        ILeadCommandRepository command,
        IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<domain.Lead>(request);
        await _command.CreateAsync(entity);
        return entity.Id;
    }
}
