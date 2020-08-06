using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTest1.Test2
{
    class Grid2 : ObservableObject
    {
        public string _id;
        public string Id2
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
        public string Status2
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
