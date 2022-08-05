namespace DCMS.Domain
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// ��ʾ��ע����
    /// </summary>
    public partial class RemarkConfig : AuditableEntity<int>
    {

        /// <summary>
        /// ��ע����       
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ����۸����
        /// </summary>
        [Column(TypeName = "BIT(1)")]
        public bool RemberPrice { get; set; }

    }
}
