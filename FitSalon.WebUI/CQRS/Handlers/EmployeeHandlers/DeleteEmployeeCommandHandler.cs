using FitSalon.DataAccessLayer.Concrete;
using MediatR;
using FitSalon.WebUI.CQRS.Commands.EmployeeCommands;

namespace FitSalon.WebUI.CQRS.Handlers.EmployeeHandlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly Context _context;

        public DeleteEmployeeCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Employees.FindAsync(request.ID);
            _context.Employees.Remove(values);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
