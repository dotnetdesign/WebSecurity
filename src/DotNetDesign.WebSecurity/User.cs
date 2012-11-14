using DotNetDesign.Common;
using DotNetDesign.Substrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDesign.WebSecurity
{
    public partial class User
    {
        #region Private Members
        private readonly Func<IRoleRepository> _roleRepositoryFactory;
        private readonly Func<IOAuthMembershipRepository> _oauthMembershipRepositoryFactory;
        #endregion

        public User(
            Func<IUserRepository> entityRepositoryFactory,
            Func<IUserData> entityDataFactory,
            Func<IConcurrencyManager<IUser, IUserData, IUserRepository>> entityConcurrencyManagerFactory,
            IEnumerable<IEntityValidator<IUser, IUserData, IUserRepository>> entityValidators,
            Func<IPermissionAuthorizationManager<IUser, IUserData, IUserRepository>> permissionAuthorizationManagerFactory,
            Func<IRoleRepository> roleRepositoryFactory,
            Func<IOAuthMembershipRepository> oauthMembershipRepositoryFactory)
            : base(entityRepositoryFactory, entityDataFactory, entityConcurrencyManagerFactory, entityValidators, permissionAuthorizationManagerFactory)
        {
            using (Logger.Assembly.Scope())
            {
                _roleRepositoryFactory = roleRepositoryFactory;
                _oauthMembershipRepositoryFactory = oauthMembershipRepositoryFactory;
            }
        }

        #region Implementation of IUser

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IRole> GetRoles()
        {
            using (Logger.Assembly.Scope())
            {
                return _roleRepositoryFactory().GetByIds(RoleIds);
            }
        }

        /// <summary>
        /// Adds the role.
        /// </summary>
        /// <param name="role">The role.</param>
        public void AddRole(IRole role)
        {
            using (Logger.Assembly.Scope())
            {
                RoleIds.Add(role.Id);
            }
        }

        /// <summary>
        /// Removes the role.
        /// </summary>
        /// <param name="role">The role.</param>
        public void RemoveRole(IRole role)
        {
            using (Logger.Assembly.Scope())
            {
                RoleIds.Remove(role.Id);
            }
        }

        /// <summary>
        /// Gets the OAuth memberships.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IOAuthMembership> GetOAuthMemberships()
        {
            using (Logger.Assembly.Scope())
            {
                return _oauthMembershipRepositoryFactory().GetByIds(RoleIds);
            }
        }

        /// <summary>
        /// Adds the OAuth membership.
        /// </summary>
        /// <param name="oauthMembership">The OAuth membership.</param>
        public void AddOAuthMembership(IOAuthMembership oauthMembership)
        {
            using (Logger.Assembly.Scope())
            {
                OAuthMembershipIds.Add(oauthMembership.Id);
            }
        }

        /// <summary>
        /// Removes the OAuth membership.
        /// </summary>
        /// <param name="oauthMembership">The OAuth membership.</param>
        public void RemoveOAuthMembership(IOAuthMembership oauthMembership)
        {
            using (Logger.Assembly.Scope())
            {
                OAuthMembershipIds.Remove(oauthMembership.Id);
            }
        }

        /// <summary>
        /// Tries to set the user's password.
        /// </summary>
        /// <param name="currentPassword">The current password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <param name="newPasswordConfirm">The new password confirm.</param>
        /// <returns></returns>
        public bool TrySetPassword(string currentPassword, string newPassword, string newPasswordConfirm)
        {
            using (Logger.Assembly.Scope())
            {
                return EntityRepositoryFactory().TrySetPassword(this, currentPassword, newPassword, newPasswordConfirm);
            }
        }

        /// <summary>
        /// Confirms the user's password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool ConfirmPassword(string password)
        {
            using (Logger.Assembly.Scope())
            {
                return EntityRepositoryFactory().ConfirmPassword(this as IUser, password);
            }
        }

        #endregion
    }
}
