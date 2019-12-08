using Admin.DataAccess.Sql;
using Admin.Domain;
using Admin.Domain.Interfaces;
using Admin.Domain.Sms;
using Admin.UI.WpfApp.ViewModels;
using System.Windows;

namespace Admin.UI.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Composition Root
            ICreateUserService service = new CreateUserService(
                new Messenger(
                    new SqlMessageTemplateRepository(
                        new MessageTemplateContext()
                    ),
                    //new NullMessageTransmissionStrategy()
                    //new SendGridEmailTransmissionStrategy()
                    new TwilioSmsTransmissionStrategy()
                )
            );

            // UI Layer
            CreateUserViewModel vm = new CreateUserViewModel(service);

            this.MainWindow = new CreateUserWindow( vm );
            this.MainWindow.Show();
        }
    }
}
