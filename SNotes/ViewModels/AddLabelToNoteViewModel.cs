using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNotes.ViewModels
{
    public class AddLabelToNoteViewModel
    {
        public string LabelName { get; set; }
        public long NoteId { get; set; }
    }
}