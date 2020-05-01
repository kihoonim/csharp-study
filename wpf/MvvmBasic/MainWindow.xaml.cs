using System.Windows;

namespace MvvmBasic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StudentViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            MvvmBasic.ViewModel.StudentViewModel studentViewModelObject =
                new MvvmBasic.ViewModel.StudentViewModel();
            studentViewModelObject.LoadStudents();

            StudentViewControl.DataContext = studentViewModelObject;
        }
    }
}
