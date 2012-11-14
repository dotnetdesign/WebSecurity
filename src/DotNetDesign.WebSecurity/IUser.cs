using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDesign.WebSecurity
{
    public partial interface IUser
    {
        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IRole> GetRoles();

        /// <summary>
        /// Adds the role.
        /// </summary>
        /// <param name="role">The role.</param>
        void AddRole(IRole role);

        /// <summary>
        /// Removes the role.
        /// </summary>
        /// <param name="role">The role.</param>
        void RemoveRole(IRole role);

        /// <summary>
        /// Gets the OAuth memberships.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IOAuthMembership> GetOAuthMemberships();

        /// <summary>
        /// Adds the OAuth membership.
        /// </summary>
        /// <param name="oauthMembership">The OAuth membership.</param>
        void AddOAuthMembership(IOAuthMembership oauthMembership);

        /// <summary>
        /// Removes the OAuth membership.
        /// </summary>
        /// <param name="oauthMembership">The OAuth membership.</param>
        void RemoveOAuthMembership(IOAuthMembership oauthMembership);

        /// <summary>
        /// Tries to set the user's password.
        /// </summary>
        /// <param name="currentPassword">The current password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <param name="newPasswordConfirm">The new password confirm.</param>
        /// <returns>Whether or not setting the user's password succeeded.</returns>
        bool TrySetPassword(string currentPassword, string newPassword, string newPasswordConfirm);

        /// <summary>
        /// Confirms the user's password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>Whether or not the password matches the user's stored password.</returns>
        bool ConfirmPassword(string password);
    }
}
