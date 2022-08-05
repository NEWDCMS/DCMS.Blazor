﻿using DCMS.Domain.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DCMS.Infrastructure.Mapping.Main
{

    /// <summary>
    /// 用于表示财务收入单据
    /// </summary>
    public partial class FinancialIncomeBillMap : IEntityTypeConfiguration<FinancialIncomeBill>
    {
        public void Configure(EntityTypeBuilder<FinancialIncomeBill> builder)
        {
            builder.ToTable("FinancialIncomeBills");
            builder.HasKey(b => b.Id);
            builder.Ignore(c => c.Operations);
            builder.Ignore(c => c.BillType);
            builder.Ignore(c => c.BillTypeId);

            builder.Ignore(c => c.PaymentStatus);
            builder.Ignore(c => c.ReceivedStatus);
            builder.Ignore(c => c.Deleted);

           
        }
    }


    /// <summary>
    /// 财务收入单据项目
    /// </summary>
    public partial class FinancialIncomeItemMap : IEntityTypeConfiguration<FinancialIncomeItem>
    {

        //public FinancialIncomeItemMap()
        //{
        //    ToTable("Items");
        //    HasKey(o => o.Id);

        //    HasRequired(sao => sao.FinancialIncomeBill)
        //    .WithMany(sa => sa.Items)
        //    .HasForeignKey(sao => sao.FinancialIncomeBillId);
        //}

        public void Configure(EntityTypeBuilder<FinancialIncomeItem> builder)
        {
            //builder.ToTable(nameof(FinancialIncomeItem));
            builder.ToTable("FinancialIncomeItems");
            builder.HasKey(b => b.Id);

            builder.HasOne(sao => sao.FinancialIncomeBill)
            .WithMany(sa => sa.Items)
            .HasForeignKey(sao => sao.FinancialIncomeBillId).IsRequired();

           
        }
    }


    /// <summary>
    ///  财务收入单付款账户（付款单据科目映射表）
    /// </summary>
    public partial class FinancialIncomeBillAccountingMap : IEntityTypeConfiguration<FinancialIncomeBillAccounting>
    {
        //public FinancialIncomeBillAccountingMap()
        //{
        //    ToTable("FinancialIncomeBill_Accounting_Mapping");

        //    HasRequired(o => o.AccountingOption)
        //         .WithMany()
        //         .HasForeignKey(o => o.AccountingOptionId);

        //    HasRequired(o => o.FinancialIncomeBill)
        //        .WithMany(m => m.FinancialIncomeBillAccountings)
        //        .HasForeignKey(o => o.FinancialIncomeBillId);

        //}

        public void Configure(EntityTypeBuilder<FinancialIncomeBillAccounting> builder)
        {
            builder.ToTable("FinancialIncomeBill_Accounting_Mapping")
               .Property(entity => entity.BillId);
  

            builder.HasKey(mapping => new { mapping.BillId, mapping.AccountingOptionId });

            builder.Property(mapping => mapping.BillId);
            builder.Property(mapping => mapping.AccountingOptionId);

            builder.HasOne(mapping => mapping.AccountingOption)
                .WithMany()
                .HasForeignKey(mapping => mapping.AccountingOptionId)
                .IsRequired();

            builder.HasOne(mapping => mapping.FinancialIncomeBill)
               .WithMany(customer => customer.FinancialIncomeBillAccountings)
                .HasForeignKey(mapping => mapping.BillId)
                .IsRequired();



           
        }
    }

}
