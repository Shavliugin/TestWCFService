using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestWCFService
{
    public class TestDBContext : DbContext
    {
        public TestDBContext() : base("DBConnection") { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}