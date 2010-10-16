using System;
using System.Windows;
using Step4.DataAccess;
using System.Windows.Controls;
using Step4.Model;
using Step4.ViewModel;

namespace Step4
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
            Person person = dataSource.GetPerson();
            this.MainWindow = new PersonWindow();
            this.MainWindow.DataContext = new PersonViewModel(person);
            this.MainWindow.Show();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }
    }
}
