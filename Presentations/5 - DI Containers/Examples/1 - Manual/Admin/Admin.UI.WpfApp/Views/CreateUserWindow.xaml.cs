using Admin.UI.WpfApp.ViewModels;
using System.Windows;

namespace Admin.UI.WpfApp
{
    /// <summary>
    /// Interaction logic for CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        public CreateUserWindow( CreateUserViewModel vm )
        {
            InitializeComponent();

            DataContext = vm;
        }
    }
}
