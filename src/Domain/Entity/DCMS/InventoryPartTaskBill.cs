﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace DCMS.Domain.Main
{

    /// <summary>
    /// 用于表示盘点任务(部分)
    /// </summary>
    public class InventoryPartTaskBill : BaseBillEntity<int,InventoryPartTaskItem>
    {
        public InventoryPartTaskBill()
        {
            BillType = BillTypeEnum.InventoryPartTaskBill;
        }


        //private ICollection<InventoryPartTaskItem> _inventoryPartTaskItems;


        /// <summary>
        /// 盘点人
        /// </summary>
        public int InventoryPerson { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        public int WareHouseId { get; set; }

        /// <summary>
        /// 盘点时间
        /// </summary>
        public DateTime InventoryDate { get; set; }


        /// <summary>
        /// 关联盈亏单
        /// </summary>
        public int? InventoryProfitLossBillId { get; set; }


        ///// <summary>
        ///// 制单人
        ///// </summary>
        //public int MakeUserId { get; set; }

        ///// <summary>
        ///// 审核人
        ///// </summary>
        //public int? AuditedUserId { get; set; }
        ///// <summary>
        ///// 状态(审核)
        ///// </summary>
        //[Column(TypeName = "BIT(1)")]
        //public bool AuditedStatus { get; set; }

        ///// <summary>
        ///// 审核时间
        ///// </summary>
        //public DateTime? AuditedDate { get; set; }

        /// <summary>
        /// 盘点状态(1进行中，2已结束,3已取消)
        /// </summary>
        public int InventoryStatus { get; set; }

        /// <summary>
        /// 完成人
        /// </summary>
        public int? CompletedUserId { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? CompletedDate { get; set; }

        /// <summary>
        /// 打印数
        /// </summary>
        public int? PrintNum { get; set; }


        //public DateTime CreatedOnUtc { get; set; }

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
        ///// (导航)
        ///// </summary>
        //public virtual ICollection<InventoryPartTaskItem> InventoryPartTaskItems
        //{
        //    get { return _inventoryPartTaskItems ?? (_inventoryPartTaskItems = new List<InventoryPartTaskItem>()); }
        //    protected set { _inventoryPartTaskItems = value; }
        //}


        /// <summary>
        /// 记账凭证
        /// </summary>
        public int VoucherId { get; set; }
    }


    /// <summary>
    /// 盘点任务项目
    /// </summary>

    public class InventoryPartTaskItem : AuditableEntity<int>
    {

        /// <summary>
        /// 盘点任务单
        /// </summary>
        public int InventoryPartTaskBillId { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public int UnitId { get; set; }


        /// <summary>
        /// 当前库存数量
        /// </summary>
        public int? CurrentStock { get; set; }

        /// <summary>
        /// 大单位数量
        /// </summary>
        public int? BigUnitQuantity { get; set; }

        /// <summary>
        /// 中单位数量
        /// </summary>
        public int? AmongUnitQuantity { get; set; }

        /// <summary>
        /// 小单位数量
        /// </summary>
        public int? SmallUnitQuantity { get; set; }

        /// <summary>
        /// 盘盈数量
        /// </summary>
        public int? VolumeQuantity { get; set; }

        /// <summary>
        /// 盘亏数量
        /// </summary>
        public int? LossesQuantity { get; set; }

        /// <summary>
        /// 盘盈批发金额
        /// </summary>
        public decimal? VolumeWholesaleAmount { get; set; }

        /// <summary>
        /// 盘亏批发金额
        /// </summary>
        public decimal? LossesWholesaleAmount { get; set; }

        /// <summary>
        /// 盘盈成本金额
        /// </summary>
        public decimal? VolumeCostAmount { get; set; }

        /// <summary>
        /// 盘亏成本金额
        /// </summary>
        public decimal? LossesCostAmount { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public string ManufactureDete { get; set; }

        //(导航) 盘点任务(部分)
        public virtual InventoryPartTaskBill InventoryPartTaskBill { get; set; }
    }

    /// <summary>
    /// 项目保存或者编辑
    /// </summary>
    public class InventoryPartTaskBillUpdate : AuditableEntity<int>
    {

        public InventoryPartTaskBillUpdate()
        {
            Items = new List<InventoryPartTaskItem>();
        }

        /// <summary>
        /// 盘点人
        /// </summary>
        public int InventoryPerson { get; set; } = 0;

        /// <summary>
        /// 仓库
        /// </summary>
        public int WareHouseId { get; set; } = 0;

        /// <summary>
        /// 盘点时间
        /// </summary>
        public DateTime InventoryDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 操作源
        /// </summary>
        public int? Operation { get; set; }

        /// <summary>
        /// 项目
        /// </summary>
        public List<InventoryPartTaskItem> Items { get; set; }

    }

}
