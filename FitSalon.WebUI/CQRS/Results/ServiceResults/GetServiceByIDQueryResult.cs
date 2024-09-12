namespace FitSalon.WebUI.CQRS.Results.ServiceResults
{
    public class GetServiceByIDQueryResult
    {
        public int ServiceID { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public string Capacity { get; set; }
        public double Price { get; set; }
    }
}
