using AdminWebSite.DAL;
using AdminWebSite.DAL.Entities;
using AdminWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminWebSite.Controllers
{
    public class CountryController : Controller
    {
        EFContext _context;
        public CountryController()
        {
            _context = new EFContext();
        }
        // GET: Country
        public ActionResult Index()
        {
            List<CountryViewModel> model;
            model = _context
                .Countries
                .Select(c=> new CountryViewModel
                {
                    Id=c.Id,
                    Name=c.Name,
                    Priority=c.Priority,
                    DateCreate= c.DateCreate
                })
                .OrderByDescending(c=>c.Priority)
                .ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CountryCreateViewModel model)
        {
            Country country = new Country
            {
                DateCreate=DateTime.Now,
                Name=model.Name,
                Priority=model.Priority
            };
            _context.Countries.Add(country);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int countryId)
        {
            _context.Countries.Remove(_context.Countries.FirstOrDefault(c => c.Id == countryId));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int countryId)
        {
            Country country = _context.Countries.FirstOrDefault(c => c.Id == countryId);
            CountryEditViewModel model = new CountryEditViewModel
            {
                Name = country.Name,
                Priority = country.Priority
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(CountryEditViewModel model, int countryId)
        {
            _context.Countries.FirstOrDefault(c => c.Id == countryId).Name = model.Name;
            _context.Countries.FirstOrDefault(c => c.Id == countryId).Priority = model.Priority;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}