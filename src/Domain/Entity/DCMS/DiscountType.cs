namespace DCMS.Domain.Main
{
    /// <summary>
    /// �ۿ�����
    /// </summary>
    public enum DiscountType
    {
        /// <summary>
        /// ����������ܼ�
        /// </summary>
        AssignedToOrderTotal = 1,
        AssignedToSkus = 2,
        AssignedToCategories = 5,
        AssignedToManufacturers = 6,
        AssignedToShipping = 10,
        AssignedToOrderSubTotal = 20
    }
}
