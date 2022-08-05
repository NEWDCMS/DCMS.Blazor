﻿using DCMS.Domain.Census;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DCMS.Infrastructure.Mapping
{
    public partial class DisplayPhotoMap : IEntityTypeConfiguration<DisplayPhoto>
    {
        //public DisplayPhotoMap()
        //{
        //    ToTable("DisplayPhoto");
        //    HasKey(c => c.Id);
        //    //this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        //    HasRequired(o => o.Tradition)
        //       .WithMany(c => c.DisplayPhotos)
        //       .HasForeignKey(o => o.TraditionId);


        //    HasRequired(o => o.Restaurant)
        //        .WithMany(c => c.DisplayPhotos)
        //        .HasForeignKey(o => o.RestaurantId);


        //    //HasRequired(o => o.VisitStore)
        //    //    .WithMany(c => c.DisplayPhotos)
        //    //    .HasForeignKey(o => o.VisitStoreId);
        //}

        public void Configure(EntityTypeBuilder<DisplayPhoto> builder)
        {
            builder.ToTable("DisplayPhoto");
            builder.HasKey(b => b.Id);

            //builder.HasOne(o => o.Tradition)
            //   .WithMany(c => c.DisplayPhotos)
            //   .HasForeignKey(o => o.TraditionId).IsRequired();


            //builder.HasOne(o => o.Restaurant)
            //    .WithMany(c => c.DisplayPhotos)
            //    .HasForeignKey(o => o.RestaurantId).IsRequired();

           
        }

    }

}
