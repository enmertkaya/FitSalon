using FitSalon.DataAccessLayer.Concrete;
using FitSalon.WebUI.CQRS.Queries.ServiceQueries;
using FitSalon.WebUI.CQRS.Results.ServiceResults;

namespace FitSalon.WebUI.CQRS.Handlers.ServiceHandlers
{
    public class GetServiceByIDQueryHandler
    {
        private readonly Context _context;

        public GetServiceByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public GetServiceByIDQueryResult Handle(GetServiceByIDQuery query)
        {
            var values = _context.Services.Find(query.id);
            return new GetServiceByIDQueryResult
            {
                ServiceID = values.ServiceID,
                City = values.City,
                DayNight = values.DayNight,
                Price = values.Price,
                Capacity = values.Capacity, 
                
            };
        }
    }
}
