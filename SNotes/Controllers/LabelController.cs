using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SNotes.Models;
using SNotes.Repositories;
using SNotes.ViewModels;

namespace SNotes.Controllers
{
    public class LabelController : Controller
    {

        // GET: Label
        public ActionResult Index()
        {
            return View();
        }

        private readonly ILabelRepository _repository;

        public LabelController(ILabelRepository repository)
        {
            _repository = repository;
        }


        // GET: Note


        public ActionResult LabelList()
        {
            var labels = _repository.GetLabelList();

            return View(labels);

            //var memberId = User.Identity.GetUserId();

            //var labels = _context.Labels.Where(x => x.UserId == memberId).ToList();

            //return View("_labelListPartial", labels);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new AddLabelViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AddLabelViewModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.Save(model);
                return RedirectToAction("NoteList", "Note");
            }

            return View(model);


            //var memberId = User.Identity.GetUserId();
            //var label= new Label()
            //{
            //    Name = model.Name,
            //    UserId = memberId
            //};

            //_context.Labels.AddOrUpdate(label);
            //_context.SaveChanges();

            //return RedirectToAction("NoteList", "Note");
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var model = _repository.Get(id);
            return View(model);

            
            //var label = _context.Labels.SingleOrDefault(l => l.Id == id);
            //if (label == null)

            //    return HttpNotFound();

            //return View("Edit", label);
        }

        [HttpPost]
        public ActionResult Edit(EditLabelViewModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(model);
                return RedirectToAction("Notelist", "Note");
            }

            return View(model);

            //var label = _context.Labels.Single(l => l.Id == model.Id);
            //label.Name = model.Name;
            //_context.SaveChanges();

            //return RedirectToAction("NoteList", "Note");
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            _repository.Delete(id);

            return RedirectToAction("NoteList", "Note");

            //var label = _context.Labels.Single(x => x.Id == id);
            //_context.Labels.Remove(label);
            //_context.SaveChanges();

            //return RedirectToAction("Notelist", "Note");
           
        }

        public ActionResult GetLabelListForNote()
        {

            var labels = _repository.GetLabelListForNote();

            return View("_labelListForNotePartial", labels);

            //var memberId = User.Identity.GetUserId();

            //var labels = _context.Notes.Where(x => x.UserId == memberId).SelectMany(x => x.Labels);

            //return View("_labelListForNotePartial", labels);
        }

    }
}