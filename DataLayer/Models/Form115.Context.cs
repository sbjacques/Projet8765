﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Form115Entities : DbContext
    {
        public Form115Entities()
            : base("name=Form115Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Continents> Continents { get; set; }
        public virtual DbSet<Hotels> Hotels { get; set; }
        public virtual DbSet<Pays> Pays { get; set; }
        public virtual DbSet<Produits> Produits { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }
        public virtual DbSet<Sejours> Sejours { get; set; }
        public virtual DbSet<Utilisateurs> Utilisateurs { get; set; }
        public virtual DbSet<Villes> Villes { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Promotions> Promotions { get; set; }
        public virtual DbSet<HotelTracking> HotelTracking { get; set; }
    }
}