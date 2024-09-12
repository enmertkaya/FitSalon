using FitSalon.DataAccessLayer.Concrete;
using FitSalon.WebUI.CQRS.Commands.ServiceCommands;

namespace FitSalon.WebUI.CQRS.Handlers.ServiceHandlers
{
    public class DeleteServiceCommandHandler
    {
        private readonly Context _context;

        public DeleteServiceCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(DeleteServiceCommand command)
        {
            var values = _context.Services.Find(command.ID);
            _context.Services.Remove(values);
            _context.SaveChanges();
        }
    }
}
