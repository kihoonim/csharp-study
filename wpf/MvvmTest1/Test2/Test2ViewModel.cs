using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmTest1.Test2
{
    class Test2ViewModel : ObservableObject, IPageViewModel
    {
        public ObservableCollection<string> Apis { get; set; }
        public ObservableCollection<Grid1> Grid1s { get; set; }
        public ObservableCollection<Grid2> Grid2s { get; set; }
        public ICommand AddCommand { get; set; }

        public Test2ViewModel()
        {
            Apis = new ObservableCollection<string>
            {
                "API1", "API2", "API3"
            };

            Grid1s = new ObservableCollection<Grid1>();
            Grid2s = new ObservableCollection<Grid2>();
            AddCommand = new RelayCommand(Add);
        }

        string _selectedApi;
        public string SelectedApi
        {
            get
            {
                return _selectedApi;
            }
            set
            {
                if (_selectedApi != value)
                {
                    _selectedApi = value;
                    RaisePropertyChanged("SelectedApi");
                }

                Apply(_selectedApi);
            }
        }

        public string Name
        {
            get { return "Test2"; }
        }


        private IPageViewModel _test2CurrentPageViewModel;
        public IPageViewModel Test2CurrentPageViewModel
        {
            get
            {
                return _test2CurrentPageViewModel;
            }
            set
            {
                if (_test2CurrentPageViewModel != value)
                {
                    _test2CurrentPageViewModel = value;
                    OnPropertyChanged("Test2CurrentPageViewModel");
                }
            }
        }

        private void Apply(string api)
        {
            if (api.Equals("API1"))
                Test2CurrentPageViewModel = new Api1.Api1ViewModel();
            else if (api.Equals("API2"))
                Test2CurrentPageViewModel = new Api2.Api2ViewModel();
            else
                throw new Exception();
        }

        private void Add(object parameter)
        {
            var win = new Add.Add();
            var addViewModel = new Add.AddViewModel(win);
            win.DataContext = addViewModel;
            win.Show();
        }
    }
}
