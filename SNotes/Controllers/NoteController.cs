using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SNotes.Models;
using SNotes.ViewModels;
using Microsoft.AspNet.Identity;
using SNotes.Repositories;

namespace SNotes.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteRepository _repository;

        public NoteController(INoteRepository repository)
        {
            _repository = repository;
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

            var notes = _repository.GetNoteList();

            return View(notes);

            //var memberId = User.Identity.GetUserId();
            //if (memberId == null)
            //    return RedirectToAction("Login", "Account");

            //var userNotes = _context.Notes.Where(n => n.UserId == memberId)
            //    .Select(n => new NoteGridViewModel
            //    {
            //        Title = n.Title,
            //        Content = n.Content,
            //        Id = n.Id,
            //        CreationTime = n.CreationTime,
            //        ModificationTime = n.ModificationTime,
            //        Labels = n.Labels.ToList()

            //    })
            //    .OrderByDescending(o => o.CreationTime)
            //    .ToList();
            
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new AddNoteViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AddNoteViewModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.Save(model);
                return RedirectToAction("NoteList");
            }

            return View(model);

            //var memberId = User.Identity.GetUserId();
            //var note = new Note()
            //{

            //    UserId = memberId,
            //    Title = model.Title,
            //    Content = model.Content,
            //    CreationTime = DateTime.Now,
            //    ModificationTime = DateTime.Now

            //};

            //_context.Notes.Add(note);
            //_context.SaveChanges();

            //return RedirectToAction("NoteList", "Note");
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var model = _repository.Get(id);
            return View(model);
            //var note = _context.Notes.SingleOrDefault(n => n.Id == id);
            //if (note == null)

            //    return HttpNotFound();

            //var viewModel = new EditNoteViewModel
            //{
            //    Title = note.Title,
            //    Content = note.Content,
            //    Id = note.Id,

            //};
            //return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditNoteViewModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(model);
                return RedirectToAction("Notelist");
            }

            return View(model);

            //var note = _context.Notes.Single(x => x.Id == model.Id);
            //note.ModificationTime = DateTime.Now;
            //note.Title = model.Title;
            //note.Content = model.Content;
            //_context.SaveChanges();

            //return RedirectToAction("NoteList", "Note");
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            _repository.Delete(id);

            return RedirectToAction("NoteList");

            //var customer = _context.Notes.Single(x => x.Id == id);
            //_context.Notes.Remove(customer);
            //_context.SaveChanges();

            //return RedirectToAction("NoteList", "Note");
        }
     

        public ActionResult Search(string searchString)
        {
            var searchResult = _repository.Search(searchString);
            return View("NoteList", searchResult);

            //var searchResult = _context.Notes.Where(n => n.UserId == memberId && n.Content.Contains(searchString))
            //    .Select(n => new NoteGridViewModel
            //    {
            //        Title = n.Title,
            //        Content = n.Content,
            //        Id = n.Id,
            //        CreationTime = n.CreationTime,
            //        ModificationTime = n.ModificationTime

            //    })
            //    .OrderByDescending(n => n.CreationTime);

            //return View("NoteList", searchResult);

        }

        public ActionResult Sort(string sortOrder)
        {

            if (sortOrder == "CreationTime")
            {
                var sortResult = _repository.SortByCreationTime();

                return View("NoteList", sortResult);

            }
             
            if (sortOrder == "ModificationTime")
            {
                var sortResult = _repository.SortByModificationTime();

                return View("NoteList", sortResult);
            }

            return View("NoteList");
        }

        [HttpGet]
        public ActionResult AddLabelToNote(long id)
        {
            var model = new AddLabelToNoteViewModel
            {
                NoteId = id
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddLabelToNote(AddLabelToNoteViewModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.AddLabelToNote(model);
                return RedirectToAction("Notelist");
            }

            return View(model);
        }


    }
}
