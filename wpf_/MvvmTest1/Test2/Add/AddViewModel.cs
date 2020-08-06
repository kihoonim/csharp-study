using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace MvvmTest1.Test2.Add
{
    class AddViewModel : ObservableObject, IPageViewModel
    {
        Add View { get; set; }
        public ICommand AddCommand { get; set; }

        public AddViewModel(Add view)
        {
            View = view;
            Indeterminate = false;

            AddCommand = new RelayCommand(Add);
        }

        private string _id;
        public string Id
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                if (value != _status)
                {
                    _status = value;
                    OnPropertyChanged("Status");
                }
            }
        }

        private bool _indeterminate;
        public bool Indeterminate
        {
            get { return _indeterminate; }
            set
            {
                if (value != _indeterminate)
                {
                    _indeterminate = value;
                    OnPropertyChanged("Indeterminate");
                }
            }
        }
        private async Task DoWorkAsync()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
            });
        }

        private async void Add(object value)
        {
            Indeterminate = true;

            await DoWorkAsync();

            Indeterminate = false;

            MessageBox.Show("OK");

            //_workingItems.Add(new WorkingItem { Id = Id, Status = Status });

            View.Close();
        }
    }
}

