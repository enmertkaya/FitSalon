using FitSalon.DataAccessLayer.Concrete;
using MediatR;
using NuGet.Protocol.Plugins;
using FitSalon.WebUI.CQRS.Queries.EmployeeQueries;
using FitSalon.WebUI.CQRS.Results.EmployeeResults;

namespace FitSalon.WebUI.CQRS.Handlers.EmployeeHandlers
{
    public class GetEmployeeByIDQueryHandler : IRequestHandler<GetEmployeeByIDQuery, GetEmployeeByIDQueryResult>
    {
        private readonly Context _context;

        public GetEmployeeByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetEmployeeByIDQueryResult> Handle(GetEmployeeByIDQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Employees.FindAsync(request.ID);
            return new GetEmployeeByIDQueryResult
            {
                EmployeeID = values.EmployeeID,
                Description = values.Description,
                EmployeeName = values.EmployeeName,
                Image = values.Image,
            };
        }
    }
}
