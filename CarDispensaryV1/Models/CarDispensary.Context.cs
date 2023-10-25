﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarDispensaryV1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarDispensaryEntities : DbContext
    {
        public CarDispensaryEntities()
            : base("name=CarDispensaryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<ExteriorImage> ExteriorImages { get; set; }
        public virtual DbSet<GarageDetail> GarageDetails { get; set; }
        public virtual DbSet<InteriorImage> InteriorImages { get; set; }
        public virtual DbSet<InventoryDetail> InventoryDetails { get; set; }
        public virtual DbSet<item> items { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<RateChart>   { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<Varient> Varients { get; set; }
    }
}