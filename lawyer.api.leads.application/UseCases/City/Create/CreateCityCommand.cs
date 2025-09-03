using MediatR;

namespace lawyer.api.leads.application.UseCases.City.Create;

public class CreateCityCommand : IRequest<Guid>
{
    public Guid IdCountry { get; set; }
    public string Name { get; set; } = string.Empty;
}
