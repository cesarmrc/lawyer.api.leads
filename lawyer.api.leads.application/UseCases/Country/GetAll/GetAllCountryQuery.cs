using lawyer.api.leads.application.DTO;
using MediatR;

namespace lawyer.api.leads.application.UseCases.Country.GetAll;

public class GetAllCountryQuery : IRequest<List<CountryQueryDto>>, IRequest<CountryQueryDto>
{
}
