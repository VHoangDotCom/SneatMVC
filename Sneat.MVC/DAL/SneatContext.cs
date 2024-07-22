﻿using Sneat.MVC.Models.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace Sneat.MVC.DAL
{
    public class SneatContext : DbContext
    {
        public SneatContext() : base("SneatContext")
        {

        }

        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}