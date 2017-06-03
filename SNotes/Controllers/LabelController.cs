using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SNotes.Models;
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

        private ApplicationDbContext _context;

        public LabelController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: Note
        

        public ActionResult LabelList()
        {
            var memberId = User.Identity.GetUserId();
            

            //var employees = db.Employees.Where(emp => emp.role.Any(r => r.Id == 12));
            //var xx = db.Produtos.Include(x => x.Aplicacoes.Select(y => y.Produtos)).ToList()

            //var labels = _context.Labels.Include(l => l.Notes.Select(x => x.UserId == memberId)).ToList();


            var labels = _context.Labels.ToList();
            

            return View("_labelListPartial", labels);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Label label)
        {
            //var memberId = User.Identity.GetUserId();
            //var note = new Note()
            //{
            //    UserId = memberId,
            //    Content = model.Content,
            //    CreationTime = DateTime.Now,
            //    ModificationTime = DateTime.Now

            //};

            _context.Labels.AddOrUpdate(label);
            _context.SaveChanges();

            return RedirectToAction("NoteList", "Note");
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var label = _context.Labels.SingleOrDefault(l => l.Id == id);
            if (label == null)

                return HttpNotFound();
            
            return View("Edit", label);
        }

        [HttpPost]
        public ActionResult Edit(Label model)
        {

            var label = _context.Labels.Single(l => l.Id == model.Id);
            label.Name = model.Name;
            _context.SaveChanges();

            return RedirectToAction("NoteList", "Note");
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            var label = _context.Labels.Single(x => x.Id == id);
            _context.Labels.Remove(label);
            _context.SaveChanges();

            return RedirectToAction("Notelist", "Note");
        }
    }
}