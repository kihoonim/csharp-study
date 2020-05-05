using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmTest1.Test2.Api1
{
    public class Api1ViewModel : ObservableObject, IPageViewModel
    {
        public ICommand AddCommand { get; set; }

        public Api1ViewModel()
        {
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

        private void Add(object value)
        {
            //_workingItems.Add(new WorkingItem { Id = Id, Status = Status });
        }
    }
}
