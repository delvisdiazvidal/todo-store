using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(EntityTypeBuilder<ToDoItem> builder)
        {
            builder.ToTable("ToDoItem_Table");

            builder.Property(tdi => tdi.Status)
                    .HasConversion(
                        s => s.ToString(),
                        s => (ToDoItemStatus)Enum.Parse(typeof(ToDoItemStatus), s));

            builder.HasData
            (
                new ToDoItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Laundry",
                    Description = "Wash Shoes",
                    Status = ToDoItemStatus.PENDING,
                    ToDoListId = new Guid("660ed4cd-1361-4216-9faa-9636e4df681a")
                },
                new ToDoItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Cook",
                    Description = "Raviolis",
                    Status = ToDoItemStatus.PENDING,
                    ToDoListId = new Guid("660ed4cd-1361-4216-9faa-9636e4df681a")
                },
                new ToDoItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Vegetals",
                    Description = "Carrots, Tomatoes",
                    Status = ToDoItemStatus.PENDING,
                    ToDoListId = new Guid("410c14e3-e6df-35c8-8c6f-1e19aed675bc")
                },
                new ToDoItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Meat",
                    Description = "Beaf, Bacon",
                    Status = ToDoItemStatus.PENDING,
                    ToDoListId = new Guid("410c14e3-e6df-35c8-8c6f-1e19aed675bc")
                },
                new ToDoItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Beer",
                    Description = "Budweiser",
                    Status = ToDoItemStatus.PENDING,
                    ToDoListId = new Guid("410c14e3-e6df-35c8-8c6f-1e19aed675bc")
                }
            );
        }
    }
}