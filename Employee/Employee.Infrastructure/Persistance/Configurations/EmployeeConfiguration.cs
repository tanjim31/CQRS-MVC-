using Employee.Model;
using Employee.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Persistance.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employees>
{
    public void Configure(EntityTypeBuilder<Employees> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.FirstName);
        builder.HasData(new
        {
            Id = 1,
            FirstName = "Rahat",
            LastName = "Tanjim",
            Address = "Dhaka",
            Age = 25,
            PhoneNumber = "0198xxxxxx",
            Created = DateTimeOffset.Now,
            CreatedBy = "1",
            LastModified = DateTimeOffset.Now,
            Status = EntityStatus.Created

        });
        //, new
        //{
        //    Id = 2,
        //    FirstName = "Rayhan",
        //    LastName = "Rahman",
        //    Address = "Dhaka",
        //    Age = 25,
        //    PhoneNumber = "0197xxxxxx",
        //    Created = DateTimeOffset.Now,
        //    CreatedBy = "1",
        //    LastModified = DateTimeOffset.Now,
        //    Status = EntityStatus.Created

        //});
        
    }
}
