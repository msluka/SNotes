using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNotes.Models;

namespace SNotes.ViewModels
{
    public class EditNoteViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public long Id { get; set; }
        public DateTime ModificationTime { get; set; }

    }
}