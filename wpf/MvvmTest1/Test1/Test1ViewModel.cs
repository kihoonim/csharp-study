using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmTest1.Test1
{
    class Test1ViewModel : ObservableObject, IPageViewModel
    {
        public ObservableCollection<string> Apis { get; set; }
        public ObservableCollection<WorkingItem> WorkingItems { get; set; }

        public RelayCommand CheckConnectionCommand { get; set; }
       
        public Test1ViewModel()
        {
            Apis = new ObservableCollection<string>
            {
                "API1", "API2", "API3"
            };

            WorkingItems = new ObservableCollection<WorkingItem>();

            CheckConnectionCommand = new RelayCommand(CheckConnection);
            Api1CurrentPageViewModel = new Api1.Api1ViewModel(WorkingItems);

            Port = 10;
        }

        string _ip;
        public string Ip
        {
            get
            {
                return _ip;
            }
            set
            {
                if (_ip != value)
                {
                    _ip = value;
                    RaisePropertyChanged("Ip");
                }
            }
        }

        int _port;
        public int Port
        {
            get
            {
                return _port;
            }
            set
            {
                if (_port != value)
                {
                    _port = value;
                    RaisePropertyChanged("Port");
                }
            }
        }

        private WorkingItem _selectedItem;
        public WorkingItem SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    RaisePropertyChanged("SelectedItem");
                }
            }
        }

        public string Name
        {
            get { return "Test1"; }
        }


        private IPageViewModel _api1CurrentPageViewModel;
        public IPageViewModel Api1CurrentPageViewModel
        {
            get
            {
                return _api1CurrentPageViewModel;
            }
            set
            {
                if (_api1CurrentPageViewModel != value)
                {
                    _api1CurrentPageViewModel = value;
                    OnPropertyChanged("Api1CurrentPageViewModel");
                }
            }
        }

        private void CheckConnection(object parameter)
        {
            MessageBox.Show($"{Ip}:{Port}");
        }
    }
}
