using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTest1.Test1
{
    public class WorkingItem : ObservableObject
    {
        public string _id;
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

        public string _status;
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
    }
}
