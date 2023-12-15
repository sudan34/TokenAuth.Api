using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TokenAuth.Api.Models;

namespace TokenAuth.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext () : base ("DefaultConnection")
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}