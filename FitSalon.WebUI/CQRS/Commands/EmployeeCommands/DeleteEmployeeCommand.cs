using MediatR;

namespace FitSalon.WebUI.CQRS.Commands.EmployeeCommands
{
    public class DeleteEmployeeCommand : IRequest
    {
        public int ID { get; set; }

        public DeleteEmployeeCommand(int ıD)
        {
            ID = ıD;
        }
    }
}
