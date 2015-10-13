using System.Collections;
using System.Collections.Generic;

namespace MLSin
{
    public static class CircularRange
    {
        public static IEnumerable<double> NewRange(int numPoints, double maxNum)
        {
            double deltaIncrement = maxNum / numPoints;

            int pointNum = 0;
            while (true)
            {
                yield return deltaIncrement*pointNum;

                pointNum = ++pointNum % numPoints;
            }
        }
    }
}
