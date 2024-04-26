using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessSpecifier
{
    public class First
    {
        public int publicNumber=10;
        private int privateNumber =20;
    }
    public class Second
    {
        public void SecondMethod()
        {
            First one = new First();
            Console.WriteLine(one.publicNumber);
        }
    }
}