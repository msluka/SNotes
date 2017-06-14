
using System.Web.Mvc;
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
            
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var model = _repository.Get(id);
            return View(model);

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

        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            _repository.Delete(id);

            return RedirectToAction("NoteList");

        }
     

        public ActionResult Search(string searchString)
        {
            var searchResult = _repository.Search(searchString);
            return View("NoteList", searchResult);

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

        public ActionResult SortByLabelGroup(long id)
        {
            var labels = _repository.SortByLabelGroup(id);

            return View("NoteList", labels);
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
