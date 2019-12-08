using Admin.DataAccess.Sql;
using Admin.Domain;
using Admin.Domain.Email;
using Admin.Domain.Interfaces;
using Admin.Domain.Logging;
using Admin.Domain.Logging.Interfaces;
using Admin.UI.WpfApp.ViewModels;
using System;
using Unity;
using Unity.Injection;

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
                .RegisterType<ILoggerFactory,FileLoggerFactory>()
                .RegisterType<ICreateUserService, CreateUserService>()
                .RegisterType<IMessageTemplateRepository, SqlMessageTemplateRepository>()
                .RegisterType<MessageTemplateContext>()
                .RegisterType<SendGridEmailTransmissionStrategy>()
                .RegisterType<IMessageTransmissionStrategy,RedirectionMessageTransmissionStrategyProxy>(
                    new InjectionConstructor(
                        new ResolvedParameter<SendGridEmailTransmissionStrategy>(),
                        new ResolvedParameter<RedirectionConfiguration>()
                    )
                )
                .RegisterInstance( new RedirectionConfiguration(
                    email: "jgh@wincubate.net",
                    phone: "+4522123631"
                    )                
                )
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
