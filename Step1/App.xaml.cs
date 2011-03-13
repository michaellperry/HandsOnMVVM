using System;
using System.Windows;
using Hands_On_MVVM.DataAccess;
using System.Windows.Controls;
using Step1.ViewModel;

namespace Hands_On_MVVM
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // http://madprops.org/blog/wpf-textbox-selectall-on-focus/
            EventManager.RegisterClassHandler(typeof(TextBox),
                TextBox.GotFocusEvent,
                new RoutedEventHandler(TextBox_GotFocus));
<<<<<<< HEAD

            DataSource dataSource = new DataSource();
            this.MainWindow = new PersonWindow();
            this.MainWindow.DataContext = new PersonViewModel(dataSource.GetPerson());
            this.MainWindow.Show();
=======
>>>>>>> a99901b09612b10e355b6a0a03717e1337a1b6ce
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }
    }
}
