using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using SNotes.DAL;
using SNotes.Models;
using SNotes.ViewModels;

namespace SNotes.Repositories
{
    public class NoteRepository : INoteRepository

    {
        private readonly SNotesContext _dbContext;

        public NoteRepository(SNotesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<NoteGridViewModel> GetNoteList()
        {

            var memberId = HttpContext.Current.User.Identity.GetUserId();


            return _dbContext.Notes.Where(n => n.UserId == memberId)
                .Select(n => new NoteGridViewModel
                {
                    Title = n.Title,
                    Content = n.Content,
                    Id = n.Id,
                    CreationTime = n.CreationTime,
                    ModificationTime = n.ModificationTime,
                    Labels = n.Labels.ToList()

                })
                .OrderByDescending(o => o.CreationTime)
                .ToList();


        }

        public void Save(AddNoteViewModel model)
        {

            var memberId = HttpContext.Current.User.Identity.GetUserId();

            var note = new Note()
            {

                UserId = memberId,
                Title = model.Title,
                Content = model.Content,
                CreationTime = DateTime.Now,
                ModificationTime = DateTime.Now

            };

            _dbContext.Notes.Add(note);
            _dbContext.SaveChanges();
        }

        public EditNoteViewModel Get(long id)
        {
            return _dbContext.Notes.Where(x => x.Id == id)
                .Select(x => new EditNoteViewModel
                {
                    Id = id,
                    Title = x.Title,
                    Content = x.Content
                    
                }).Single();
        }

        public void Update(EditNoteViewModel model)
        {
            var note = _dbContext.Notes.Single(x => x.Id == model.Id);

            note.Title = model.Title;
            note.Content = model.Content;
            note.ModificationTime = DateTime.Now;
            
            _dbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            var note = _dbContext.Notes.Where(x => x.Id == id).Single();
            _dbContext.Notes.Remove(note);
            _dbContext.SaveChanges();

        }

        public IEnumerable<NoteGridViewModel> Search(string searchString)
        {
            
            var memberId = HttpContext.Current.User.Identity.GetUserId();

            return _dbContext.Notes.Where(n => n.UserId == memberId && n.Content.Contains(searchString))
                .Select(n => new NoteGridViewModel
                {
                    Title = n.Title,
                    Content = n.Content,
                    Id = n.Id,
                    CreationTime = n.CreationTime,
                    ModificationTime = n.ModificationTime

                }).OrderByDescending(n => n.CreationTime);
        }

        public IEnumerable<NoteGridViewModel> SortByCreationTime ()
        {
            var memberId = HttpContext.Current.User.Identity.GetUserId();

            var sortResult = _dbContext.Notes.Where(n => n.UserId == memberId)
                    .Select(n => new NoteGridViewModel
                    {
                        Id = n.Id,
                        Title = n.Title,
                        Content = n.Content,
                        CreationTime = n.CreationTime,
                        ModificationTime = n.ModificationTime

                    }).OrderByDescending(n => n.CreationTime);

            return sortResult;

        }

        public IEnumerable<NoteGridViewModel> SortByModificationTime()
        {
            var memberId = HttpContext.Current.User.Identity.GetUserId();
            
                var sortResult = _dbContext.Notes.Where(n => n.UserId == memberId)
                    .Select(n => new NoteGridViewModel
                    {
                        Title = n.Title,
                        Content = n.Content,
                        Id = n.Id,
                        CreationTime = n.CreationTime,
                        ModificationTime = n.ModificationTime

                    }).OrderByDescending(n => n.ModificationTime);

            return sortResult;
        }

        
        public void AddLabelToNote(AddLabelToNoteViewModel model)
        {
            var memberId = HttpContext.Current.User.Identity.GetUserId();

            var note = _dbContext.Notes.Single(x => x.Id == model.NoteId);
            
            var label = new Label
            {
                Name = model.LabelName,
                UserId = memberId

            };
            
            _dbContext.Labels.Add(label);
           
            note.Labels.Add(label);

            _dbContext.SaveChanges();

        }

    }
}