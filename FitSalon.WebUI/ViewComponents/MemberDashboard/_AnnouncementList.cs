﻿
using FitSalon.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FitSalon.WebUI.ViewComponents.MemberDashboard
{
    public class _AnnouncementList : ViewComponent
    {
        private readonly IAnnouncementService _announcementService;

        public _AnnouncementList(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _announcementService.TGetList();
            return View(values);
        }
    }
}
