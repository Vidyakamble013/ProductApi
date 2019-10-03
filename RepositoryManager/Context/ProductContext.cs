using CommonLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryManager.Context
{
   public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
        }

     public DbSet<BulkUpdate> Product { get; set; }
    }
}
