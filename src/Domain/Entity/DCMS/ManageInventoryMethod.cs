namespace DCMS.Domain.Main
{
    /// <summary>
    /// ��ʾ���ڿ�����취
    /// </summary>
    public enum ManageInventoryMethod
    {
        /// <summary>
        /// �����ٲ�Ʒ���
        /// </summary>
        DontManageStock = 0,
        /// <summary>
        /// ���ٲ�Ʒ���
        /// </summary>
        ManageStock = 1,
        /// <summary>
        /// ����Ʒ���Ը��ٲ�Ʒ���
        /// </summary>
        ManageStockByAttributes = 2,
    }

    /// <summary>
    /// �Ϳ��ʱ�Ĵ�����
    /// </summary>
    public enum LowStockActivity
    {
        /// <summary>
        /// ������
        /// </summary>
        Nothing = 0,
        /// <summary>
        /// �����µ���ť
        /// </summary>
        DisablePlaceButton = 1,
        /// <summary>
        /// ��������Ʒ
        /// </summary>
        Unpublish = 2,
    }
}
