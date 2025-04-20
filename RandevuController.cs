using Microsoft.AspNetCore.Mvc;
using RandevuSistemi.Models;

namespace RandevuSistemi.Controllers
{
    public class RandevuController : Controller
    {
        private static List<Randevu> _randevular = new();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Randevu model)
        {
            if (ModelState.IsValid)
            {
                _randevular.Add(model);
                ViewBag.Basarili = true;
                return View();
            }
            return View(model);
        }

        public IActionResult Admin()
        {
            return View(_randevular);
        }

        public IActionResult Sil(int index)
        {
            if (index >= 0 && index < _randevular.Count)
                _randevular.RemoveAt(index);

            return RedirectToAction("Admin");
        }
    }
}
