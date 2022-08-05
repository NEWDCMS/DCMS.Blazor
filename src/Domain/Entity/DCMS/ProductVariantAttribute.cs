using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DCMS.Domain.Main
{
    /// <summary>
    /// ��Ʒ��������
    /// </summary>
    public partial class ProductVariantAttribute : AuditableEntity<int>
    {
        private ICollection<ProductVariantAttributeValue> _productVariantAttributeValues;

        /// <summary>
        /// ��ʾ
        /// </summary>
        public string TextPrompt { get; set; } = "";

        /// <summary>
        /// �Ƿ������Ʒ
        /// </summary>
        [Column(TypeName = "BIT(1)")]
        public bool IsRequired { get; set; } = false;

        /// <summary>
        /// ��������ID
        /// </summary>
        public int AttributeControlTypeId { get; set; } = 0;

        /// <summary>
        /// ����
        /// </summary>
        public int DisplayOrder { get; set; } = 0;

        /// <summary>
        /// ������������
        /// </summary>
        public AttributeControlType AttributeControlType
        {
            get
            {
                return (AttributeControlType)AttributeControlTypeId;
            }
            set
            {
                AttributeControlTypeId = (int)value;
            }
        }





        /// <summary>
        ///��ƷID
        /// </summary>
        public virtual int ProductId { get; set; } = 0;

        /// <summary>
        /// ��Ʒ����ID
        /// </summary>
        public virtual int ProductAttributeId { get; set; } = 0;


        /// <summary>
        /// ��ȡ��Ʒ����
        /// </summary>
        public virtual ProductAttribute ProductAttribute { get; set; }

        /// <summary>
        /// ��ȡ��Ʒ
        /// </summary>
        public virtual Product Product { get; set; }


        /// <summary>
        /// ��ȡ��������
        /// </summary>
        public virtual ICollection<ProductVariantAttributeValue> ProductVariantAttributeValues
        {
            get { return _productVariantAttributeValues ?? (_productVariantAttributeValues = new List<ProductVariantAttributeValue>()); }
            protected set { _productVariantAttributeValues = value; }
        }

    }

}
