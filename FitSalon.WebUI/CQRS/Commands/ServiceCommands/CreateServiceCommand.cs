namespace FitSalon.WebUI.CQRS.Commands.ServiceCommands
{
    public class CreateServiceCommand
    {
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
        public string Capacity { get; set; }
        public bool Status { get; set; }
    }
}
