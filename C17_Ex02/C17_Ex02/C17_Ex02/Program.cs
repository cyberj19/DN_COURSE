using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C17_Ex02.Generators;
namespace C17_Ex02
{
    class Program
    {

        public static void Main() {
            //            Generators.RangeGenerator ms = new Generators.RangeGenerator(0, 10);
            int?[,] myarr = new int?[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    myarr[i, j] = i * 3 + j;
                }
            }


            RangeGenerator outer = new RangeGenerator(0, 3);
            RangeGenerator inner = new RangeGenerator(0, 3);

            //            RangeGenerator inner = new RangeGenerator(0, 1, 1, 1, 1);
            TwoDimensionalArrayGenerator<int?> k = new TwoDimensionalArrayGenerator<int?>(outer, inner, myarr);

            int? curr = k.Next();
            while (curr != null)
            {
                Console.WriteLine((int)curr);
                curr = k.Next();
            }
        }
    }
}
