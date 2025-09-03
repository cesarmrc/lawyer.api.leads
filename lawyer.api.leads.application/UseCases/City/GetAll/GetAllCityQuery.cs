using lawyer.api.leads.application.DTO;
using MediatR;

namespace lawyer.api.leads.application.UseCases.City.GetAll;

public class GetAllCityQuery : IRequest<List<CityDto>>, IRequest<CityDto>
{
}
