using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SNotes.Models;
using SNotes.ViewModels;

namespace SNotes.Controllers
{
    public class NoteController : Controller
    {
        private ApplicationDbContext _context;

        public NoteController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Note
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NoteList()
        {

            var allNotes = _context.Notes.Select(n => new NoteGridViewModel
            {
                Content = n.Content,
                Id = n.Id

            });

            return View(allNotes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();

            return RedirectToAction("NoteList", "Note");
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var note = _context.Notes.SingleOrDefault(n => n.Id == id);
            if (note == null)

                return HttpNotFound();

            var viewModel = new EditNoteViewModel
            {
                Content = note.Content

            };
            return View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Note note)
        {
            _context.Notes.AddOrUpdate(note);
            _context.SaveChanges();

            return RedirectToAction("NoteList", "Note");
        }


        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        public ActionResult Delete(long id)
        {

            var note = _context.Notes.SingleOrDefault(n => n.Id == id);

            _context.Notes.Remove(note);
            _context.SaveChanges();

            return RedirectToAction("NoteList");

        }
    }
}