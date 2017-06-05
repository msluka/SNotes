using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNotes.Models;

namespace SNotes.ViewModels
{
    public class AddNoteViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public string UserId { get; set; }
        

    }
}