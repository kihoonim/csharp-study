using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ValueObject
{
    public class ModelNumber
    {
        private readonly string productCode;
        private readonly string branch;
        private readonly string lot;

        public ModelNumber(string productCode, string branch, string lot)
        {
            if (productCode == null) throw new ArgumentNullException(nameof(productCode));
            if (branch == null) throw new ArgumentNullException(nameof(branch));
            if (lot == null) throw new ArgumentNullException(nameof(lot));

            this.productCode = productCode;
            this.branch = branch;
            this.lot = lot;
        }

        public override string ToString()
        {
            return productCode + "-" + branch + "-" + lot;
        }
    }
}
