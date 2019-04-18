using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.MiniBlog.Sessions;
using Microsoft.AspNetCore.Mvc;
using NUglify.Helpers;

namespace Abp.MiniBlog.Web.Views.Shared.Components.LeftSideBar
{
    public class LeftSideBarViewComponent: MiniBlogViewComponent
    {
        private readonly ISessionAppService _sessionAppService;

        public LeftSideBarViewComponent(ISessionAppService sessionAppService)
        {
            _sessionAppService = sessionAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var logInfo = await _sessionAppService.GetCurrentLoginInformations();
            return View(new LeftSideBarViewModel
            {
                Show = logInfo.User!=null
            });
        }
    }
}
