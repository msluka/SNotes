using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNotes.Models;

namespace SNotes.ViewModels
{
    public class LabelGridViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public virtual List<Note> Notes { get; set; }
    }
}