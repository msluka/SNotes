using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNotes.ViewModels;

namespace SNotes.Repositories
{
    public interface INoteRepository
    {
        IEnumerable<NoteGridViewModel> GetNoteList();
        void Save(AddNoteViewModel model);
        EditNoteViewModel Get(long id);
        void Update(EditNoteViewModel model);
        void Delete(long id);
        IEnumerable<NoteGridViewModel> Search(string searchString);
        IEnumerable<NoteGridViewModel> SortByCreationTime(); 
        IEnumerable<NoteGridViewModel> SortByModificationTime();
        void AddLabelToNote(AddLabelToNoteViewModel model);

    }
}