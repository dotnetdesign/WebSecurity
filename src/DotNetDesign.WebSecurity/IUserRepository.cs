using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDesign.WebSecurity
{
    public partial interface IUserRepository
    {
        /// <summary>
        /// Gets the user by email address.
        /// </summary>
        /// <param name="email">The email address.</param>
        /// <returns>User associated with the email address. Will return null if there are no matches.</returns>
        IUser GetByEmail(string email);

        /// <summary>
        /// Gets the user by confirmation token.
        /// </summary>
        /// <param name="confirmationToken">The confirmation token.</param>
        /// <returns>User associated with the confirmation token. Will return null if there are no matches.</returns>
        IUser GetByConfirmationToken(Guid confirmationToken);

        /// <summary>
        /// Tries to set the user's password.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="currentPassword">The current password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <param name="newPasswordConfirm">The new password confirmation.</param>
        /// <returns></returns>
        bool TrySetPassword(IUser user, string currentPassword, string newPassword, string newPasswordConfirm);

        /// <summary>
        /// Confirms the password.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        bool ConfirmPassword(IUser user, string password);
    }
}
