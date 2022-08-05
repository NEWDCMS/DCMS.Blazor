﻿using DCMS.Domain.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DCMS.Infrastructure.Mapping.Auth
{
	public partial class ActivityLogMap : IEntityTypeConfiguration<ActivityLog>
    {
        //public ActivityLogMap()
        //{
        //    ToTable("ActivityLog");
        //    HasKey(al => al.Id);
        //    Property(al => al.Comment).IsRequired();


        //    HasRequired(al => al.ActivityLogType)
        //        .WithMany()
        //        .HasForeignKey(al => al.ActivityLogTypeId);

        //    //this.HasRequired(al => al.User)
        //    //    .WithMany()
        //    //    .HasForeignKey(al => al.UserId);
        //}

        public void Configure(EntityTypeBuilder<ActivityLog> builder)
        {
            builder.ToTable("ActivityLog");
            builder.HasKey(b => b.Id);
            builder.Property(al => al.Comment).IsRequired();

            builder.HasOne(al => al.ActivityLogType)
                .WithMany()
                .HasForeignKey(al => al.ActivityLogTypeId);


           
        }
    }
}
