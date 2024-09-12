using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FitSalon.WebUI.CQRS.Commands.ServiceCommands;
using FitSalon.WebUI.CQRS.Commands.EmployeeCommands;
using FitSalon.WebUI.CQRS.Handlers.ServiceHandlers;
using FitSalon.WebUI.CQRS.Queries.EmployeeQueries;
using FitSalon.WebUI.CQRS.Queries.ServiceQueries;

namespace FitSalon.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]

    public class EmployeeMediatRController : Controller
    {
        private readonly IMediator _mediator;

        public EmployeeMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllEmployeeQuery());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees(int id)
        {
            var values = await _mediator.Send(new GetEmployeeByIDQuery(id));
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> GetEmployees(UpdateEmployeeCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult AddEmployees()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployees(CreateEmployeeCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _mediator.Send(new DeleteEmployeeCommand(id));
            return RedirectToAction("Index");
        }

    }
}
