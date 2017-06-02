using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace SNotes.Models
{
    public class NoteLabels
    {
        public long NoteId { get; set; }
        public long LabelId { get; set; }
    }
}