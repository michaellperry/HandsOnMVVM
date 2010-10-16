using System;
using System.Windows;
using Step5.DataAccess;
using System.Windows.Controls;
using Step5.Model;
using Step5.ViewModel;

namespace Step5
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // http://madprops.org/blog/wpf-textbox-selectall-on-focus/
            EventManager.RegisterClassHandler(typeof(TextBox),
                TextBox.GotFocusEvent,
                new RoutedEventHandler(TextBox_GotFocus));

            DataSource dataSource = new DataSource();
            ContactList contacts = dataSource.LoadContacts();
            this.MainWindow = new ContactsWindow();
            this.MainWindow.DataContext = new ContactsViewModel(contacts);
            this.MainWindow.Show();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }
    }
}
