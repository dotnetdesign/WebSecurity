using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ServiceModel;
using DotNetDesign.Common;
using DotNetDesign.Substrate;
using Common.Logging;

namespace DotNetDesign.WebSecurity
{
	internal static class Logger
    {
        static Logger()
        {
            Assembly = LogManager.GetLogger("DotNetDesign.WebSecurity");
        }

        internal static ILog Assembly;
    }

	#region Entity Data Interfaces
	public partial interface IUserData : IEntityData<IUserData, IUser, IUserRepository>
	{
		[Required]
		[DisplayName("First Name")]
		string FirstName { get; set; }
		[Required]
		[DisplayName("Last Name")]
		string LastName { get; set; }
		[Required]
		[DisplayName("E-mail Address")]
		[RegularExpression(Constants.RegExs.Email)]
		string EmailAddress { get; set; }
		[Required]
		[DisplayName("Display Name")]
		string DisplayName { get; set; }
		[DisplayName("Permissions")]
		uint? Permissions { get; set; }
		[DisplayName("Role IDs")]
		HashSet<Guid> RoleIds { get; set; }
		[DisplayName("OAuth Membership IDs")]
		HashSet<Guid> OAuthMembershipIds { get; set; }
		[Required]
		[DisplayName("Number of sign-ins")]
		int SignInCount { get; set; }
		[DisplayName("Date/Time of current sign-in")]
		DateTime? CurrentSignInAt { get; set; }
		[DisplayName("Date/Time of last sign-in")]
		DateTime? LastSignInAt { get; set; }
		[DisplayName("Current sign-in IP address")]
		string CurrentSignInIp { get; set; }
		[DisplayName("Last sign-in IP address")]
		string LastSignInIp { get; set; }
		[Required]
		[DisplayName("Confirmation Token")]
		Guid ConfirmationToken { get; set; }
		[DisplayName("Date/Time Confirmed")]
		DateTime? ConfirmedAt { get; set; }
		[DisplayName("Date/Time Confirmation was sent")]
		DateTime? ConfirmationSentAt { get; set; }
		[Required]
		[DisplayName("Is Super Admin?")]
		bool IsSuperAdmin { get; set; }
		[Required]
		[DisplayName("Is Approved?")]
		bool IsApproved { get; set; }
		[DisplayName("Approved by")]
		Guid ApprovedById { get; set; }
		[DisplayName("Date/Time Approved")]
		DateTime? ApprovedAt { get; set; }
	}
	public partial interface IRoleData : IEntityData<IRoleData, IRole, IRoleRepository>
	{
		[Required]
		[DisplayName("Name")]
		string Name { get; set; }
		[Required]
		[DisplayName("Permissions")]
		uint Permissions { get; set; }
	}
	public partial interface IOAuthMembershipData : IEntityData<IOAuthMembershipData, IOAuthMembership, IOAuthMembershipRepository>
	{
		[Required]
		[DisplayName("Provider Name")]
		string ProviderName { get; set; }
		[Required]
		[DisplayName("Provider User ID")]
		string ProviderUserId { get; set; }
		[Required]
		[DisplayName("User ID")]
		Guid UserId { get; set; }
	}
	#endregion Entity Data Interfaces

	#region Entity Interfaces
	public partial interface IUser : IEntity<IUser, IUserData, IUserRepository>, IUserData {}
	public partial interface IRole : IEntity<IRole, IRoleData, IRoleRepository>, IRoleData {}
	public partial interface IOAuthMembership : IEntity<IOAuthMembership, IOAuthMembershipData, IOAuthMembershipRepository>, IOAuthMembershipData {}
	#endregion Entity Interfaces

	#region Entity Repository Interfaces
	public partial interface IUserRepository : IEntityRepository<IUserRepository, IUser, IUserData> {}
	public partial interface IRoleRepository : IEntityRepository<IRoleRepository, IRole, IRoleData> {}
	public partial interface IOAuthMembershipRepository : IEntityRepository<IOAuthMembershipRepository, IOAuthMembership, IOAuthMembershipData> {}
	#endregion Entity Repository Interfaces

