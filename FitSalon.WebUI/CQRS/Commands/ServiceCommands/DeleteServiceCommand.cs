namespace FitSalon.WebUI.CQRS.Commands.ServiceCommands
{
    public class DeleteServiceCommand
    {
        public int ID { get; set; }

        public DeleteServiceCommand(int id)
        {
            ID = id;
        }
    }
}
