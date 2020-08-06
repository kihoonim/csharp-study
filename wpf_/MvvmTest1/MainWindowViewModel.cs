using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MvvmTest1
{
    public class MainWindowViewModel : ObservableObject
    {
        IPageViewModel TotalViewModel { get; set; }
        IPageViewModel Test1ViewModel { get; set; }
        IPageViewModel Test2ViewModel { get; set; }
        public ICommand ChangePageCommand { get; set; }

        public MainWindowViewModel()
        {
            TotalViewModel = new Total.TotalViewModel();
            Test1ViewModel = new Test1.Test1ViewModel();
            Test2ViewModel = new Test2.Test2ViewModel();

            ChangePageCommand = new RelayCommand(ChangeViewModel);
        }

        private IPageViewModel _currentPageViewModel;
        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }

        private void ChangeViewModel(object page)
        {
            if (page.Equals("Total"))
                CurrentPageViewModel = TotalViewModel;
            else if (page.Equals("Test1"))
                CurrentPageViewModel = Test1ViewModel;
            else if (page.Equals("Test2"))
                CurrentPageViewModel = Test2ViewModel;
        }
    }
}
