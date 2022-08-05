﻿using DCMS.Domain.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DCMS.Infrastructure.Mapping.Main
{

    /// <summary>
    /// 用于表示预付款单据
    /// </summary>
    public partial class AdvancePaymentBillMap : IEntityTypeConfiguration<AdvancePaymentBill>
    {
        public void Configure(EntityTypeBuilder<AdvancePaymentBill> builder)
        {
            builder.ToTable("AdvancePaymentBills");
            builder.HasKey(b => b.Id);
            builder.Ignore(c => c.Operations);
            builder.Ignore(c => c.BillType);
            builder.Ignore(c => c.BillTypeId);
            builder.Ignore(c => c.Deleted);

           
        }
    }


    /// <summary>
    ///  预付款账户（收款单据科目映射表）
    /// </summary>
    public partial class AdvancePaymentBillAccountingMap : IEntityTypeConfiguration<AdvancePaymentBillAccounting>
    {
        //public AdvancePaymentBillAccountingMap()
        //{
        //    ToTable("AdvancePaymentBill_Accounting_Mapping");

        //    HasRequired(o => o.AccountingOption)
        //         .WithMany()
        //         .HasForeignKey(o => o.AccountingOptionId);

        //    HasRequired(o => o.AdvancePaymentBill)
        //        .WithMany(m => m.AdvancePaymentBillAccountings)
        //        .HasForeignKey(o => o.AdvancePaymentBillId);
        //}

        public void Configure(EntityTypeBuilder<AdvancePaymentBillAccounting> builder)
        {
            builder.ToTable("AdvancePaymentBill_Accounting_Mapping")
               .Property(entity => entity.BillId);

            builder.HasKey(mapping => new { mapping.BillId, mapping.AccountingOptionId });

            builder.Property(mapping => mapping.BillId);
            builder.Property(mapping => mapping.AccountingOptionId);

            builder.HasOne(mapping => mapping.AccountingOption)
                .WithMany()
                .HasForeignKey(mapping => mapping.AccountingOptionId)
                .IsRequired();

            builder.HasOne(mapping => mapping.AdvancePaymentBill)
               .WithMany(customer => customer.Items)
                .HasForeignKey(mapping => mapping.BillId)
                .IsRequired();



           
        }

    }

}
