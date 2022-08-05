namespace DCMS.Domain.Main
{
    using System.ComponentModel.DataAnnotations.Schema;
    /// <summary>
    /// ��ʾ��Ʒ�ṩ��
    /// </summary>
    public partial class ProductManufacturer : AuditableEntity<int>
    {
        /// <summary>
        /// ��Ʒ��ʶ
        /// </summary>
        public int ProductId { get; set; } = 0;

        /// <summary>
        /// �ṩ��ID
        /// </summary>
        public int ManufacturerId { get; set; } = 0;

        /// <summary>
        /// �Ƿ���ɫ��Ʒ
        /// </summary>
        [Column(TypeName = "BIT(1)")]
        public bool IsFeaturedProduct { get; set; } = false;

        /// <summary>
        /// ����
        /// </summary>
        public int DisplayOrder { get; set; } = 0;

        /// <summary>
        /// �ṩ��
        /// </summary>
        public virtual Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// ��Ʒ
        /// </summary>
        public virtual Product Product { get; set; }
    }

}
