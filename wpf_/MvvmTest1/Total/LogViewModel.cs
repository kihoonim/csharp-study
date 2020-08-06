using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTest1.Total
{
    public class LogViewModel : ObservableObject, IPageViewModel
    {
        public LogViewModel() { }

        public string Name
        {
            get { return "Log"; }
        }

        string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    RaisePropertyChanged("Message");
                }
            }
        }
    }
}
