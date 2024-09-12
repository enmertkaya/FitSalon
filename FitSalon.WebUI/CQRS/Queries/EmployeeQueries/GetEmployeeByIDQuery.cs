using MediatR;
using FitSalon.WebUI.CQRS.Results.EmployeeResults;

namespace FitSalon.WebUI.CQRS.Queries.EmployeeQueries
{
    public class GetEmployeeByIDQuery : IRequest<GetEmployeeByIDQueryResult>
    {
        public int ID { get; set; }

        public GetEmployeeByIDQuery(int ıD)
        {
            ID = ıD;
        }
    }
}
