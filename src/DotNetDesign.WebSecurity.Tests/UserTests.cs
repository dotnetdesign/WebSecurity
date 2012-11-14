using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Autofac;

namespace DotNetDesign.WebSecurity.Tests
{
    public class UserTests : BaseTestClass
    {
        public static IUserData ValidUserData = new UserData
                                                    {
                                                        FirstName = "John",
                                                        LastName = "Doe",
                                                        EmailAddress = "john.doe@example.com",
                                                        DisplayName = "John Doe"
                                                    };

        [Fact]
        public void NewUserShouldNotBeNull()
        {
            using (var lifetimeScope = Container.BeginLifetimeScope())
            {
                var userRepository = lifetimeScope.Resolve<IUserRepository>();
                var user = userRepository.GetNew();

                Assert.NotNull(user);
            }
        }

        [Fact]
        public void NewUserShouldHaveNewNonEmptyGuidAsId()
        {
            using (var lifetimeScope = Container.BeginLifetimeScope())
            {
                var userRepository = lifetimeScope.Resolve<IUserRepository>();
                var user = userRepository.GetNew();

                Assert.NotEqual(Guid.Empty, user.Id);
            }
        }

        [Fact]
        public void NewUnmodifiedUserShouldFailToSave()
        {
            using (var lifetimeScope = Container.BeginLifetimeScope())
            {
                var userRepository = lifetimeScope.Resolve<IUserRepository>();
                var user = userRepository.GetNew();

                // expect concurrency manager to get previous instance. return null
                UserRepositoryServiceMock
                    .Setup(x => x.GetById(user.Id, It.IsAny<Dictionary<string, string>>()))
                    .Returns<UserData>(null);

                Assert.False(user.Save());
                Assert.NotEqual(0, user.Validate().Count());
            }
        }

        [Fact]
        public void NewUserWithValidDataShouldCallSaveOnRepositoryService()
        {
            using (var lifetimeScope = Container.BeginLifetimeScope())
            {
                var userRepository = lifetimeScope.Resolve<IUserRepository>();
                var user = userRepository.GetNew();

                user.FirstName = ValidUserData.FirstName;
                user.LastName = ValidUserData.LastName;
                user.EmailAddress = ValidUserData.EmailAddress;
                user.DisplayName = ValidUserData.DisplayName;

                // expect concurrency manager to get previous instance. return null
                UserRepositoryServiceMock
                    .Setup(x => x.GetById(user.Id, It.IsAny<Dictionary<string, string>>()))
                    .Returns<UserData>(null);

                // expect a call to save on UserRepositoryService because user is valid.
                UserRepositoryServiceMock
                    .Setup(x => x.Save(user.EntityData as UserData, It.IsAny<Dictionary<string, string>>()))
                    .Returns(user.EntityData as UserData);

                Assert.Equal(0, user.Validate().Count());
                Assert.True(user.Save());

                UserRepositoryServiceMock.VerifyAll();
            }
        }

        [Fact]
        public void UserSetAndConfirmPasswordTests()
        {
            using (var lifetimeScope = Container.BeginLifetimeScope())
            {
                var currentPassword = "aBc#4F8jf";
                var newPassword = "aBcPPF8_f";
                var confirmPassword = "aBcPPF8_f";
                var badPassword = "aBcPPF8_ff";

                var userRepository = lifetimeScope.Resolve<IUserRepository>();
                var user = userRepository.GetNew();

                user.FirstName = ValidUserData.FirstName;
                user.LastName = ValidUserData.LastName;
                user.EmailAddress = ValidUserData.EmailAddress;
                user.DisplayName = ValidUserData.DisplayName;

                // expect concurrency manager to get previous instance. return null
                UserRepositoryServiceMock
                    .Setup(x => x.GetById(user.Id, It.IsAny<Dictionary<string, string>>()))
                    .Returns<UserData>(null);

                Assert.Equal(0, user.Validate().Count());

                // expect a call to save on UserRepositoryService because user is valid and TrySetPassword was called with valid params.
                UserRepositoryServiceMock
                    .Setup(x => x.Save(user.EntityData as UserData, It.IsAny<Dictionary<string, string>>()))
                    .Returns(user.EntityData as UserData);

                Assert.True(user.TrySetPassword(currentPassword, newPassword, confirmPassword));

                UserRepositoryServiceMock.VerifyAll();

                Assert.False(user.ConfirmPassword(currentPassword));
                Assert.False(user.ConfirmPassword(badPassword));
                Assert.True(user.ConfirmPassword(newPassword));
            }
        }
    }
}
