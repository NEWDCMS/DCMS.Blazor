
using System.ComponentModel.DataAnnotations.Schema;

namespace DCMS.Domain.Main
{
    /// <summary>
    /// ������Ʒ����ֵ
    /// </summary>
    public partial class ProductVariantAttributeValue : AuditableEntity<int>
    {


        /// <summary>
        /// ����ID
        /// </summary>
        public int AttributeValueTypeId { get; set; }

        /// <summary>
        /// ������ƷID
        /// </summary>
        public int AssociatedProductId { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ColorSquaresRgb { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal PriceAdjustment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal WeightAdjustment { get; set; }

        /// <summary>
        /// �Ƿ�Ԥ��ѡ��
        /// </summary>
        [Column(TypeName = "BIT(1)")]
        public bool IsPreSelected { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ����ͼƬ
        /// </summary>
        public int PictureId { get; set; }



        /// <summary>
        /// ����ID
        /// </summary>
        public virtual int ProductVariantAttributeId { get; set; }

        /// <summary>
        /// ��Ʒ��������
        /// </summary>
        public virtual ProductVariantAttribute ProductVariantAttribute { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public AttributeValueType AttributeValueType
        {
            get
            {
                return (AttributeValueType)AttributeValueTypeId;
            }
            set
            {
                AttributeValueTypeId = (int)value;
            }
        }
    }
}
