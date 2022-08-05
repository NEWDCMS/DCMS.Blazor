namespace DCMS.Domain.Main
{
    using System.ComponentModel.DataAnnotations.Schema;
    /// <summary>
    /// �������
    /// </summary>
    public partial class ProductVariantAttributeCombination : AuditableEntity<int>
    {
        /// <summary>
        /// ��ƷID
        /// </summary>
        public int ProductId { get; set; } = 0;

        /// <summary>
        /// ����XML
        /// </summary>
        public string AttributesXml { get; set; } = "";

        /// <summary>
        /// �����
        /// </summary>
        public int StockQuantity { get; set; } = 0;

        /// <summary>
        /// �Ƿ�������ȱ��ʱ�µ�
        /// </summary>
        [Column(TypeName = "BIT(1)")]
        public bool AllowOutOfStockOrders { get; set; } = false;

        /// <summary>
        /// ��ƷSKU��
        /// </summary>
        public string Sku { get; set; } = "";

        /// <summary>
        /// ��Ʒָ���ṩ�̱���
        /// </summary>
        public string ManufacturerPartNumber { get; set; } = "";

        /// <summary>
        /// Gtin ����
        /// </summary>
        public string Gtin { get; set; } = "";

        /// <summary>
        /// ��Ʒ
        /// </summary>
        public virtual Product Product { get; set; }

    }
}
