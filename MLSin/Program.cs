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
                var enumerator = CircularRange.NewRange(4, 2*Math.PI)
                    .Select(ToDoubleArray)
                    .GetEnumerator();

                SpatialPooler pooler = new SpatialPooler(10, 8, 2);

                int trainCycles = 100000;
                for (int count = 0; count < trainCycles; count++)
                {
                    enumerator.MoveNext();
                    var output = pooler.ProcessInput(enumerator.Current);

                    string inputStr = ArrayToString(enumerator.Current);
                    string outputStr = ArrayToString(output);

                    if (count > trainCycles - 20)
                    {
                        Console.WriteLine($"> {inputStr}");
                        Console.WriteLine($"< {outputStr}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        static string ArrayToString<T>(T[] arr)
        {
            string str = string.Join(" ", arr);
            return $"{{{str}}}";
        }

        static double[] ToDoubleArray(double value)
        {
            var output = new double[8];

            var bitArr =new BitArray(BitConverter.GetBytes(Convert.ToInt32(value*10)).ToArray());
            
            for (int index = 0; index < bitArr.Length; index++)
            {
                if (bitArr[index])
                {
                    output[index] = 1;
                }
            }

            return output;
        }
    }
}
