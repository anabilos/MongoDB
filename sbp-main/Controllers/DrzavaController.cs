using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Galerija.Models;
using Galerija.Services;

namespace Galerija.Controllers
{
    
    public class DrzavaController : Controller 
    {
        private  DrzavaService _subSvc;

        public DrzavaController(DrzavaService drzavaService)
        {
            _subSvc = drzavaService;
        }

      
        public ActionResult<IList<Drzava>> Index() => View(_subSvc.Read());

        [HttpGet]
        public ActionResult Create() => View();
        
        [HttpPost]
    
        public ActionResult<Drzava> Create(Drzava drzava){
            if(ModelState.IsValid){
                _subSvc.Create(drzava);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult<Drzava> Edit(string id) => 
            View(_subSvc.Find(id));

        [HttpPost]

        public ActionResult Edit(Drzava drzava)
        {
            if(ModelState.IsValid){
                _subSvc.Update(drzava);
                return RedirectToAction("Index");
            }
            return View(drzava);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            _subSvc.Delete(id);
            return RedirectToAction("Index");
        }
    }
}