using MediatR;
using FitSalon.WebUI.CQRS.Results.EmployeeResults;

namespace FitSalon.WebUI.CQRS.Queries.EmployeeQueries
{
    public class GetAllEmployeeQuery : IRequest<List<GetAllEmployeeQueryResult>>
    {

    }
}
