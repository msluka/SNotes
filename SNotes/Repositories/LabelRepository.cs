using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.VisualBasic.ApplicationServices;
using SNotes.DAL;
using SNotes.Models;
using SNotes.ViewModels;

namespace SNotes.Repositories
{
    public class LabelRepository : ILabelRepository
    {
        private readonly SNotesContext _dbContext;

        public LabelRepository(SNotesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<LabelGridViewModel> GetLabelList()
        {
            var memberId = HttpContext.Current.User.Identity.GetUserId();

            var labels = _dbContext.Labels.Where(x => x.UserId == memberId).ToList();

            return _dbContext.Labels.Where(n => n.UserId == memberId)
                .Select(n => new LabelGridViewModel()
                {
                    Name = n.Name,
                   
                }).ToList();

        }

        public void Save(AddLabelViewModel model)
        {
            var memberId = HttpContext.Current.User.Identity.GetUserId();

            var label = new Label()
            {
                Name = model.Name,
                UserId = memberId
                
            };

            _dbContext.Labels.Add(label);
            _dbContext.SaveChanges();
        }

        public EditLabelViewModel Get(long id)
        {

            return _dbContext.Labels.Where(x => x.Id == id)
                .Select(x => new EditLabelViewModel
                {
                    Name = x.Name

                }).Single();
        }

        public void Update(EditLabelViewModel model)
        {
            var label = _dbContext.Labels.Single(x => x.Id == model.Id);

            label.Name = model.Name;
          
            _dbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            var label = _dbContext.Labels.Where(x => x.Id == id).Single();
            _dbContext.Labels.Remove(label);
            _dbContext.SaveChanges();

        }

        public IEnumerable<Label> GetLabelListForNote()
        {
            var memberId = HttpContext.Current.User.Identity.GetUserId();

            var labels = _dbContext.Notes.Where(x => x.UserId == memberId).SelectMany(x => x.Labels);

            return labels;
            
        }
    }
}