﻿using DCMS.Domain;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DCMS.Domain.Main
{

    /// <summary>
    /// 采购退货单
    /// </summary>
    public class PurchaseReturnBill : BaseBillEntity<int,PurchaseReturnItem>
    {
        public PurchaseReturnBill()
        {
            BillType = BillTypeEnum.PurchaseReturnBill;
        }

        private ICollection<PurchaseReturnBillAccounting> _purchaseReturnBillAccountings;

        /// <summary>
        /// 供应商Id
        /// </summary>
        public int ManufacturerId { get; set; }

        /// <summary>
        /// 业务员
        /// </summary>
        public int BusinessUserId { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        public int WareHouseId { get; set; }

        /// <summary>
        /// 交易日期
        /// </summary>
        public DateTime? TransactionDate { get; set; }

        /// <summary>
        /// 按最小单位采购
        /// </summary>
        [Column(TypeName = "BIT(1)")]
        public bool IsMinUnitPurchase { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        public decimal SumAmount { get; set; }

        /// <summary>
        /// 应收金额
        /// </summary>
        public decimal ReceivableAmount { get; set; }

        /// <summary>
        /// 优惠金额
        /// </summary>
        public decimal PreferentialAmount { get; set; }

        /// <summary>
        /// 欠款金额
        /// </summary>
        public decimal OweCash { get; set; }


        /// <summary>
        /// 打印数
        /// </summary>
        public int PrintNum { get; set; }

        /// <summary>
        /// 付款状态
        /// </summary>
        public int PayStatus { get; set; }
        public PayStatus PaymentStatus
        {
            get { return (PayStatus)PayStatus; }
            set { PayStatus = (int)value; }
        }


        /// <summary>
        /// 操作源
        /// </summary>
        public int? Operation { get; set; }
        public OperationEnum Operations
        {
            get { return (OperationEnum)Operation; }
            set { Operation = (int)value; }
        }

        ///// <summary>
        ///// (导航)商品类别
        ///// </summary>
        //public virtual ICollection<PurchaseReturnItem> PurchaseReturnItems
        //{
        //    get { return _purchaseReturnItems ?? (_purchaseReturnItems = new List<PurchaseReturnItem>()); }
        //    protected set { _purchaseReturnItems = value; }
        //}

        /// <summary>
        /// (导航)收款账户
        /// </summary>
        
        public virtual ICollection<PurchaseReturnBillAccounting> PurchaseReturnBillAccountings
        {
            get { return _purchaseReturnBillAccountings ?? (_purchaseReturnBillAccountings = new List<PurchaseReturnBillAccounting>()); }
            protected set { _purchaseReturnBillAccountings = value; }
        }

        ///// <summary>
        ///// 删除标志位
        ///// </summary>
        //[Column(TypeName = "BIT(1)")]
        //public bool Deleted { get; set; } = false;


        //发票号,产生的发票号(预留)
        public int InvoiceId { get; set; }

        //退款状态:0:未退款（关联的发票对账金额 = 0）,1:部分退款（关联的发票对账金额 < 发票金额 ）,2:全部退款 （关联的发票对账金额 == 发票金额）
        public int ReturnState { get; set; }

        /// <summary>
        /// 入库凭证（入库记账凭证Id）
        /// </summary>
        public int VoucherId { get; set; }

        /// <summary>
        /// 总税额
        /// </summary>
        public decimal TaxAmount { get; set; } = 0;
    }


    /// <summary>
    /// 采购单明细
    /// </summary>
    public class PurchaseReturnItem : AuditableEntity<int>
    {

        /// <summary>
        /// 税率%
        /// </summary>
        public decimal TaxRate { get; set; }


        /// <summary>
        /// 商品Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 成本价
        /// </summary>
        public decimal CostPrice { get; set; }

        /// <summary>
        /// 成本金额
        /// </summary>
        public decimal CostAmount { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public int StockQty { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 剩余还款数量
        /// </summary>
        public int RemainderQty { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 采购单Id
        /// </summary>
        public int PurchaseReturnBillId { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? ManufactureDete { get; set; }

        /// <summary>
        /// 是否口味商品
        /// </summary>
        [Column(TypeName = "BIT(1)")]
        public bool IsFlavorProduct { get; set; } = false;

        #region 导航

        public virtual PurchaseReturnBill PurchaseReturnBill { get; set; }

        #endregion


    }


    /// <summary>
    ///  收款账户（采购单科目映射表）
    /// </summary>
    public class PurchaseReturnBillAccounting : BaseAccountEntity<int>
    {

        private int PurchaseReturnBillId;
        /// <summary>
        /// 供应商
        /// </summary>
        public int ManufacturerId { get; set; }

        //(导航) 会计科目
        public virtual AccountingOption AccountingOption { get; set; }
        //(导航) 采购单
        public virtual PurchaseReturnBill PurchaseReturnBill { get; set; }
    }

    /// <summary>
    /// 项目保存或者编辑
    /// </summary>
    public class PurchaseReturnBillUpdate : AuditableEntity<int>
    {
        public string BillNumber { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public int ManufacturerId { get; set; } = 0;

        /// <summary>
        /// 业务员
        /// </summary>
        public int BusinessUserId { get; set; } = 0;

        /// <summary>
        /// 仓库
        /// </summary>
        public int WareHouseId { get; set; } = 0;

        /// <summary>
        /// 交易日期
        /// </summary>
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// 按最小单位采购
        /// </summary>
        public bool IsMinUnitPurchase { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 优惠金额
        /// </summary>
        public decimal PreferentialAmount { get; set; } = 0;
        /// <summary>
        /// 优惠后金额
        /// </summary>
        public decimal PreferentialEndAmount { get; set; } = 0;

        /// <summary>
        /// 欠款金额
        /// </summary>
        public decimal OweCash { get; set; } = 0;

        /// <summary>
        /// 操作源
        /// </summary>
        public int? Operation { get; set; }

        /// <summary>
        /// 项目
        /// </summary>
        public List<PurchaseReturnItem> Items { get; set; }

        /// <summary>
        /// 收款账户
        /// </summary>
        public List<PurchaseReturnBillAccounting> Accounting { get; set; }

    }


}
