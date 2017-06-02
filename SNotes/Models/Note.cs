using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNotes.Models
{
    public class Note
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
        public virtual IList<Label> Labels { get; set; }

    }
    
}