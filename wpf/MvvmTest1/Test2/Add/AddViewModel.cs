using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTest1.Test2.Add
{
    class AddViewModel
    {
        public AddViewModel(Add view)
        {
            view.Close();
        }
    }
}
