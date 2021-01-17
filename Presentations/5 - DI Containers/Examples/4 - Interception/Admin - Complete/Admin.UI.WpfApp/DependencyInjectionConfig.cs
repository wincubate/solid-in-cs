using Admin.DataAccess.Sql;
using Admin.Domain;
using Admin.Domain.Email;
using Admin.Domain.Interfaces;
using Admin.Domain.Sms;
using Admin.UI.WpfApp.ViewModels;
using System;
using Unity;
using Unity.Injection;

namespace Admin.UI.WpfApp
{
    internal class DependencyInjectionConfig : IDisposable
    {
        private IUnityContainer _container;

        public DependencyInjectionConfig()
        {
            _container = new UnityContainer();
        }

        public void Register()
        {
            _container
                .RegisterType<ICreateUserService, CreateUserService>()
                .RegisterType<Messenger>()
                .RegisterType<IMessageTemplateRepository, SqlMessageTemplateRepository>()
                .RegisterType<MessageTemplateContext>()
                .RegisterType<IMessageTransmissionStrategy, CompositeMessageTransmissionStrategy>(
                    new InjectionConstructor(
                        new ResolvedArrayParameter<IMessageTransmissionStrategy>(
                            new ResolvedParameter<TwilioSmsTransmissionStrategy>(),
                            new ResolvedParameter<SendGridEmailTransmissionStrategy>()
                        )
                    )
                )
                .RegisterType<CreateUserViewModel>()
                .RegisterType<CreateUserWindow>()
                ;
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}
