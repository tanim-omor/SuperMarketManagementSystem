//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Final_Project.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ShopManagementSystemEntitiesx : DbContext
    {
        public ShopManagementSystemEntitiesx()
            : base("name=ShopManagementSystemEntitiesx")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C_current_> C_current_ { get; set; }
        public virtual DbSet<cart> carts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<method> methods { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<tbl_admin> tbl_admin { get; set; }
        public virtual DbSet<tbl_category> tbl_category { get; set; }
        public virtual DbSet<tbl_product> tbl_product { get; set; }
        public virtual DbSet<tbl_user> tbl_user { get; set; }
        public virtual DbSet<adminPin> adminPins { get; set; }
        public virtual DbSet<auth> auths { get; set; }
    }
}
