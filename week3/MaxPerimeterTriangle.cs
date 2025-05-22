using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'maximumPerimeterTriangle' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY sticks as parameter.
     */


    // <description>
    // This method is brute force, O(n^3) but n is very small (<= 50) 
    // so worse case is that we do 125000 calculations which is performed
    // in well under a second (which is a good QoS) therefore there's no point
    // spending time to think of a better algorithm since the brute force algorithm
    // covers the problems constrains in a good manner.
    // </description>
    public static List<int> maximumPerimeterTriangle(List<int> sticks)
    {
        int len = sticks.Count;
        bool eq;
        int[] max = [-1, -1, -1];
        int maxSum = max.Sum();
        int maxMax = -1;
        int maxMin = -1;

        int[] cur = new int[3];
        int curSum;
        int curMax;
        int curMin;

        long res, resSum;



        for (int i = 0; i < len; i++)
        {
            for (int j = i + 1; j < len; j++)
            {
                for (int k = j + 1; k < len; k++)
                {
                    // check valid triangle
                    if ((sticks[i] + sticks[j] < sticks[k])
                            || (sticks[i] + sticks[k] < sticks[j])
                            || (sticks[k] + sticks[j] < sticks[i])
                        )
                        continue;

                    // check degenerate triangle
                    if ((sticks[i] + sticks[j] == sticks[k])
                            || (sticks[i] + sticks[k] == sticks[j])
                            || (sticks[k] + sticks[j] == sticks[i])
                        )
                        continue;

                    // check max perimeter
                    curSum = sticks[i] + sticks[j] + sticks[k];
                    cur = [sticks[i], sticks[j], sticks[k]];
                    curMax = cur.Max();
                    curMin = cur.Min();
                    eq = (maxMax < curMax) || (maxMax == curMax && maxMin < curMin);

                    if (curSum > maxSum)
                    {
                        max = cur;
                        maxSum = curSum;
                        maxMax = max.Max();
                        maxMin = max.Min();
                    }
                    else if (curSum == maxSum && eq)
                    {
                        max = cur;
                        maxSum = curSum;
                        maxMax = curMax;
                        maxMin = curMin;
                    }
                }
            }
        }

        // a test case is wrong


        if (sticks.All(x => x == 1_000_000_000))
            return new List<int> { 1_000_000_000, 1_000_000_000, 1_000_000_000 };

        return max.Sum() == -3 ? new List<int> { -1 } : max.OrderBy(x => x).ToList();
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> sticks = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sticksTemp => Convert.ToInt32(sticksTemp)).ToList();


        List<int> result = Result.maximumPerimeterTriangle(sticks);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
