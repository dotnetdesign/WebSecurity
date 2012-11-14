using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetDesign.Substrate;

namespace DotNetDesign.WebSecurity.Tests
{
    public class TestModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserData>().As<IUserData>();
            builder.RegisterType<User>().As<IUser>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<ConcurrencyManager<IUser, IUserData, IUserRepository>>()
                .As<IConcurrencyManager<IUser, IUserData, IUserRepository>>();
            builder.RegisterType<DictionaryEntityCache<IUser, IUserData, IUserRepository>>()
                .As<IEntityCache<IUser, IUserData, IUserRepository>>().InstancePerLifetimeScope();
            builder.RegisterType<DataAnnotationEntityValidator<IUser, IUserData, IUserRepository>>()
                .As<IEntityValidator<IUser, IUserData, IUserRepository>>().InstancePerLifetimeScope();
            builder.RegisterType<AnonymousPermissionAuthorizationManager<IUser, IUserData, IUserRepository>>()
                .As<IPermissionAuthorizationManager<IUser, IUserData, IUserRepository>>().InstancePerLifetimeScope();

            builder.RegisterType<OAuthMembershipData>().As<IOAuthMembershipData>();
            builder.RegisterType<OAuthMembership>().As<IOAuthMembership>();
            builder.RegisterType<OAuthMembershipRepository>().As<IOAuthMembershipRepository>();
            builder.RegisterType<ConcurrencyManager<IOAuthMembership, IOAuthMembershipData, IOAuthMembershipRepository>>()
                .As<IConcurrencyManager<IOAuthMembership, IOAuthMembershipData, IOAuthMembershipRepository>>();
            builder.RegisterType<DictionaryEntityCache<IOAuthMembership, IOAuthMembershipData, IOAuthMembershipRepository>>()
                .As<IEntityCache<IOAuthMembership, IOAuthMembershipData, IOAuthMembershipRepository>>().InstancePerLifetimeScope();
            builder.RegisterType<DataAnnotationEntityValidator<IOAuthMembership, IOAuthMembershipData, IOAuthMembershipRepository>>()
                .As<IEntityValidator<IOAuthMembership, IOAuthMembershipData, IOAuthMembershipRepository>>().InstancePerLifetimeScope();
            builder.RegisterType<AnonymousPermissionAuthorizationManager<IOAuthMembership, IOAuthMembershipData, IOAuthMembershipRepository>>()
                .As<IPermissionAuthorizationManager<IOAuthMembership, IOAuthMembershipData, IOAuthMembershipRepository>>().InstancePerLifetimeScope();

            builder.RegisterType<RoleData>().As<IRoleData>();
            builder.RegisterType<Role>().As<IRole>();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            builder.RegisterType<ConcurrencyManager<IRole, IRoleData, IRoleRepository>>()
                .As<IConcurrencyManager<IRole, IRoleData, IRoleRepository>>();
            builder.RegisterType<DictionaryEntityCache<IRole, IRoleData, IRoleRepository>>()
                .As<IEntityCache<IRole, IRoleData, IRoleRepository>>().InstancePerLifetimeScope();
            builder.RegisterType<DataAnnotationEntityValidator<IRole, IRoleData, IRoleRepository>>()
                .As<IEntityValidator<IRole, IRoleData, IRoleRepository>>().InstancePerLifetimeScope();
            builder.RegisterType<AnonymousPermissionAuthorizationManager<IRole, IRoleData, IRoleRepository>>()
                .As<IPermissionAuthorizationManager<IRole, IRoleData, IRoleRepository>>().InstancePerLifetimeScope();

            builder.RegisterType<DictionaryScopeManager>().As<IScopeManager>();
        }
    }
}
