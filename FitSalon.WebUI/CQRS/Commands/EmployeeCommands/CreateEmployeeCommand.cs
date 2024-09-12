using MediatR;

namespace FitSalon.WebUI.CQRS.Commands.EmployeeCommands
{
    public class CreateEmployeeCommand : IRequest 
    {
        public string EmployeeName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
