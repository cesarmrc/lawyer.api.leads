using AutoMapper;
using lawyer.api.leads.application.Contracts.Interfaces.Persistence.City;
using lawyer.api.leads.application.DTO;
using MediatR;

namespace lawyer.api.leads.application.UseCases.City.GetById;

public class GetByIdCityQueryHandler : IRequestHandler<GetByIdCityQuery, CityDto>
{
    private readonly IMapper _mapper;
    private readonly ICityQueryRepository _query;

    public GetByIdCityQueryHandler(
        IMapper mapper,
        ICityQueryRepository query)
    {
        _mapper = mapper;
        _query = query;
    }

    public async Task<CityDto> Handle(GetByIdCityQuery request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetByIdAsync(request.Id);
        return _mapper.Map<CityDto>(entity);
    }
}
