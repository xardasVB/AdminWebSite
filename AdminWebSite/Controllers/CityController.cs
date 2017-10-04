using AdminWebSite.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AdminWebSite.Models;
using AdminWebSite.DAL.Entities;

namespace AdminWebSite.Controllers
{
    public class CityController : Controller
    {
        EFContext _context;
        public CityController()
        {
            _context = new EFContext();
            ViewBag.MenuCity = true;
        }
        // GET: City
        public ActionResult Index()
        {
            var model = _context
                .Cities
                .Include(c => c.Country)
                .Select(c => new CityViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    DateCreate = c.DateCreate,
                    Priority = c.Priority,
                    Country = c.Country.Name
                })
                .OrderByDescending(c => c.Priority);
            return View(model);
        }
        public ActionResult Create()
        {
            CityCreateViewModel model = new CityCreateViewModel();
            model.Countries = _context
                .Countries
                .Select(c => new SelectItemViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(CityCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Are you retarded or something?");
                return View(model);
            }
            City city = new City
            {
                DateCreate = DateTime.Now,
                Name = model.Name,
                Priority = model.Priority,
                CountryId = model.CountryId
            };
            _context.Cities.Add(city);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _context.Cities.Remove(_context.Cities.FirstOrDefault(c => c.Id == id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            City city = _context.Cities.FirstOrDefault(c => c.Id == id);
            CityEditViewModel model = new CityEditViewModel();
            model.Countries = _context
                .Countries
                .Select(c => new SelectItemViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();
            model.Name = city.Name;
            model.Priority = city.Priority;
            model.CountryId = city.CountryId;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(CityEditViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Are you retarded or something?");
                return View(model);
            }
            _context.Cities.FirstOrDefault(c => c.Id == id).Name = model.Name;
            _context.Cities.FirstOrDefault(c => c.Id == id).Priority = model.Priority;
            _context.Cities.FirstOrDefault(c => c.Id == id).CountryId = model.CountryId;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            City city = _context.Cities.FirstOrDefault(c => c.Id == id);
            CityViewModel model = new CityViewModel
            {
                Name = city.Name,
                Priority = city.Priority,
                DateCreate = city.DateCreate,
                Country = city.Country.Name,
                Id = city.Id
            };
            return View(model);
        }
    }
}