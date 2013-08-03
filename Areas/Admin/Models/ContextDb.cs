using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace inln_bootstrap.Areas.Admin.Models
{
    public class ContextDb : DbContext
    {
        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<InfoBlockModel> InfoBlocks { get; set; }
    }
}