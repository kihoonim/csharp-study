using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ValueObject
{
    public class Money
    {
        private readonly decimal amount;
        private readonly string currency;

        public Money(decimal amount, string currency)
        {
            if (currency == null) throw new ArgumentNullException(nameof(currency));

            this.amount = amount;
            this.currency = currency;
        }

        //public static Money operator +(Money other)
        //{
        //    return Add(other);
        //}

        public Money Add(Money arg)
        {
            if (arg == null) throw new ArgumentNullException(nameof(arg));
            if (currency != arg.currency) throw new ArgumentNullException($"Invalid = {currency}, {arg.currency}");
            return new Money(amount + arg.amount, currency);
        }

        //public Money Multiply(Rate rate);
    }
}
