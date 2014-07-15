namespace MVCLab.Infrastructure.Data.CRM
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using MVCLab.Domain.CRM;
    using MVCLab.Infrastructure.Data.CRM.Mapping;

    public partial class MVCLabContext : DbContext
    {
        public MVCLabContext()
            : base("name=MVCLabContext")
        {
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new CustomerMapper());   
        }
    }
}
