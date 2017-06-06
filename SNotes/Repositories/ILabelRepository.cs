using System.Collections.Generic;
using SNotes.Models;
using SNotes.ViewModels;

namespace SNotes.Repositories
{
    public interface ILabelRepository
    {
        IEnumerable<LabelGridViewModel> GetLabelList(string userId);
        void Save(AddLabelViewModel model);
        EditLabelViewModel Get(long id);
        void Update(EditLabelViewModel model);
        void Delete(long id);
        IEnumerable<Label> GetLabelListForNote();

    }
}