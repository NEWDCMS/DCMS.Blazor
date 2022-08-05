using System;
namespace DCMS.Domain.Main
{

	/// <summary>
	/// ��ʾ���Ԥ������
	/// </summary>
	public partial class StockEarlyWarning : AuditableEntity<int>
	{
		/// <summary>
		/// �ֿ�Id
		/// </summary>
		public int WareHouseId { get; set; }

		/// <summary>
		/// ��ƷId
		/// </summary>
		public int ProductId { get; set; }

		/// <summary>
		/// ��Ʒ����
		/// </summary>
		public string ProductName { get; set; }

		/// <summary>
		/// ��λ
		/// </summary>
		public int UnitId { get; set; }

		/// <summary>
		/// ����
		/// </summary>
		public string BarCode { get; set; }

		/// <summary>
		/// ������λ
		/// </summary>
		public string AuxiliaryUnit { get; set; }

		/// <summary>
		/// ȱ��Ԥ����
		/// </summary>
		public int ShortageWarningQuantity { get; set; }

		/// <summary>
		/// ��ѹԤ����
		/// </summary>
		public int BacklogWarningQuantity { get; set; }


		public DateTime CreatedOnUtc { get; set; }

		public virtual WareHouse WareHouse { get; set; }

	}
}
