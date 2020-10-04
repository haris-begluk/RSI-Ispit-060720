using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RS1_Ispit_asp.net_core.EF;
using RS1_Ispit_asp.net_core.ViewModels;
using System;
using System.Linq;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class TakmicenjeController : Controller
    {
        private readonly MojContext _context;

        public TakmicenjeController(MojContext mojContext)
        {
            _context = mojContext;
        }
        // GET: TakmicenjeController
        public ActionResult Index(int id)
        {
            var model = new TakmicenjeVM
            {
                SkolaId = id,
                Skole = _context.Skola.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Naziv }).ToList(),
                Data = _context.Takmicenje.Where(t => t.SkolaId.Equals(id)).Select(t => new Row
                {
                    Datum = t.Datum,
                    Predmet = t.Predmet.Naziv,
                    Razred = t.Razred,
                    Skola = t.Skola.Naziv,
                    TakmicenjeId = t.Id,
                    NajboljiUcenik = _context.TakmicenjeUcesnik
                    .Where(u => u.Id.Equals(t.Id))
                    .OrderByDescending(x => x.Bodovi)
                    .Select(o => o.OdjeljenjeStavka.Odjeljenje.Skola.Naziv + "|" +
                    o.OdjeljenjeStavka.Odjeljenje.Oznaka + "|" + o.OdjeljenjeStavka.Ucenik.ImePrezime)
                    .FirstOrDefault()
                }).ToList()
            };

            return View(model);
        }


        public ActionResult SkolaTakmicenja(int id = 1)
        {
            var model = new TakmicenjeVM
            {
                SkolaId = id,
                Skole = _context.Skola.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Naziv }).ToList(),
                Data = _context.Takmicenje.Where(t => t.SkolaId.Equals(id)).Select(t => new Row
                {
                    Datum = t.Datum,
                    Predmet = t.Predmet.Naziv,
                    Razred = t.Razred,
                    Skola = t.Skola.Naziv,
                    TakmicenjeId = t.Id,
                    NajboljiUcenik = _context.TakmicenjeUcesnik
                    .Where(u => u.Id.Equals(t.Id))
                    .OrderByDescending(x => x.Bodovi)
                    .Select(o => o.OdjeljenjeStavka.Odjeljenje.Skola.Naziv + "|" +
                    o.OdjeljenjeStavka.Odjeljenje.Oznaka + "|" + o.OdjeljenjeStavka.Ucenik.ImePrezime)
                    .FirstOrDefault()
                }).ToList()
            };

            return PartialView("SkolaTakmicenjaPartial", model);
        }
        [HttpGet]
        public ActionResult DodajTakmicenje()
        {

            var model = new DodajTakmicenjeVM
            {
                Predmeti = _context.Predmet.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Naziv }).ToList(),
                DTSkole = _context.Skola.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Naziv }).ToList(),
                Datum = DateTime.Now
            };

            return PartialView("DodajTakmicenjePartial", model);
        }
        [HttpPost]
        public void DodajTakmicenje(DodajTakmicenjeVM model)
        {

            _context.Takmicenje.Add(new EntityModels.Takmicenje
            {
                PredmetId = model.PredmetId,
                SkolaId = model.DTSkolaId,
                Datum = model.Datum,
                Zakljucaj = false
            });
            _context.SaveChanges();
            RedirectToAction("Index", model.DTSkolaId);
        }
        // GET: TakmicenjeController/Create
        public ActionResult Create()
        {
            return View();
        }


    }
}
