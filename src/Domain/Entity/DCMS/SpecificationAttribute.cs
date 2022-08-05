using System.Collections.Generic;

namespace DCMS.Domain.Main
{

    public enum SpecificationAttributeType
    {
        /// <summary>
        /// Option
        /// </summary>
        Option = 0,

        /// <summary>
        /// Custom text
        /// </summary>
        CustomText = 10,

        /// <summary>
        /// Custom HTML text
        /// </summary>
        CustomHtmlText = 20,

        /// <summary>
        /// Hyperlink
        /// </summary>
        Hyperlink = 30
    }

    /// <summary>
    ///  ��ʾ�������
    /// </summary>
    public partial class SpecificationAttribute : AuditableEntity<int>
    {
        private ICollection<SpecificationAttributeOption> _specificationAttributeOptions;


        /// <summary>
        /// ������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public virtual ICollection<SpecificationAttributeOption> SpecificationAttributeOptions
        {
            get { return _specificationAttributeOptions ?? (_specificationAttributeOptions = new List<SpecificationAttributeOption>()); }
            protected set { _specificationAttributeOptions = value; }
        }
    }
}
