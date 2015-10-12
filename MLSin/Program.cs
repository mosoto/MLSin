using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLSin
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var enumerator = CircularRange.NewRange(4, 2 * Math.PI);

                for (int count = 0; count < 20; count++)
                {
                    enumerator.MoveNext();
                    Console.WriteLine(enumerator.Current);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
