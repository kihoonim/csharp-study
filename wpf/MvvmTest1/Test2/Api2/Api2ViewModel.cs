using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmTest1.Test2.Api2
{
    public class Api2ViewModel : ObservableObject, IPageViewModel
    {
        public RelayCommand ApplyCommand { get; set; }

        public Api2ViewModel()
        {
            ApplyCommand = new RelayCommand(Apply);

        }

        public string Name
        {
            get { return "Api2"; }
        }

        private string _option1;
        public string Option1
        {
            get { return _option1; }
            set
            {
                if (value != _option1)
                {
                    _option1 = value;
                    OnPropertyChanged("Option1");
                }
            }
        }

        private string _option2;
        public string Option2
        {
            get { return _option2; }
            set
            {
                if (value != _option2)
                {
                    _option2 = value;
                    OnPropertyChanged("Option1");
                }
            }
        }

        private void Apply(object value)
        {
            MessageBox.Show($"{Option1} {Option2}");
        }
    }
}
