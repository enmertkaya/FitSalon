using FitSalon.DataAccessLayer.Concrete;
using MediatR;
using FitSalon.WebUI.CQRS.Commands.EmployeeCommands;
using FitSalon.WebUI.CQRS.Queries.EmployeeQueries;
using FitSalon.WebUI.CQRS.Results.EmployeeResults;

namespace FitSalon.WebUI.CQRS.Handlers.EmployeeHandlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly Context _context;

        public UpdateEmployeeCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Employees.FindAsync(request.EmployeeID);
            values.EmployeeName = request.EmployeeName;
            values.Description = request.Description;
            values.Image = request.Image;
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
