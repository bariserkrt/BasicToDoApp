using Microsoft.EntityFrameworkCore;
using ToDoApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Data.Context
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions options) : base(options)
        {
        }

        protected ToDoContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=appdb1;Username=postgres;Password=allame0912");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        DbSet<ToDo> ToDoSet { get; set; }


    }
}
