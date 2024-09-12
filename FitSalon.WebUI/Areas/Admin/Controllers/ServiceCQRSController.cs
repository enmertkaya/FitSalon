using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FitSalon.WebUI.CQRS.Commands.ServiceCommands;
using FitSalon.WebUI.CQRS.Handlers.ServiceHandlers;
using FitSalon.WebUI.CQRS.Queries.ServiceQueries;

namespace FitSalon.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]

    public class ServiceCQRSController : Controller
    {
        private readonly GetAllServiceQueryHandler _getAllServiceQueryHandler;
        private readonly GetServiceByIDQueryHandler _getServiceByIDQueryHandler;
        private readonly CreateServiceCommandHandler _createServiceCommandHandler;
        private readonly DeleteServiceCommandHandler _deleteServiceCommandHandler;
        private readonly UpdateServiceCommandHandler _updateServiceCommandHandler;

        public ServiceCQRSController(GetAllServiceQueryHandler getAllServiceQueryHandler, GetServiceByIDQueryHandler getServiceByIDQueryHandler, CreateServiceCommandHandler createServiceCommandHandler, DeleteServiceCommandHandler deleteServiceCommandHandler, UpdateServiceCommandHandler updateServiceCommandHandler)
        {
            _getAllServiceQueryHandler = getAllServiceQueryHandler;
            _getServiceByIDQueryHandler = getServiceByIDQueryHandler;
            _createServiceCommandHandler = createServiceCommandHandler;
            _deleteServiceCommandHandler = deleteServiceCommandHandler;
            _updateServiceCommandHandler = updateServiceCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getAllServiceQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult GetService(int id)
        {
            var values = _getServiceByIDQueryHandler.Handle(new GetServiceByIDQuery(id));
            return View(values);
        }

        [HttpPost]
        public IActionResult GetService(UpdateServiceCommand command)
        {
            _updateServiceCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddService(CreateServiceCommand command)
        {
            _createServiceCommandHandler.Handle(command);
            return RedirectToAction("Index");  
        }

        public IActionResult DeleteService(int id)
        {
            _deleteServiceCommandHandler.Handle(new DeleteServiceCommand(id));
            return RedirectToAction("Index");
        }
    }
}
