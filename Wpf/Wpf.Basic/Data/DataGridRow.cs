using System;
using System.Collections.Generic;
using System.Text;
using Wpf.Mvvm;

namespace Wpf.Basic.Data
{
    public class DataGridRow : ObservableObject, ICloneable
    {
        public string _column1;
        public string Column1
        {
            get { return _column1; }
            set
            {
                if (value != _column1)
                {
                    _column1 = value;
                    OnPropertyChanged("Column1");
                }
            }
        }

        public int _column2;
        public int Column2
        {
            get { return _column2; }
            set
            {
                if (value != _column2)
                {
                    _column2 = value;
                    OnPropertyChanged("Column2");
                }
            }
        }

        public float _column3;
        public float Column3
        {
            get { return _column3; }
            set
            {
                if (value != _column3)
                {
                    _column3 = value;
                    OnPropertyChanged("Column3");
                }
            }
        }

        public bool _column4;
        public bool Column4
        {
            get { return _column4; }
            set
            {
                if (value != _column4)
                {
                    _column4 = value;
                    OnPropertyChanged("Column4");
                }
            }
        }

        public DataGridRow()
        {

        }

        public DataGridRow(DataGridRow other)
        {

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
