﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DCMS.Domain.Main;

namespace DCMS.Domain.Auth
{
	/// <summary>
	/// 用户实体
	/// </summary>
	public partial class User : AuditableEntity<int>
	{
		private ICollection<UserUserRole> _userUserRoles;
		private ICollection<UserGroupUser> _userGroupUsers;
		private ICollection<UserLineTierAssign> _userLineTiers;
		private IList<UserRole> _userRoles;

		public User()
		{
			UserGuid = Guid.NewGuid().ToString();
			PasswordFormat = PasswordFormat.Clear;
		}

		/// <summary>
		/// 经销商
		/// </summary>
		//移除

		/// <summary>
		/// 直接上级
		/// </summary>
		public int? Dirtleader { get; set; } = 0;

		/// <summary>
		/// 用户标识（GUID）
		/// </summary>
		public string UserGuid { get; set; }

		/// <summary>
		/// 用户名
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		/// 真实姓名
		/// </summary>
		public string UserRealName { get; set; } = " ";

		/// <summary>
		/// 邮箱
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// 手机号
		/// </summary>
		public string MobileNumber { get; set; }

		/// <summary>
		/// 密码
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// 密码格式类型
		/// </summary>
		public int PasswordFormatId { get; set; }

		/// <summary>
		/// 密码格式方式
		/// </summary>
		
		public PasswordFormat PasswordFormat
		{
			get { return (PasswordFormat)PasswordFormatId; }
			set { PasswordFormatId = (int)value; }
		}

		/// <summary>
		/// 密码秘钥
		/// </summary>
		public string PasswordSalt { get; set; } = "";

		/// <summary>
		///管理员评论
		/// </summary>
		public string AdminComment { get; set; } = "";

		/// <summary>
		/// 用户是否免税
		/// </summary>
		[System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "BIT(1)")]
		public bool IsTaxExempt { get; set; }

