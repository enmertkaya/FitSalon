namespace FitSalon.WebUI.CQRS.Queries.ServiceQueries
{
    public class GetServiceByIDQuery
    {
        public GetServiceByIDQuery(int id)
        {
            this.id = id;
        }

        public  int id { get; set; }
    }
}
