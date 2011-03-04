using System.Windows;
using Hands_On_MVVM.DataAccess;
using Hands_On_MVVM.ViewModel;

namespace Hands_On_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PersonWindow : Window
    {
        public PersonWindow()
        {
            InitializeComponent();
        }

        private void PersonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataSource dataSource = new DataSource();
            DataContext = new PersonViewModel(dataSource.GetPerson());
        }
    }
}
