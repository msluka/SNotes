using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNotes.Models;

namespace SNotes.ViewModels
{
    public class NoteGridViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
        public List<Label> Labels { get; set; }
        
    }
}