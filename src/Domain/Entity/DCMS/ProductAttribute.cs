
namespace DCMS.Domain.Main
{
    /// <summary>
    ///  ��ʾ��Ʒ����
    /// </summary>
    public partial class ProductAttribute : AuditableEntity<int>
    {



        /// <summary>
        /// ������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Description { get; set; }
    }
}
