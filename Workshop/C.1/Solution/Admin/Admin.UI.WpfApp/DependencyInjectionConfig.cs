using Admin.DataAccess.Sql;
using Admin.Domain;
using Admin.Domain.Email;
using Admin.Domain.Interfaces;
using Admin.UI.WpfApp.ViewModels;
using System;
using Unity;

namespace Admin.UI.WpfApp
{
    internal class DependencyInjectionConfig : IDisposable
    {
        private readonly IUnityContainer _container;

        public DependencyInjectionConfig()
        {
            _container = new UnityContainer();
        }

        public void Register()
        {
            _container
                .RegisterType<ICreateUserService, CreateUserService>()
                .RegisterType<IMessageTemplateRepository, SqlMessageTemplateRepository>()
                .RegisterType<MessageTemplateContext>()
                .RegisterType<IMessageTransmissionStrategy, SendGridEmailTransmissionStrategy>()
                .RegisterType<CreateUserViewModel>()
                ;
        }

        public T Resolve<T>() => _container.Resolve<T>();

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}
