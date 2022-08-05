﻿using DCMS.Domain.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DCMS.Infrastructure.Mapping.Auth
{

	public partial class UserMapV3 : IEntityTypeConfiguration<User>
	{

		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("Users");
			builder.HasKey(b => b.Id);
			builder.HasIndex(b => b.StoreId);

			//Table 9.3 Maximum Length of strings used with EF Core
			//=======================================================
			//Data Type                 Maximum Length	    .NET Type
			//=======================================================
			//CHAR                      255                 string
			//BINARY                    255                 byte[]
			//VARCHAR,VARBINARY         65,535              string, byte[]
			//TINYBLOB, TINYTEXT        255                 byte[]
			//BLOB, TEXT                65,535              byte[]
			//MEDIUMBLOB, MEDIUMTEXT    16,777,215          byte[]
			//LONGBLOB, LONGTEXT        4,294,967,295       byte[]
			//ENUM                      65,535              string
			//SET                       65,535              string
			//========================================================
			builder.Ignore(user => user.UserRoles);
			builder.Ignore(user => user.PasswordFormat);
			builder.Ignore(user => user.RefreshTokens);
		   
		}
	}


	/// <summary>
	/// Mapping
	/// </summary>
	public partial class UserUserRoleMap : IEntityTypeConfiguration<UserUserRole>
	{
		public void Configure(EntityTypeBuilder<UserUserRole> builder)
		{
			builder.ToTable("UserUserRole");
			builder.HasKey(mapping => new { mapping.UserId, mapping.UserRoleId });
			builder.Ignore(mapping => mapping.Id);

			builder.Property(mapping => mapping.UserId);
			builder.Property(mapping => mapping.UserRoleId);

			builder.HasOne(mapping => mapping.User)
				.WithMany(customer => customer.UserUserRoles)
				.HasForeignKey(mapping => mapping.UserId)
				.IsRequired();

			builder.HasOne(mapping => mapping.UserRole)
				.WithMany()
				.HasForeignKey(mapping => mapping.UserRoleId)
				.IsRequired();
		}
	}


	public partial class RefreshTokenMap : IEntityTypeConfiguration<RefreshToken>
	{
		public void Configure(EntityTypeBuilder<RefreshToken> builder)
		{
			builder.ToTable("RefreshToken");
			builder.HasKey(b => b.Id);
		}
	}


	public partial class UserDistrictsMap : IEntityTypeConfiguration<UserDistricts>
	{
		public void Configure(EntityTypeBuilder<UserDistricts> builder)
		{
			builder.ToTable("UserDistricts");
			builder.HasKey(b => b.Id);
		   
		}
	}


	public partial class UserPasswordMap : IEntityTypeConfiguration<UserPassword>
	{
		#region Methods

		public void Configure(EntityTypeBuilder<UserPassword> builder)
		{
			builder.ToTable(nameof(UserPassword));
			builder.HasKey(password => password.Id);

			builder.HasOne(password => password.User)
				.WithMany()
				.HasForeignKey(password => password.UserId)
				.IsRequired();

			builder.Ignore(password => password.PasswordFormat);

		   
		}

		#endregion
	}


	public partial class UserAttributeMap : IEntityTypeConfiguration<UserAttribute>
	{
		#region Methods

		public void Configure(EntityTypeBuilder<UserAttribute> builder)
		{
			builder.ToTable(nameof(UserAttribute));
			builder.HasKey(attribute => attribute.Id);

			builder.Property(attribute => attribute.Name).HasMaxLength(400).IsRequired();
		}

		#endregion
	}


	public partial class UserAttributeValueMap : IEntityTypeConfiguration<UserAttributeValue>
	{
		#region Methods

		public void Configure(EntityTypeBuilder<UserAttributeValue> builder)
		{
			builder.ToTable(nameof(UserAttributeValue));
			builder.HasKey(value => value.Id);

			builder.Property(value => value.Name).HasMaxLength(400).IsRequired();

			builder.HasOne(value => value.UserAttribute)
				.WithMany(attribute => attribute.UserAttributeValues)
				.HasForeignKey(value => value.UserAttributeId)
				.IsRequired();
		}

		#endregion
	}


	public partial class PrivateMessageMap : IEntityTypeConfiguration<PrivateMessage>
	{

		public void Configure(EntityTypeBuilder<PrivateMessage> builder)
		{
			builder.ToTable(nameof(PrivateMessage));
			builder.HasKey(message => message.Id);

			builder.Property(message => message.Subject).HasMaxLength(200).IsRequired();
			builder.Property(message => message.Text).HasMaxLength(500).IsRequired();

			//builder.HasOne(message => message.FromUser)
			//   .WithMany()
			//   .HasForeignKey(message => message.FromUserId)
			//   .IsRequired()
			//   .OnDelete(DeleteBehavior.Restrict);

			//builder.HasOne(message => message.ToUser)
			//   .WithMany()
			//   .HasForeignKey(message => message.ToUserId)
			//   .IsRequired()
			//   .OnDelete(DeleteBehavior.Restrict);


		}
	}
}