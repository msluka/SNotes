using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SNotes.Models;
using SNotes.ViewModels;
using Microsoft.AspNet.Identity;

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
            var memberId = User.Identity.GetUserId();
            if (memberId == null)
                return RedirectToAction("Login", "Account");

            var userNotes = _context.Notes.Where(n => n.UserId == memberId)
                .Select(n => new NoteGridViewModel
                {
                    Content = n.Content,
                    Id = n.Id,
                    CreationTime = n.CreationTime,
                    ModificationTime = n.ModificationTime

                })
                .OrderByDescending(o => o.CreationTime);

            
            return View(userNotes);
            
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AddNoteViewModel model)
        {
            var memberId = User.Identity.GetUserId();
            var note = new Note()
            {
                UserId = memberId,
                Content = model.Content,
                CreationTime = DateTime.Now,
                ModificationTime = DateTime.Now

            };

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
                Content = note.Content,
                Id = note.Id,

            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditNoteViewModel model)
        {

            var note = _context.Notes.Single(x => x.Id == model.Id);
            note.ModificationTime = DateTime.Now;
            note.Content = model.Content;
            _context.SaveChanges();

            return RedirectToAction("NoteList", "Note");
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            var customer = _context.Notes.Single(x => x.Id == id);
            _context.Notes.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("NoteList", "Note");
        }
        //[AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        //public ActionResult Delete(long id)
        //{

        //    var note = _context.Notes.SingleOrDefault(n => n.Id == id);

        //    _context.Notes.Remove(note);
        //    _context.SaveChanges();

        //    return RedirectToAction("NoteList");

        //}

        public ActionResult Search(string searchString)
        {
            var memberId = User.Identity.GetUserId();
            if (memberId == null)
                return RedirectToAction("Login", "Account");


            var searchResult = _context.Notes.Where(n => n.UserId == memberId && n.Content.Contains(searchString))
                   .Select(n => new NoteGridViewModel
                   {
                       Content = n.Content,
                       Id = n.Id,
                       CreationTime = n.CreationTime,
                       ModificationTime = n.ModificationTime

                   });

            return View("NoteList", searchResult);

        }

        public ActionResult Sort(string sortOrder)
        {
            var memberId = User.Identity.GetUserId();
            if (memberId == null)
                return RedirectToAction("Login", "Account");

            if (sortOrder == "Number1")
            {
                var searchResult = _context.Notes.Where(n => n.UserId == memberId)
                    .Select(n => new NoteGridViewModel
                    {
                        Content = n.Content,
                        Id = n.Id,
                        CreationTime = n.CreationTime,
                        ModificationTime = n.ModificationTime

                        //}).OrderByDescending(n => n.CreationTime);
                    }).OrderByDescending(n => n.CreationTime);

                return View("NoteList", searchResult);

            }

            if (sortOrder == "Number2")
            {
                var searchResult = _context.Notes.Where(n => n.UserId == memberId)
                    .Select(n => new NoteGridViewModel
                    {
                        Content = n.Content,
                        Id = n.Id,
                        CreationTime = n.CreationTime,
                        ModificationTime = n.ModificationTime

                    }).OrderBy(n => n.ModificationTime);

                return View("NoteList", searchResult);
            }

            return View("NoteList");
        }
    }
}
