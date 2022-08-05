using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DCMS.Domain.Main
{
	public partial class NewsCategory : AuditableEntity<int>
	{
		private ICollection<NewsItem> _newsItems;

		public NewsCategory()
		{
			_newsItems = new List<NewsItem>();
		}


		public int? NewsItemId { get; set; } = 0;
		public int? NewsCategoryId { get; set; } = 0;

		/// <summary>
		/// ����
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// ˳��
		/// </summary>
		public int DisplayOrder { get; set; }

		/// <summary>
		/// ����Id
		/// </summary>
		public int? ParentId { get; set; } = 0;

		/// <summary>
		/// �Ƿ���ʾ
		/// </summary>
		[Column(TypeName = "BIT(1)")]
		public bool Published { get; set; }

		/// <summary>
		/// �Ƿ�ɾ��
		/// </summary>
		[Column(TypeName = "BIT(1)")]
		public bool Deleted { get; set; }

		/// <summary>
		/// �Ƿ���ʾ����ҳ
		/// </summary>
		[Column(TypeName = "BIT(1)")]
		public bool ShowOnHomePage { get; set; }

		[Column(TypeName = "BIT(1)")]
		public bool SubjectToAcl { get; set; }

		/// <summary>
		/// �Ƿ����ƾ�����
		/// </summary>
		[Column(TypeName = "BIT(1)")]
		public bool LimitedToStores { get; set; }

		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime CreateDate { get; set; }

		/// <summary>
		/// �������
		/// </summary>
		public virtual NewsCategory NewsCategories { get; set; }

		/// <summary>
		/// ����𼯺�
		/// </summary>
		public virtual ICollection<NewsCategory> ChildCategories { get; set; }


		public virtual ICollection<NewsItem> NewsItems
		{
			get { return _newsItems ?? (_newsItems = new List<NewsItem>()); }
			protected set { _newsItems = value; }
		}

	}

}
