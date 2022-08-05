﻿using DCMS.Domain.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DCMS.Infrastructure.Mapping.Auth
{
	public partial class PermissionRecordMap : IEntityTypeConfiguration<PermissionRecord>
    {
        //public PermissionRecordMap()
        //{
        //    ToTable("PermissionRecord");
        //    HasKey(pr => pr.Id);
        //    Property(pr => pr.Name).IsRequired();
        //    Property(pr => pr.SystemName).IsRequired().HasMaxLength(255);

        //    //权限角色
        //    //HasMany(pr => pr.UserRoles)
        //    //    .WithMany(cr => cr.PermissionRecords)
        //    //    .Map(m => m.ToTable("PermissionRecord_Role_Mapping"));

        //    //1 这种写法也正确
        //    //this.HasMany(r => r.UserRoles)
        //    //    .WithMany(u => u.PermissionRecords);

        //    //模块和权限(一对多关系 写法1)
        //    HasRequired(c => c.Module)
        //        .WithMany(c => c.Permissions)
        //        .HasForeignKey(d => d.ModuleId); 

        //}

        public void Configure(EntityTypeBuilder<PermissionRecord> builder)
        {
            builder.ToTable("PermissionRecord");
            builder.HasKey(record => record.Id);

            builder.Property(record => record.Name).IsRequired();
            builder.Property(record => record.SystemName).HasMaxLength(255).IsRequired();

           
        }

    }


    public partial class PermissionRecordRolesMap : IEntityTypeConfiguration<PermissionRecordRoles>
    {
        //public PermissionRecordRolesMap()
        //{
        //    ToTable("PermissionRecord_Role_Mapping");

        //    HasRequired(o => o.PermissionRecord)
        //        .WithMany(m => m.PermissionRecordRoles)
        //        .HasForeignKey(o => o.PermissionRecord_Id);

        //    HasRequired(o => o.UserRole)
        //        .WithMany(m => m.PermissionRecordRoles)
        //        .HasForeignKey(o => o.UserRole_Id);
        //}

        public void Configure(EntityTypeBuilder<PermissionRecordRoles> builder)
        {
            builder.ToTable("PermissionRecordRoles");
            builder.HasKey(mapping => new { mapping.PermissionRecord_Id, mapping.UserRole_Id, mapping.Platform });

            builder.Property(mapping => mapping.PermissionRecord_Id);
            builder.Property(mapping => mapping.UserRole_Id);
            builder.Property(mapping => mapping.Platform);

            builder.HasOne(mapping => mapping.UserRole)
                .WithMany(role => role.PermissionRecordRoles)
                .HasForeignKey(mapping => mapping.UserRole_Id)
                .IsRequired();

            builder.HasOne(mapping => mapping.PermissionRecord)
                .WithMany(record => record.PermissionRecordRoles)
                .HasForeignKey(mapping => mapping.PermissionRecord_Id)
                .IsRequired();



           
        }

    }

    public partial class DataChannelPermissionMap : IEntityTypeConfiguration<DataChannelPermission>
    {

        public void Configure(EntityTypeBuilder<DataChannelPermission> builder)
        {
            builder.ToTable("DataChannelPermissions");
            builder.HasKey(b => b.Id);
            builder.Ignore(c => c.AllowViewReport);
           
        }
    }


}