using FitSalon.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using FitSalon.WebUI.CQRS.Queries.ServiceQueries;
using FitSalon.WebUI.CQRS.Results.ServiceResults;

namespace FitSalon.WebUI.CQRS.Handlers.ServiceHandlers
{
    public class GetAllServiceQueryHandler
    {
        private readonly Context _context;

        public GetAllServiceQueryHandler(Context context)
        {
            this._context = context;
        }

        public List<GetAllServiceQueryResult> Handle()
        {
            var values = _context.Services.Select(x => new GetAllServiceQueryResult
            {
                ID = x.ServiceID,
                City = x.City,
                Capacity = x.Capacity,
                DayNight = x.DayNight,
                Price = x.Price
            }).AsNoTracking().ToList();
            return values;
        }
    }
}
