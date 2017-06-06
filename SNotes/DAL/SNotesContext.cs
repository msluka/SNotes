using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using SNotes.Models;

namespace SNotes.DAL
{
    public class SNotesContext : DbContext
    {
        public SNotesContext() : base("DefaultConnection")
        {
            
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Label> Labels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}