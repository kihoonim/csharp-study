using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTest1.Test1
{
    public class Test1Model : ObservableObject
    {
        #region Fields

        private int _productId;
        private string _productName;
        private decimal _unitPrice;
        private string _test1Items;

        #endregion // Fields

        #region Properties

        public string Test1Items
        {
            get { return _test1Items; }
            set
            {
                if (value !=_test1Items)
                {
                    _test1Items = value;
                    OnPropertyChanged("Test1Items");
                }
            }
        }

        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (value != _productId)
                {
                    _productId = value;
                    OnPropertyChanged("ProductId");
                }
            }
        }

        public string ProductName
        {
            get { return _productName; }
            set
            {
                if (value != _productName)
                {
                    _productName = value;
                    OnPropertyChanged("ProductName");
                }
            }
        }

        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set
            {
                if (value != _unitPrice)
                {
                    _unitPrice = value;
                    OnPropertyChanged("UnitPrice");
                }
            }
        }

        #endregion // Properties
    }
}
