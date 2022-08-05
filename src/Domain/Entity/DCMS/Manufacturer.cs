using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DCMS.Domain.Main
{
    /// <summary>
    ///  ��ʾ��Ʒ�ṩ��
    /// </summary>
    public partial class Manufacturer : AuditableEntity<int>
    {
        public Manufacturer() { Status = true; }
        /// <summary>
        /// �ṩ����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public string MnemonicName { get; set; }
        /// <summary>
        /// ��ϵ��
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// ��ϵ�˵绰
        /// </summary>
        public string ContactPhone { get; set; }
        /// <summary>
        /// ��ַ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// ״̬
        /// </summary>
        [Column(TypeName = "BIT(1)")]
        public bool Status { get; set; }
        /// <summary>
        /// �Ƿ�ɾ��
        /// </summary>
        [Column(TypeName = "BIT(1)")]
        public bool Deleted { get; set; }
        /// <summary>
        /// �۸�Χ
        /// </summary>
        public string PriceRanges { get; set; }


        /// <summary>
        /// ����
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }
    }


    /// <summary>
    /// ��Ӧ���˻����
    /// </summary>
    public class ManufacturerBalance : AuditableEntity<int>
    {
        /// <summary>
        /// ��ĿId
        /// </summary>
        public int AccountingOptionId { get; set; }

        /// <summary>
        /// ��Ŀ����
        /// </summary>
        public string AccountingName { get; set; }

        /// <summary>
        /// ʣ��Ԥ������
        /// </summary>
        public decimal AdvanceAmountBalance { get; set; } = 0;
        /// <summary>
        /// ��Ƿ��
        /// </summary>
        public decimal TotalOweCash { get; set; } = 0;
        /// <summary>
        /// ʣ��Ƿ����
        /// </summary>
        public decimal OweCashBalance { get; set; } = 0;

    }
}
