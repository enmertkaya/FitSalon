using FitSalon.DataAccessLayer.Concrete;
using FitSalon.WebUI.CQRS.Commands.ServiceCommands;

namespace FitSalon.WebUI.CQRS.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler
    {
        private readonly Context _context;

        public UpdateServiceCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateServiceCommand command)
        {
            var values = _context.Services.Find(command.ServiceID);
            values.Capacity = command.Capacity;
            values.DayNight = command.DayNight;
            values.Price = command.Price;
            values.City = command.City;
            values.Status = true;
            _context.SaveChanges();
        }
    }
}
