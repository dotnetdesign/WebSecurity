using DotNetDesign.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDesign.WebSecurity
{
    public partial class UserRepository : IUserRepository
    {
        public IUser GetByEmail(string email)
        {
            using (Logger.Assembly.Scope())
            {
                var userData = EntityRepositoryServiceFactory().GetByEmail(email);
                return InitializeEntities(userData);
            }
        }

        public IUser GetByConfirmationToken(Guid confirmationToken)
        {
            using (Logger.Assembly.Scope())
            {
                var userData = EntityRepositoryServiceFactory().GetByConfirmationToken(confirmationToken);
                return InitializeEntities(userData);
            }
        }

        public bool TrySetPassword(IUser user, string currentPassword, string newPassword, string newPasswordConfirm)
        {
            using (Logger.Assembly.Scope())
            {
                var userData = user.EntityData as UserData;
                if (!ConfirmPassword(userData, currentPassword))
                {
                    return false;
                }

                var originalUserDataVersion = user.Version;

                // this will try to hash the new password and set accordingly on user.
                HashPassword(userData, newPassword, newPasswordConfirm);
                return user.Save();
            }
        }

        public bool ConfirmPassword(IUser user, string password)
        {
            using (Logger.Assembly.Scope())
            {
                return ConfirmPassword(user.EntityData as UserData, password);
            }
        }

        private bool ConfirmPassword(UserData userData, string password)
        {
            if (userData.PasswordHash == null || userData.PasswordHash.Length == 0) return true;
            return userData.PasswordHash.SequenceEqual(HashPasswordWithSalt(password, userData.PasswordSalt));
        }

        /// <summary>
        /// Hashes the password.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <param name="password">The password.</param>
        /// <param name="passwordConfirm">The password confirm.</param>
        private static void HashPassword(UserData userData, string password, string passwordConfirm)
        {
            // TODO: Enforce password policy
            // throw new ApplicationException("Password does not meet strength requirements or do not match so hash could not be generated");

            userData.PasswordSalt = GenerateSalt();
            userData.PasswordHash = HashPasswordWithSalt(password, userData.PasswordSalt);
        }


        /// <summary>
        /// Generates the salt.
        /// </summary>
        /// <returns></returns>
        private static byte[] GenerateSalt()
        {
            var saltBytes = new byte[64];
            var rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(saltBytes);
            return saltBytes;
        }

        /// <summary>
        /// Hashes the password with salt.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="salt">The salt.</param>
        /// <returns></returns>
        private static byte[] HashPasswordWithSalt(string password, byte[] salt)
        {
            var hashManager = new SHA512Managed();
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var passwordWithSaltBytes = passwordBytes.Concat(salt).ToArray();
            return hashManager.ComputeHash(passwordWithSaltBytes);
        }
    }
}