	#region Entity Repository Service Interfaces
	[ServiceContract]
	public partial interface IUserRepositoryService : IEntityRepositoryService<IUserData, IUser, IUserRepository, UserData> {}
	[ServiceContract]
	public partial interface IRoleRepositoryService : IEntityRepositoryService<IRoleData, IRole, IRoleRepository, RoleData> {}
	[ServiceContract]
	public partial interface IOAuthMembershipRepositoryService : IEntityRepositoryService<IOAuthMembershipData, IOAuthMembership, IOAuthMembershipRepository, OAuthMembershipData> {}
	#endregion Entity Repository Service Interfaces

	#region Entity Data Implementations
	[DataContract]
	[Serializable]
	public partial class UserData : BaseEntityData<IUserData, IUser, IUserRepository>, IUserData
	{
		#region IUserData Properties
		[DataMember]
		public virtual string FirstName { get; set; }
		[DataMember]
		public virtual string LastName { get; set; }
		[DataMember]
		public virtual string EmailAddress { get; set; }
		[DataMember]
		public virtual string DisplayName { get; set; }
		[DataMember]
		public virtual uint? Permissions { get; set; }
		[DataMember]
		public virtual HashSet<Guid> RoleIds { get; set; }
		[DataMember]
		public virtual HashSet<Guid> OAuthMembershipIds { get; set; }
		[DataMember]
		public virtual int SignInCount { get; set; }
		[DataMember]
		public virtual DateTime? CurrentSignInAt { get; set; }
		[DataMember]
		public virtual DateTime? LastSignInAt { get; set; }
		[DataMember]
		public virtual string CurrentSignInIp { get; set; }
		[DataMember]
		public virtual string LastSignInIp { get; set; }
		[DataMember]
		public virtual Guid ConfirmationToken { get; set; }
		[DataMember]
		public virtual DateTime? ConfirmedAt { get; set; }
		[DataMember]
		public virtual DateTime? ConfirmationSentAt { get; set; }
		[DataMember]
		public virtual bool IsSuperAdmin { get; set; }
		[DataMember]
		public virtual bool IsApproved { get; set; }
		[DataMember]
		public virtual Guid ApprovedById { get; set; }
		[DataMember]
		public virtual DateTime? ApprovedAt { get; set; }
		#endregion IUserData Properties
	}
	[DataContract]
	[Serializable]
	public partial class RoleData : BaseEntityData<IRoleData, IRole, IRoleRepository>, IRoleData
	{
		#region IRoleData Properties
		[DataMember]
		public virtual string Name { get; set; }
		[DataMember]
		public virtual uint Permissions { get; set; }
		#endregion IRoleData Properties
	}
	[DataContract]
	[Serializable]
	public partial class OAuthMembershipData : BaseEntityData<IOAuthMembershipData, IOAuthMembership, IOAuthMembershipRepository>, IOAuthMembershipData
	{
		#region IOAuthMembershipData Properties
		[DataMember]
		public virtual string ProviderName { get; set; }
		[DataMember]
		public virtual string ProviderUserId { get; set; }
		[DataMember]
		public virtual Guid UserId { get; set; }
		#endregion IOAuthMembershipData Properties
	}
	#endregion Entity Data Implementations

	#region Entity Implementations
		public partial class User : BaseEntity<IUser, IUserData, IUserRepository>, IUser
		{
			public User(
				Func<IUserRepository> entityRepositoryFactory,
				Func<IUserData> entityDataFactory,
				Func<IConcurrencyManager<IUser, IUserData, IUserRepository>> entityConcurrencyManagerFactory,
				IEnumerable<IEntityValidator<IUser, IUserData, IUserRepository>> entityValidators,
	            Func<IPermissionAuthorizationManager<IUser, IUserData, IUserRepository>> permissionAuthorizationManagerFactory)
				: base(entityRepositoryFactory, entityDataFactory, entityConcurrencyManagerFactory, entityValidators, permissionAuthorizationManagerFactory)
			{
			}

			#region IUserData Properties
			public virtual string FirstName 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.FirstName; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.FirstName == value) return;

