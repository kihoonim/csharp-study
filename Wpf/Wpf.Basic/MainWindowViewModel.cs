using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Wpf.Mvvm;
using Wpf.Mvvm.Interface;

namespace Wpf.Basic
{
    class MainWindowViewModel : ObservableObject
    {
        #region Data
        IPageViewModel DataGridViewModel { get; set; }

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
        #endregion

        #region Command
        public ICommand ChangePageCommand { get; set; }
        #endregion

        public MainWindowViewModel()
        {
            DataGridViewModel = new View.DataGridViewModel();
            ChangePageCommand = new RelayCommand(ChangeViewModel);
        }

        private void _ChangeViewModel(string page)
        {
            switch (page.ToUpper())
            {
                case "DATAGRID":
                    CurrentPageViewModel = DataGridViewModel;
                    break;
                default:
                    break;
            }
        }

        public void ChangeViewModel(object parameter)
        {
            var page = parameter.ToString();

            _ChangeViewModel(page);
        }
    }
}
