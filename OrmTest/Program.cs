using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrmTest
{
    class Program
    {
        static void Main(string[] args)
        {
            OrmTest test = new OrmTest();
            test.PerformTest();

            Console.WriteLine();
            Console.WriteLine("Press enter to Quit");
            Console.ReadLine();
        }
    }
}
