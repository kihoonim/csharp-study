using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MvvmTest1.Test2.Api2
{
    public class Api2ViewModel : ObservableObject, IPageViewModel
    {
        public ICommand ApplyCommand { get; set; }

        public Api2ViewModel()
        {
            ApplyCommand = new RelayCommand(Apply);

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

        private int _inputWidth;
        public int InputWidth
        {
            get { return _inputWidth; }
            set
            {
                if (value != _inputWidth)
                {
                    _inputWidth = value;
                    OnPropertyChanged("InputWidth");
                }
            }
        }

        private int _inputHeight;
        public int InputHeight
        {
            get { return _inputHeight; }
            set
            {
                if (value != _inputHeight)
                {
                    _inputHeight = value;
                    OnPropertyChanged("InputHeight");
                }
            }
        }

        private BitmapSource _input;
        public BitmapSource Input
        {
            get { return _input; }
            set
            {
                if (value != _input)
                {
                    _input = value;
                    OnPropertyChanged("Input");
                }
            }
        }

        private int _outputWidth;
        public int OutputWidth
        {
            get { return _outputWidth; }
            set
            {
                if (value != _outputWidth)
                {
                    _outputWidth = value;
                    OnPropertyChanged("OutputWidth");
                }
            }
        }

        private int _outputHeight;
        public int OutputHeight
        {
            get { return _outputHeight; }
            set
            {
                if (value != _outputHeight)
                {
                    _outputHeight = value;
                    OnPropertyChanged("OutputHeight");
                }
            }
        }

        private BitmapSource _output;
        public BitmapSource Output
        {
            get { return _output; }
            set
            {
                if (value != _output)
                {
                    _output = value;
                    OnPropertyChanged("Output");
                }
            }
        }

        private void Apply(object parameter)
        {
            Bitmap bitmap = (Bitmap)Bitmap.FromFile($@"{Option1}", true);

            InputWidth = bitmap.Width;
            InputHeight = bitmap.Height;

            Input = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                          bitmap.GetHbitmap(),
                          IntPtr.Zero,
                          Int32Rect.Empty,
                          BitmapSizeOptions.FromEmptyOptions());

            OutputWidth = bitmap.Width;
            OutputHeight = bitmap.Height;

            Output = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                          bitmap.GetHbitmap(),
                          IntPtr.Zero,
                          Int32Rect.Empty,
                          BitmapSizeOptions.FromEmptyOptions());

            MessageBox.Show($"{Option1} {Option2}");
        }
    }
}
