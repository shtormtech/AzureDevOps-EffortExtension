using Effort.Models;
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
            // TODO: Убрать дефллтное значение
            modelBuilder.Entity<Timesheet>().Property<DateTime>("LastUpdated").HasDefaultValue(DateTime.Now);
            // TODO: Убрать дефллтное значение
            modelBuilder.Entity<Timesheet>().Property<DateTime>("Inserted").HasDefaultValue(DateTime.Now);
            
            modelBuilder.Entity<ActivityType>().HasData(
                new ActivityType { Id = 1, Name = "Анализ", Code = "analyze", Comment = "Анализ задачи", Color = "red"},
                new ActivityType { Id = 2, Name = "Разработка", Code = "develop", Comment = "Разработка", Color = "green" },
                new ActivityType { Id = 3, Name = "Тестирование", Code = "test", Comment = "Тестирование", Color = "blue" }
                );
            //TODO: Удалить после тестирования
            modelBuilder.Entity<Timesheet>().HasData(
                new Timesheet { Id = -1, ActivityTypeId = 1, WorkItemId = 11, UserUniqueName = "ivan.varnavskiy@shtormtech.ru", Date = DateTime.Now, Duration = 15, Comment = "текст", IsDeleted = true },
                new Timesheet { Id = -2, ActivityTypeId = 1, WorkItemId = 6, UserUniqueName = "ivan.varnavskiy@shtormtech.ru", Date = DateTime.Now, Duration = 15, Comment = "текст" },
                new Timesheet { Id = -3, ActivityTypeId = 1, WorkItemId = 10, UserUniqueName = "ivan.varnavskiy@shtormtech.ru", Date = DateTime.Now, Duration = 15, Comment = "текст" },
                new Timesheet { Id = -4, ActivityTypeId = 2, WorkItemId = 44, UserUniqueName = "ivan.varnavskiy@shtormtech.ru", Date = DateTime.Now, Duration = 15, Comment = "текст", IsDeleted = true },
                new Timesheet { Id = -5, ActivityTypeId = 2, WorkItemId = 55, UserUniqueName = "ivan.varnavskiy@shtormtech.ru", Date = DateTime.Now, Duration = 15, Comment = "текст" },
                new Timesheet { Id = -6, ActivityTypeId = 2, WorkItemId = 66, UserUniqueName = "ivan.varnavskiy@shtormtech.ru", Date = DateTime.Now, Duration = 15, Comment = "текст" },
                new Timesheet { Id = -7, ActivityTypeId = 2, WorkItemId = 11, UserUniqueName = "ivan.varnavskiy@shtormtech.ru", Date = DateTime.Now, Duration = 15, Comment = "текст" },
                new Timesheet { Id = -8, ActivityTypeId = 3, WorkItemId = 88, UserUniqueName = "ivan.varnavskiy@shtormtech.ru", Date = DateTime.Now, Duration = 15, Comment = "текст", IsDeleted = true },
                new Timesheet { Id = -9, ActivityTypeId = 3, WorkItemId = 99, UserUniqueName = "ivan.varnavskiy@shtormtech.ru", Date = DateTime.Now, Duration = 15, Comment = "текст" },
                new Timesheet { Id = -10, ActivityTypeId = 3, WorkItemId = 100, UserUniqueName = "ivan.varnavskiy@shtormtech.ru", Date = DateTime.Now, Duration = 15, Comment = "текст" },
                new Timesheet { Id = -11, ActivityTypeId = 3, WorkItemId = 110, UserUniqueName = "ivan.varnavskiy@shtormtech.ru", Date = DateTime.Now, Duration = 15, Comment = "текст" },
                new Timesheet { Id = -12, ActivityTypeId = 3, WorkItemId = 120, UserUniqueName = "ivan.varnavskiy@shtormtech.ru", Date = DateTime.Now, Duration = 15, Comment = "текст" })
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
