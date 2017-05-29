using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNotes.Models;

namespace SNotes.ViewModels
{
    public class EditNoteViewModel
    {
        public string Content { get; set; }
        public Note Notes { get; set; }
    }
}