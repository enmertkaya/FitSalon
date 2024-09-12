using MediatR;

namespace FitSalon.WebUI.CQRS.Commands.EmployeeCommands
{
    public class UpdateEmployeeCommand : IRequest
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
