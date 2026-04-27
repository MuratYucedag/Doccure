using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutScriptsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
