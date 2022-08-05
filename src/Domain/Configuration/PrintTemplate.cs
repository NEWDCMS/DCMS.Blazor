namespace DCMS.Domain
{
    /// <summary>
    /// ��ʾ��ӡģ��
    /// </summary>
    public partial class PrintTemplate : AuditableEntity<int>
    {
        /// <summary>
        /// ģ������
        /// </summary>
        public int TemplateType { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public int BillType { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Content { get; set; }


        public int PaperType { get; set; }

        public PaperTypeEnum EPaperTypes
        {
            get => (PaperTypeEnum)PaperType;
            set => PaperType = (int)value;
        }


        /// <summary>
        /// ֽ�ſ��
        /// </summary>
        public double PaperWidth { get; set; }

        /// <summary>
        /// ֽ�Ÿ߶�
        /// </summary>
        public double PaperHeight { get; set; }

    }
}
