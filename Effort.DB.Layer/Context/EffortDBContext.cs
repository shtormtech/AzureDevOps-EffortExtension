﻿using Effort.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Effort.DB.Layer.Context
{
    public class EffortDbContext : DbContext
    {
        protected const String DefaultShema = "effort";
        public DbSet<ActivityType> ActivityType { get; set; }
        public DbSet<Timesheet> Timesheet { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(DefaultShema);
            modelBuilder.Entity<Timesheet>().Property<DateTime>("LastUpdated");
            modelBuilder.Entity<Timesheet>().Property<DateTime>("Inserted");
            modelBuilder.Entity<ActivityType>().HasData(
                new ActivityType { Id = 1, Name = "Анализ", Code = "analyze", Comment = "Анализ задачи" },
                new ActivityType { Id = 2, Name = "Разработка", Code = "develop", Comment = "Разработка" },
                new ActivityType { Id = 3, Name = "Тестирование", Code = "test", Comment = "Тестирование" }
                );
            //===============================================================================================
            modelBuilder.Entity<Timesheet>().HasData(
                new Timesheet { Id = 1, ActivityTypeId = 1, WorkItemId = 1, UserId = "iloer", Date = DateTime.Now, Duration = 15, Comment = "текст" },
                new Timesheet { Id = 2, ActivityTypeId = 1, WorkItemId = 1, UserId = "iloer", Date = DateTime.Now, Duration = 15, Comment = "текст" },
                new Timesheet { Id = 3, ActivityTypeId = 1, WorkItemId = 1, UserId = "iloer", Date = DateTime.Now, Duration = 15, Comment = "текст" },
                new Timesheet { Id = 4, ActivityTypeId = 2, WorkItemId = 1, UserId = "iloer", Date = DateTime.Now, Duration = 15, Comment = "текст" },
                new Timesheet { Id = 5, ActivityTypeId = 2, WorkItemId = 1, UserId = "iloer", Date = DateTime.Now, Duration = 15, Comment = "текст" },
                new Timesheet { Id = 6, ActivityTypeId = 2, WorkItemId = 1, UserId = "iloer", Date = DateTime.Now, Duration = 15, Comment = "текст" },
                new Timesheet { Id = 7, ActivityTypeId = 2, WorkItemId = 1, UserId = "iloer", Date = DateTime.Now, Duration = 15, Comment = "текст" },
                new Timesheet { Id = 8, ActivityTypeId = 3, WorkItemId = 1, UserId = "iloer", Date = DateTime.Now, Duration = 15, Comment = "текст" },
                new Timesheet { Id = 9, ActivityTypeId = 3, WorkItemId = 1, UserId = "iloer", Date = DateTime.Now, Duration = 15, Comment = "текст" },
                new Timesheet { Id = 10, ActivityTypeId = 3, WorkItemId = 1, UserId = "iloer", Date = DateTime.Now, Duration = 15, Comment = "текст" },
                new Timesheet { Id = 11, ActivityTypeId = 3, WorkItemId = 1, UserId = "iloer", Date = DateTime.Now, Duration = 15, Comment = "текст" },
                new Timesheet { Id = 12, ActivityTypeId = 3, WorkItemId = 1, UserId = "iloer", Date = DateTime.Now, Duration = 15, Comment = "текст" })
                ;

        }
        public EffortDbContext()
            : base()
        { }

        public EffortDbContext(DbContextOptions<EffortDbContext> options)
            : base(options)
        {
        }
    }
}
