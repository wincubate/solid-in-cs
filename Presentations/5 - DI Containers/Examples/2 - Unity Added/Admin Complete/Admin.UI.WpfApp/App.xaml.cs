using Admin.DataAccess.Sql;
using Admin.Domain;
using Admin.Domain.Email;
using Admin.Domain.Interfaces;
using Admin.Domain.Sms;
using Admin.UI.WpfApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace Admin.UI.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IUnityContainer _container;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Composition Root
            _container = new UnityContainer();
            _container
                .RegisterType<ICreateUserService, CreateUserService>()
                .RegisterType<Messenger>()
                .RegisterType<IMessageTemplateRepository,SqlMessageTemplateRepository>()
                .RegisterType<MessageTemplateContext>()
                .RegisterType<IMessageTransmissionStrategy,SendGridEmailTransmissionStrategy>()
                .RegisterType<CreateUserViewModel>()
                ;

            //ICreateUserService service = new CreateUserService(
            //    new Messenger(
            //        new SqlMessageTemplateRepository(
            //            new MessageTemplateContext()
            //        ),
            //        //new NullMessageTransmissionStrategy()
            //        //new SendGridEmailTransmissionStrategy()
            //        new TwilioSmsTransmissionStrategy()
            //    )
            //);
            //// UI Layer
            //CreateUserViewModel vm = new CreateUserViewModel(service);

            this.MainWindow = _container.Resolve<CreateUserWindow>();
            this.MainWindow.Show();
        }
    }
}
