using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDesign.WebSecurity
{
    public partial interface IUserRepositoryService
    {
        /// <summary>
        /// Gets the UserData by email address.
        /// </summary>
        /// <param name="email">The email address.</param>
        /// <returns>UserData associated with the email address. Null if there is no match.</returns>
        UserData GetByEmail(string email);

        /// <summary>
        /// Gets the UserData by confirmation token.
        /// </summary>
        /// <param name="confirmationToken">The confirmation token.</param>
        /// <returns>UserData associated with the confirmation token. Null if there is no match.</returns>
        UserData GetByConfirmationToken(Guid confirmationToken);

        /// <summary>
        /// Tries to set the UserData password.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <param name="currentPassword">The current password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <param name="newPasswordConfirm">The new password confirm.</param>
        /// <returns></returns>
        UserData TrySetPassword(UserData userData, string currentPassword, string newPassword, string newPasswordConfirm);

        /// <summary>
        /// Confirms the UserData password.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <param name="password">The password.</param>
        /// <returns>Whether or not the password matches the stored UserData password.</returns>
        bool ConfirmPassword(UserData userData, string password);
    }
}
