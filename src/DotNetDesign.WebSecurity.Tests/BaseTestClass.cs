using Autofac;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDesign.WebSecurity.Tests
{
    public class BaseTestClass : IDisposable
    {
        protected Mock<IUserRepositoryService> UserRepositoryServiceMock;
        protected Mock<IRoleRepositoryService> RoleRepositoryServiceMock;
        protected Mock<IOAuthMembershipRepositoryService> OAuthMembershipRepositoryServiceMock;
        protected IContainer Container;

        public BaseTestClass()
        {
            var container = new ContainerBuilder();
            container.RegisterModule(new TestModule());

            UserRepositoryServiceMock = new Mock<IUserRepositoryService>();
            RoleRepositoryServiceMock = new Mock<IRoleRepositoryService>();
            OAuthMembershipRepositoryServiceMock = new Mock<IOAuthMembershipRepositoryService>();

            container.RegisterInstance(UserRepositoryServiceMock.Object).As<IUserRepositoryService>();
            container.RegisterInstance(RoleRepositoryServiceMock.Object).As<IRoleRepositoryService>();
            container.RegisterInstance(OAuthMembershipRepositoryServiceMock.Object).As<IOAuthMembershipRepositoryService>();

            Container = container.Build();
        }

        public void Dispose()
        {
            Container.Dispose();
        }
    }
}
