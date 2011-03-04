using System.Windows;
using Hands_On_MVVM.DataAccess;
using Hands_On_MVVM.ViewModel;

namespace Hands_On_MVVM
{
    /// <summary>
    /// Interaction logic for ContactsWindow.xaml
    /// </summary>
    public partial class ContactsWindow : Window
    {
        public ContactsWindow()
        {
            InitializeComponent();
        }

        private void ContactsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataSource dataSource = new DataSource();
            DataContext = new ContactsViewModel(dataSource.LoadContacts());
        }
    }
}
