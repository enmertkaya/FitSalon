using FitSalon.DataAccessLayer.Concrete;
using MediatR;
using FitSalon.WebUI.CQRS.Commands.EmployeeCommands;

namespace FitSalon.WebUI.CQRS.Handlers.EmployeeHandlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand>
    {
        private readonly Context _context;

        public CreateEmployeeCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            _context.Employees.Add(new EntityLayer.Concrete.Employee
            {
                EmployeeName = request.EmployeeName,
                Description = request.Description,
                Image = request.Image
            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
