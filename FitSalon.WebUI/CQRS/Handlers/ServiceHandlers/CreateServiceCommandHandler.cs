using FitSalon.DataAccessLayer.Concrete;
using FitSalon.WebUI.CQRS.Commands.ServiceCommands;

namespace FitSalon.WebUI.CQRS.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler
    {
        private readonly Context _context;

        public CreateServiceCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateServiceCommand command)
        {
            _context.Services.Add(new EntityLayer.Concrete.Service
            {
                City = command.City,
                Price = command.Price,
                DayNight = command.DayNight,
                Capacity = command.Capacity,
                Status = true
            });
            _context.SaveChanges();
        }
    }
}
