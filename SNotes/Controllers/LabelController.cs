using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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
            var labels = _repository.GetLabelList(User.Identity.GetUserId());

            return View("_labelListPartial", labels);
            
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
            
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var model = _repository.Get(id);
            return View(model);
  
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
            
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            _repository.Delete(id);

            return RedirectToAction("NoteList", "Note");
           
        }

    }
}