﻿using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Service.Context
{
    public class NCDbContext : DbContext
    {
        public NCDbContext(DbContextOptions<NCDbContext> options)
         : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Role> Roles { get; set; }


        public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }







    }
}
