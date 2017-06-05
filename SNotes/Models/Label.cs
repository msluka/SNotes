using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNotes.Models
{
    public class Label
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public virtual IList<Note> Notes { get; set; }
    }
}