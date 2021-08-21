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
    class ToDoListConfiguration : IEntityTypeConfiguration<ToDoList>
    {
        public void Configure(EntityTypeBuilder<ToDoList> builder)
        {
            builder.ToTable("ToDoList_Table");

            builder.HasData
            (
                new ToDoList
                {
                    Id = new Guid("410c14e3-e6df-35c8-8c6f-1e19aed675bc"),
                    Name = "Shopping",
                    CreateDate = DateTimeOffset.UtcNow,
                },
                new ToDoList
                {
                    Id = new Guid("660ed4cd-1361-4216-9faa-9636e4df681a"),
                    Name = "Home",
                    CreateDate = DateTimeOffset.UtcNow,
                }
            ); 

            builder.HasMany(tdi => tdi.ToDoItems)
                .WithOne(tdl => tdl.ToDoList)
                .HasForeignKey(tdl => tdl.ToDoListId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}