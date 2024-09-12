using FitSalon.DataAccessLayer.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FitSalon.WebUI.CQRS.Queries.EmployeeQueries;
using FitSalon.WebUI.CQRS.Results.EmployeeResults;

namespace FitSalon.WebUI.CQRS.Handlers.EmployeeHandlers
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery,List<GetAllEmployeeQueryResult>>
    {
        private readonly Context _context;

        public GetAllEmployeeQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllEmployeeQueryResult>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _context.Employees.Select(x => new GetAllEmployeeQueryResult
            {
                EmployeeID = x.EmployeeID,
                EmployeeName = x.EmployeeName,
                Description = x.Description,
                Image = x.Image,
            }).AsNoTracking().ToListAsync();
        }
    }
}