		/// <summary>
		/// 是否有效
		/// </summary>
		[System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "BIT(1)")]
		public bool Active { get; set; }

		public DateTime? ActivationTime { get; set; } = DateTime.Now;

		/// <summary>
		///是否删除
		/// </summary>
		[System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "BIT(1)")]
		public bool Deleted { get; set; }

		/// <summary>
		/// 是否系统账户
		/// </summary>
		[System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "BIT(1)")]
		public bool IsSystemAccount { get; set; }

		/// <summary>
		/// 系统名称
		/// </summary>
		public string SystemName { get; set; } = "";

		/// <summary>
		/// 是否平台创建（平台创建的 管理员账号 不能删除管理员权限）
		/// </summary>
		[System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "BIT(1)")]
		public bool IsPlatformCreate { get; set; }

		/// <summary>
		/// 最后访问IP
		/// </summary>
		public string LastIpAddress { get; set; } = "";

		/// <summary>
		/// 账户创建时间
		/// </summary>
		public DateTime CreatedOnUtc { get; set; }

		/// <summary>
		/// 最后登录时间
		/// </summary>
		public DateTime? LastLoginDateUtc { get; set; } = DateTime.Now;

		/// <summary>
		/// 最后活动时间
		/// </summary>
		public DateTime LastActivityDateUtc { get; set; }

		/// <summary>
		/// 是否邮件安全验证
		/// </summary>
		[System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "BIT(1)")]
		public bool EmailValidation { get; set; }


		/// <summary>
		/// 是否手机安全验证
		/// </summary>
		[System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "BIT(1)")]
		public bool MobileValidation { get; set; }


		/// <summary>
		/// 账户类型(0 区域公司,1 经销商)
		/// </summary>
		public int AccountType { get; set; }

		/// <summary>
		/// 组织机构代码(账户类型需为(0 区域公司))
		/// </summary>
		public int BranchCode { get; set; }

		/// <summary>
		/// 部门ID
		/// </summary>
		public int? BranchId { get; set; } = 0;

		/// <summary>
		/// 业务员提成方案
		/// </summary>
		public int? SalesmanExtractPlanId { get; set; } = 0;

		/// <summary>
		/// 送货员提成方案
		/// </summary>
		public int? DeliverExtractPlanId { get; set; } = 0;

		/// <summary>
		/// 最大欠款额度
		/// </summary>
		public decimal? MaxAmountOfArrears { get; set; }

		/// <summary>
		/// 头像
		/// </summary>
		public string FaceImage { get; set; } = "";

		/// <summary>
		/// UUID
		/// </summary>
		public string AppId { get; set; } = "";


		//新增加

		/// <summary>
		/// 是否需要用户重新登录
		/// </summary>
		[Column(TypeName = "BIT(1)")]
		public bool RequireReLogin { get; set; }

		/// <summary>
		/// 失败的登录尝试次数（密码错误）
		/// </summary>
		public int FailedLoginAttempts { get; set; }

		/// <summary>
		/// 登录（锁定）的日期和时间
		/// </summary>
		public DateTime? CannotLoginUntilDateUtc { get; set; } = DateTime.Now;

		[Column(TypeName = "BIT(1)")]
		public bool UseACLPc { get; set; }

		[Column(TypeName = "BIT(1)")]
		public bool UseACLMobile { get; set; }

		#region 导航属性

		/// <summary>
		/// 用户角色
		/// </summary>
		public virtual IList<UserRole> UserRoles
		{
			get => _userRoles ?? (_userRoles = UserUserRoles.Select(mapping => mapping.UserRole).ToList());
		}
		/// <summary>
		/// 获取设置用户角色
		/// </summary>
		
		public virtual ICollection<UserUserRole> UserUserRoles
		{
			get
			{
				return _userUserRoles ?? (_userUserRoles = new List<UserUserRole>());
			}
			protected set { _userUserRoles = value; }
		}



		/// <summary>
		/// 用户组集合
		/// </summary>
		
		public virtual ICollection<UserGroupUser> UserGroupUsers
		{
			get { return _userGroupUsers ?? (_userGroupUsers = new List<UserGroupUser>()); }
			protected set { _userGroupUsers = value; }
		}


		/// <summary>
		/// 业务员线路
		/// </summary>
		
		public virtual ICollection<UserLineTierAssign> UserLineTiers
		{
			get { return _userLineTiers ?? (_userLineTiers = new List<UserLineTierAssign>()); }
			protected set { _userLineTiers = value; }
		}
		#endregion

		#region 方法

		public void AddUserRole(UserRole role)
		{
			UserRoles.Add(role);
			//_userRoles = null;
		}


		public void AddUserUserRole(UserUserRole role)
		{
			UserUserRoles.Add(role);
			//_userUserRoles = null;
		}


		public void RemoveAddUserUserRole(UserUserRole role)
		{
			UserUserRoles.Remove(role);
			_userUserRoles = null;
		}




		#endregion


		///[NotMapped]
		
		public List<RefreshToken> RefreshTokens { get; set; }

		/// <summary>
		/// 用户APP访问控制
		/// </summary>
		public string AppModuleAcl { get; set; }

		/// <summary>
		/// 直属下级
		/// </summary>
		public string Subordinates { get; set; }

	}

	public partial class UserUserRole : AuditableEntity<int>
	{
		public int UserId { get; set; }
		public int UserRoleId { get; set; }

		public virtual User User { get; set; }
		public virtual UserRole UserRole { get; set; }
	}

	public class UserPasswordChangedEvent
	{
		/// <summary>
		/// Ctor
		/// </summary>
		/// <param name="password">Password</param>
		public UserPasswordChangedEvent(UserPassword password)
		{
			Password = password;
		}

		/// <summary>
		/// User password
		/// </summary>
		public UserPassword Password { get; }
	}

	public partial class UserPassword : AuditableEntity<int>
	{
		public UserPassword()
		{
			PasswordFormat = PasswordFormat.Clear;
		}

		public int UserId { get; set; }
		public string Password { get; set; }
		public int PasswordFormatId { get; set; }
		public string PasswordSalt { get; set; }
		public DateTime CreatedOnUtc { get; set; }
		public PasswordFormat PasswordFormat
		{
			get => (PasswordFormat)PasswordFormatId;
			set => PasswordFormatId = (int)value;
		}
		public virtual User User { get; set; }
	}

	public enum UserRegistrationType
	{
		/// <summary>
		/// Standard account creation
		/// </summary>
		Standard = 1,

		/// <summary>
		/// Email validation is required after registration
		/// </summary>
		EmailValidation = 2,

		/// <summary>
		/// A user should be approved by administrator
		/// </summary>
		AdminApproval = 3,

		/// <summary>
		/// Registration is disabled
		/// </summary>
		Disabled = 4
	}


	public partial class UserGroupUser : AuditableEntity<int>
	{

		public int User_Id { get; set; }
		public int UserGroup_Id { get; set; }


		public virtual User User { get; set; }
		public virtual UserGroup UserGroup { get; set; }
	}

	/// <summary>
	/// 用户提成
	/// </summary>
	public partial class UserPercentages
	{
		public User User { get; set; }
		/// <summary>
		/// 业务提成
		/// </summary>
		public IList<Percentage> SPercentages { get; set; } = new List<Percentage>();
		/// <summary>
		/// 送货提成
		/// </summary>
		public IList<Percentage> DPercentages { get; set; } = new List<Percentage>();
	}

	/// <summary>
	/// 用户特性
	/// </summary>
	public partial class UserAttribute : AuditableEntity<int>
	{
		private ICollection<UserAttributeValue> _userAttributeValues;

		public string Name { get; set; }
		[Column(TypeName = "BIT(1)")]
		public bool IsRequired { get; set; }
		public int AttributeControlTypeId { get; set; }
		public int DisplayOrder { get; set; }
		public AttributeControlType AttributeControlType
		{
			get => (AttributeControlType)AttributeControlTypeId;
			set => AttributeControlTypeId = (int)value;
		}

		public virtual ICollection<UserAttributeValue> UserAttributeValues
		{
			get => _userAttributeValues ?? (_userAttributeValues = new List<UserAttributeValue>());
			protected set => _userAttributeValues = value;
		}
	}

	/// <summary>
	/// 用户特性值
	/// </summary>
	public partial class UserAttributeValue : AuditableEntity<int>
	{
		public int UserAttributeId { get; set; }
		public string Name { get; set; }
		[Column(TypeName = "BIT(1)")]
		public bool IsPreSelected { get; set; }
		public int DisplayOrder { get; set; }
		public virtual UserAttribute UserAttribute { get; set; }
	}



	/// <summary>
	/// 用于表示用户账户余额
	/// </summary>
	public class UserBalance
	{

	}

}
