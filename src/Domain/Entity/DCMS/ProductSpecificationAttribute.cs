namespace DCMS.Domain.Main
{
    
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// ��ʾ��Ʒ�������
    /// </summary>
    public partial class ProductSpecificationAttribute : AuditableEntity<int>
    {
        /// <summary>
        /// ��Ʒ��ʶ
        /// </summary>
        public int ProductId { get; set; } = 0;

        /// <summary>
        /// ����������ʶ
        /// </summary>
        public int SpecificationAttributeOptionId { get; set; } = 0;

        /// <summary>
        /// �Զ���ֵ
        /// </summary>
        public string CustomValue { get; set; } = "";

        /// <summary>
        /// �Ƿ�����ɸѡ
        /// </summary>
        [Column(TypeName = "BIT(1)")]
        public bool AllowFiltering { get; set; } = false;

        /// <summary>
        /// �Ƿ���������Ʒҳ����ʾ
        /// </summary>
        [Column(TypeName = "BIT(1)")]
        public bool ShowOnProductPage { get; set; } = false;

        /// <summary>
        /// ����
        /// </summary>
        public int DisplayOrder { get; set; } = 0;



        /// <summary>
        /// ��Ʒ
        /// </summary>
        
        public virtual Product Product { get; set; }

        /// <summary>
        /// �����
        /// </summary>
        
        public virtual SpecificationAttributeOption SpecificationAttributeOption { get; set; }
    }
}
