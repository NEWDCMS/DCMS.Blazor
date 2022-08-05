﻿using DCMS.Domain.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DCMS.Infrastructure.Mapping.Main
{

    /// <summary>
    /// 用于表示付款单据
    /// </summary>
    public partial class PaymentReceiptBillMap : IEntityTypeConfiguration<PaymentReceiptBill>
    {
        public void Configure(EntityTypeBuilder<PaymentReceiptBill> builder)
        {
            builder.ToTable("PaymentReceiptBills");
            builder.HasKey(b => b.Id);
            builder.Ignore(c => c.Operations);
            builder.Ignore(c => c.BillType);
            builder.Ignore(c => c.BillTypeId);
            builder.Ignore(c => c.Deleted);

           
        }
    }


    /// <summary>
    ///付款单据项目
    /// </summary>
    public partial class PaymentReceiptItemMap : IEntityTypeConfiguration<PaymentReceiptItem>
    {

        //public PaymentReceiptItemMap()
        //{
        //    ToTable("Items");
        //    HasKey(o => o.Id);

        //    Ignore(c => c.BillTypeEnum);

        //    HasRequired(sao => sao.PaymentReceiptBill)
        //    .WithMany(sa => sa.Items)
        //    .HasForeignKey(sao => sao.PaymentReceiptBillId);
        //}

        public void Configure(EntityTypeBuilder<PaymentReceiptItem> builder)
        {
            builder.ToTable("PaymentReceiptItems");
            builder.HasKey(b => b.Id);

            builder.Ignore(c => c.BillTypeEnum);

            builder.HasOne(sao => sao.PaymentReceiptBill)
            .WithMany(sa => sa.Items)
            .HasForeignKey(sao => sao.PaymentReceiptBillId).IsRequired();

           
        }
    }


    /// <summary>
    ///  付款账户（付款单据科目映射表）
    /// </summary>
    public partial class PaymentReceiptBillAccountingMap : IEntityTypeConfiguration<PaymentReceiptBillAccounting>
    {
        //public PaymentReceiptBillAccountingMap()
        //{
        //    ToTable("PaymentReceiptBill_Accounting_Mapping");

        //    HasRequired(o => o.AccountingOption)
        //         .WithMany()
        //         .HasForeignKey(o => o.AccountingOptionId);

        //    HasRequired(o => o.PaymentReceiptBill)
        //        .WithMany(m => m.PaymentReceiptBillAccountings)
        //        .HasForeignKey(o => o.PaymentReceiptBillId);

        //}

        public void Configure(EntityTypeBuilder<PaymentReceiptBillAccounting> builder)
        {
            builder.ToTable("PaymentReceiptBill_Accounting_Mapping")
               .Property(entity => entity.BillId);
 

            builder.HasKey(mapping => new { mapping.BillId, mapping.AccountingOptionId });

            builder.Property(mapping => mapping.BillId);
            builder.Property(mapping => mapping.AccountingOptionId);

            builder.HasOne(mapping => mapping.AccountingOption)
                .WithMany()
                .HasForeignKey(mapping => mapping.AccountingOptionId)
                .IsRequired();

            builder.HasOne(mapping => mapping.PaymentReceiptBill)
               .WithMany(customer => customer.PaymentReceiptBillAccountings)
                .HasForeignKey(mapping => mapping.BillId)
                .IsRequired();



           
        }
    }

}
