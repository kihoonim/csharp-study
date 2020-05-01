using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTest1.Total
{
    public class ContainerInfo : ObservableObject
    {
        public string _nodeName;
        public string NodeName
        {
            get { return _nodeName; }
            set
            {
                if (value != _nodeName)
                {
                    _nodeName = value;
                    OnPropertyChanged("NodeName");
                }
            }
        }

        public string _ip;
        public string Ip
        {
            get { return _ip; }
            set
            {
                if (value != _ip)
                {
                    _ip = value;
                    OnPropertyChanged("Ip");
                }
            }
        }

        public string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
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
    }
}
