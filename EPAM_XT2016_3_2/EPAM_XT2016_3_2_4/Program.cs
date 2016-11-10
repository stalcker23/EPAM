using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString mystring1 = new MyString("abc");
            MyString mystring2 = new MyString("abf");
                        
            int k = mystring1 < mystring2;
            
            Console.WriteLine(k);
            
        }
    }
}