					var originalValue = EntityData.FirstName;
					OnPropertyChanging("FirstName", originalValue, value);
					EntityData.FirstName = value;
					OnPropertyChanged("FirstName", originalValue, value);
				}
			}
		}
		public virtual string LastName 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.LastName; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.LastName == value) return;

					var originalValue = EntityData.LastName;
					OnPropertyChanging("LastName", originalValue, value);
					EntityData.LastName = value;
					OnPropertyChanged("LastName", originalValue, value);
				}
			}
		}
		public virtual string EmailAddress 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.EmailAddress; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.EmailAddress == value) return;

					var originalValue = EntityData.EmailAddress;
					OnPropertyChanging("EmailAddress", originalValue, value);
					EntityData.EmailAddress = value;
					OnPropertyChanged("EmailAddress", originalValue, value);
				}
			}
		}
		public virtual string DisplayName 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.DisplayName; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.DisplayName == value) return;

					var originalValue = EntityData.DisplayName;
					OnPropertyChanging("DisplayName", originalValue, value);
					EntityData.DisplayName = value;
					OnPropertyChanged("DisplayName", originalValue, value);
				}
			}
		}
		public virtual uint? Permissions 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.Permissions; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.Permissions == value) return;

					var originalValue = EntityData.Permissions;
					OnPropertyChanging("Permissions", originalValue, value);
					EntityData.Permissions = value;
					OnPropertyChanged("Permissions", originalValue, value);
				}
			}
		}
		public virtual HashSet<Guid> RoleIds 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.RoleIds; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.RoleIds == value) return;

					var originalValue = EntityData.RoleIds;
					OnPropertyChanging("RoleIds", originalValue, value);
					EntityData.RoleIds = value;
					OnPropertyChanged("RoleIds", originalValue, value);
				}
			}
		}
		public virtual HashSet<Guid> OAuthMembershipIds 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.OAuthMembershipIds; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.OAuthMembershipIds == value) return;

					var originalValue = EntityData.OAuthMembershipIds;
					OnPropertyChanging("OAuthMembershipIds", originalValue, value);
					EntityData.OAuthMembershipIds = value;
					OnPropertyChanged("OAuthMembershipIds", originalValue, value);
				}
			}
		}
		public virtual int SignInCount 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.SignInCount; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.SignInCount == value) return;

					var originalValue = EntityData.SignInCount;
					OnPropertyChanging("SignInCount", originalValue, value);
					EntityData.SignInCount = value;
					OnPropertyChanged("SignInCount", originalValue, value);
				}
			}
		}
		public virtual DateTime? CurrentSignInAt 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.CurrentSignInAt; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.CurrentSignInAt == value) return;

					var originalValue = EntityData.CurrentSignInAt;
					OnPropertyChanging("CurrentSignInAt", originalValue, value);
					EntityData.CurrentSignInAt = value;
					OnPropertyChanged("CurrentSignInAt", originalValue, value);
				}
			}
		}
		public virtual DateTime? LastSignInAt 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.LastSignInAt; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.LastSignInAt == value) return;

					var originalValue = EntityData.LastSignInAt;
					OnPropertyChanging("LastSignInAt", originalValue, value);
					EntityData.LastSignInAt = value;
					OnPropertyChanged("LastSignInAt", originalValue, value);
				}
			}
		}
		public virtual string CurrentSignInIp 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.CurrentSignInIp; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.CurrentSignInIp == value) return;

					var originalValue = EntityData.CurrentSignInIp;
					OnPropertyChanging("CurrentSignInIp", originalValue, value);
					EntityData.CurrentSignInIp = value;
					OnPropertyChanged("CurrentSignInIp", originalValue, value);
				}
			}
		}
		public virtual string LastSignInIp 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.LastSignInIp; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.LastSignInIp == value) return;

					var originalValue = EntityData.LastSignInIp;
					OnPropertyChanging("LastSignInIp", originalValue, value);
					EntityData.LastSignInIp = value;
					OnPropertyChanged("LastSignInIp", originalValue, value);
				}
			}
		}
		public virtual Guid ConfirmationToken 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.ConfirmationToken; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.ConfirmationToken == value) return;

					var originalValue = EntityData.ConfirmationToken;
					OnPropertyChanging("ConfirmationToken", originalValue, value);
					EntityData.ConfirmationToken = value;
					OnPropertyChanged("ConfirmationToken", originalValue, value);
				}
			}
		}
		public virtual DateTime? ConfirmedAt 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.ConfirmedAt; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.ConfirmedAt == value) return;

					var originalValue = EntityData.ConfirmedAt;
					OnPropertyChanging("ConfirmedAt", originalValue, value);
					EntityData.ConfirmedAt = value;
					OnPropertyChanged("ConfirmedAt", originalValue, value);
				}
			}
		}
		public virtual DateTime? ConfirmationSentAt 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.ConfirmationSentAt; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.ConfirmationSentAt == value) return;

					var originalValue = EntityData.ConfirmationSentAt;
					OnPropertyChanging("ConfirmationSentAt", originalValue, value);
					EntityData.ConfirmationSentAt = value;
					OnPropertyChanged("ConfirmationSentAt", originalValue, value);
				}
			}
		}
		public virtual bool IsSuperAdmin 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.IsSuperAdmin; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.IsSuperAdmin == value) return;

					var originalValue = EntityData.IsSuperAdmin;
					OnPropertyChanging("IsSuperAdmin", originalValue, value);
					EntityData.IsSuperAdmin = value;
					OnPropertyChanged("IsSuperAdmin", originalValue, value);
				}
			}
		}
		public virtual bool IsApproved 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.IsApproved; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.IsApproved == value) return;

					var originalValue = EntityData.IsApproved;
					OnPropertyChanging("IsApproved", originalValue, value);
					EntityData.IsApproved = value;
					OnPropertyChanged("IsApproved", originalValue, value);
				}
			}
		}
		public virtual Guid ApprovedById 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.ApprovedById; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.ApprovedById == value) return;

					var originalValue = EntityData.ApprovedById;
					OnPropertyChanging("ApprovedById", originalValue, value);
					EntityData.ApprovedById = value;
					OnPropertyChanged("ApprovedById", originalValue, value);
				}
			}
		}
		public virtual DateTime? ApprovedAt 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.ApprovedAt; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.ApprovedAt == value) return;

					var originalValue = EntityData.ApprovedAt;
					OnPropertyChanging("ApprovedAt", originalValue, value);
					EntityData.ApprovedAt = value;
					OnPropertyChanged("ApprovedAt", originalValue, value);
				}
			}
		}
		#endregion IUserData Properties
	}
		public partial class Role : BaseEntity<IRole, IRoleData, IRoleRepository>, IRole
		{
			public Role(
				Func<IRoleRepository> entityRepositoryFactory,
				Func<IRoleData> entityDataFactory,
				Func<IConcurrencyManager<IRole, IRoleData, IRoleRepository>> entityConcurrencyManagerFactory,
				IEnumerable<IEntityValidator<IRole, IRoleData, IRoleRepository>> entityValidators,
	            Func<IPermissionAuthorizationManager<IRole, IRoleData, IRoleRepository>> permissionAuthorizationManagerFactory)
				: base(entityRepositoryFactory, entityDataFactory, entityConcurrencyManagerFactory, entityValidators, permissionAuthorizationManagerFactory)
			{
			}

			#region IRoleData Properties
			public virtual string Name 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.Name; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.Name == value) return;

					var originalValue = EntityData.Name;
					OnPropertyChanging("Name", originalValue, value);
					EntityData.Name = value;
					OnPropertyChanged("Name", originalValue, value);
				}
			}
		}
		public virtual uint Permissions 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.Permissions; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.Permissions == value) return;

					var originalValue = EntityData.Permissions;
					OnPropertyChanging("Permissions", originalValue, value);
					EntityData.Permissions = value;
					OnPropertyChanged("Permissions", originalValue, value);
				}
			}
		}
		#endregion IRoleData Properties
	}
		public partial class OAuthMembership : BaseEntity<IOAuthMembership, IOAuthMembershipData, IOAuthMembershipRepository>, IOAuthMembership
		{
			public OAuthMembership(
				Func<IOAuthMembershipRepository> entityRepositoryFactory,
				Func<IOAuthMembershipData> entityDataFactory,
				Func<IConcurrencyManager<IOAuthMembership, IOAuthMembershipData, IOAuthMembershipRepository>> entityConcurrencyManagerFactory,
				IEnumerable<IEntityValidator<IOAuthMembership, IOAuthMembershipData, IOAuthMembershipRepository>> entityValidators,
	            Func<IPermissionAuthorizationManager<IOAuthMembership, IOAuthMembershipData, IOAuthMembershipRepository>> permissionAuthorizationManagerFactory)
				: base(entityRepositoryFactory, entityDataFactory, entityConcurrencyManagerFactory, entityValidators, permissionAuthorizationManagerFactory)
			{
			}

			#region IOAuthMembershipData Properties
			public virtual string ProviderName 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.ProviderName; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.ProviderName == value) return;

					var originalValue = EntityData.ProviderName;
					OnPropertyChanging("ProviderName", originalValue, value);
					EntityData.ProviderName = value;
					OnPropertyChanged("ProviderName", originalValue, value);
				}
			}
		}
		public virtual string ProviderUserId 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.ProviderUserId; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.ProviderUserId == value) return;

					var originalValue = EntityData.ProviderUserId;
					OnPropertyChanging("ProviderUserId", originalValue, value);
					EntityData.ProviderUserId = value;
					OnPropertyChanged("ProviderUserId", originalValue, value);
				}
			}
		}
		public virtual Guid UserId 
		{
			get 
			{
				using(Logger.Assembly.Scope())
				{ 
					return EntityData.UserId; 
				}
			}
			set
			{
				using(Logger.Assembly.Scope())
				{ 
					if (EntityData.UserId == value) return;

					var originalValue = EntityData.UserId;
					OnPropertyChanging("UserId", originalValue, value);
					EntityData.UserId = value;
					OnPropertyChanged("UserId", originalValue, value);
				}
			}
		}
		#endregion IOAuthMembershipData Properties
	}
	#endregion Entity Implementations

	#region Entity Repository Implementations
		public partial class UserRepository : EntityRepository<IUser, IUserData, UserData, IUserRepository, IUserRepositoryService>, IUserRepository
		{
			public UserRepository(
				Func<IUser> entityFactory,
				Func<IUserData> entityDataFactory,
				Func<IUserRepositoryService> entityRepositoryServiceFactory,
				IEnumerable<IEntityObserver<IUser>> entityObservers,
				Func<IEntityCache<IUser, IUserData, IUserRepository>> entityCacheFactory,
				Func<IScopeManager> scopeManagerFactory)
				: base(entityFactory, entityDataFactory, entityRepositoryServiceFactory, entityObservers, entityCacheFactory, scopeManagerFactory)
			{
			}
		}
			public partial class RoleRepository : EntityRepository<IRole, IRoleData, RoleData, IRoleRepository, IRoleRepositoryService>, IRoleRepository
		{
			public RoleRepository(
				Func<IRole> entityFactory,
				Func<IRoleData> entityDataFactory,
				Func<IRoleRepositoryService> entityRepositoryServiceFactory,
				IEnumerable<IEntityObserver<IRole>> entityObservers,
				Func<IEntityCache<IRole, IRoleData, IRoleRepository>> entityCacheFactory,
				Func<IScopeManager> scopeManagerFactory)
				: base(entityFactory, entityDataFactory, entityRepositoryServiceFactory, entityObservers, entityCacheFactory, scopeManagerFactory)
			{
			}
		}
			public partial class OAuthMembershipRepository : EntityRepository<IOAuthMembership, IOAuthMembershipData, OAuthMembershipData, IOAuthMembershipRepository, IOAuthMembershipRepositoryService>, IOAuthMembershipRepository
		{
			public OAuthMembershipRepository(
				Func<IOAuthMembership> entityFactory,
				Func<IOAuthMembershipData> entityDataFactory,
				Func<IOAuthMembershipRepositoryService> entityRepositoryServiceFactory,
				IEnumerable<IEntityObserver<IOAuthMembership>> entityObservers,
				Func<IEntityCache<IOAuthMembership, IOAuthMembershipData, IOAuthMembershipRepository>> entityCacheFactory,
				Func<IScopeManager> scopeManagerFactory)
				: base(entityFactory, entityDataFactory, entityRepositoryServiceFactory, entityObservers, entityCacheFactory, scopeManagerFactory)
			{
			}
		}
		#endregion Entity Repository Implementations
}
