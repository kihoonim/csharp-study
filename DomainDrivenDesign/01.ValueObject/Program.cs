using System;

namespace _01.ValueObject
{
    class Program
    {
        static void Main(string[] args)
        {
            var fullName = "lim kihoon";
            Console.WriteLine(fullName);

            var tokens = fullName.Split(' ');
            var lastName = tokens[0];
            Console.WriteLine(lastName);

            var fullNameObj = new FullName_v1("lim", "kihoon");
            Console.WriteLine(fullNameObj.FirstName);

            var nameA = new FullName_v1("lim", "kihoon");
            var nameB = new FullName_v1("lim", "kihoon");

            Console.WriteLine(nameA.Equals(nameB));


            #region 3
            var myMoney = new Money(1000, "KRW");
            var allowance = new Money(3000, "KRW");
            var result = myMoney.Add(allowance);
            var result2 = myMoney + allowance;
            #endregion
        }
    }
}
