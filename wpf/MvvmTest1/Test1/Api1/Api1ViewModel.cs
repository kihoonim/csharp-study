using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmTest1.Test1.Api1
{
    public class Api1ViewModel : ObservableObject, IPageViewModel
    {
        public RelayCommand AddCommand { get; set; }
        ObservableCollection<WorkingItem> _workingItems;

        public Api1ViewModel(ObservableCollection<WorkingItem> workingItems)
        {
            AddCommand = new RelayCommand(Add);

            _workingItems = workingItems;
        }

        public string Name
        {
            get { return "Api1"; }
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

        private void Add(object value)
        {
            _workingItems.Add(new WorkingItem { Id = Id, Status = Status });
        }
    }
}
