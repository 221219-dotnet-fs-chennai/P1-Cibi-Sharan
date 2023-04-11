using Microsoft.AspNetCore.Mvc;
using POC_1.Models;

namespace POC_1.Controllers
{
    public class DateController : Controller
    {
        [HttpPost]
        public IActionResult SubmitForm(MyModel model)
        {
            if (ModelState.IsValid)
            {
                AddDate(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        private void AddDate(MyModel model)
        {
            throw new NotImplementedException();
        }
    }
}
