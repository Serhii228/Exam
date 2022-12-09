using API.DbOperations.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace API.DbOperations
{
    public class EntityFrameworkCoreDbContext : DbContext
    {
        private readonly string _connectionString =
     "Server=DESKTOP-PF17DPL\\SQLEXPRESS01;Database=examdb;Trusted_Connection=True;";
        public EntityFrameworkCoreDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DbSet<ProjectTaskEntity> Tasks { get; set; }
        public EntityFrameworkCoreDbContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProjectTaskEntity>().HasData(new List<ProjectTaskEntity>
            {
                new ProjectTaskEntity
                {
                    Id = 1,
                    Text = "Add feature1.",
                    Status = Enums.TaskStatus.New,
                    Time = DateTime.Now,
                    Priority = Enums.TaskPriority.Low
                },
                 new ProjectTaskEntity
                {
                    Id=2,
                    Text = "Add feature2.",
                    Status = Enums.TaskStatus.InProccess,
                    Time = DateTime.Now,
                    Priority = Enums.TaskPriority.Middle
                },
                  new ProjectTaskEntity
                {
                    Id = 3,
                    Text = "Add task1.",
                    Status = Enums.TaskStatus.InTest,
                    Time = DateTime.Now,
                    Priority = Enums.TaskPriority.High
                },
                   new ProjectTaskEntity
                {
                    Id = 4,
                    Text = "Add task2.",
                    Status = Enums.TaskStatus.Closed,
                    Time = DateTime.Now,
                    Priority = Enums.TaskPriority.Low
                },
                   new ProjectTaskEntity
                {
                    Id = 5,
                    Text = "Fix bug1.",
                    Status = Enums.TaskStatus.New,
                    Time = DateTime.Now,
                    Priority = Enums.TaskPriority.High
                },
                   new ProjectTaskEntity
                {
                    Id = 6,
                    Text = "Fix or add bug2.",
                    Status = Enums.TaskStatus.Closed,
                    Time = DateTime.Now,
                    Priority = Enums.TaskPriority.Low
                },
            });

        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_connectionString);
            base.OnConfiguring(builder);
        }
    }
}
