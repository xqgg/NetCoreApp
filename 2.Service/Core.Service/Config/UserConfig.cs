using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("T_Users");
            builder.HasIndex(u => u.Email).IsUnique();
            builder.HasIndex(u => u.Name).IsUnique();
            builder.HasIndex(u => u.PhoneNumber).IsUnique();
            builder.Property(u => u.Roles).HasMaxLength(128);

        }
    }
}
