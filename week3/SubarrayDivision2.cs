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
     * Complete the 'birthday' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY s
     *  2. INTEGER d
     *  3. INTEGER m
     */

    public static int birthday(List<int> s, int d, int m)
    {
        int differentSegments = 0;
        int currentSum = 0;

        if (s.Count < m || (d<0 || d>31) || (m<1 || m>12))
            {throw new System.ArgumentException("Arguements are wrong\nMust be:\ns.Length >=m\nd in [0,31]\nm in [1,12]");
}
        for (int i=0; i<m-1; i++)
        {
            currentSum += s[i];
        }

        for (int i = m - 1; i < s.Count; i++)
        {
            currentSum += s[i];
            if (currentSum == d) differentSegments++;
            currentSum -= s[i - (m-1)];
        }

        return differentSegments;   
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int d = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        int result = Result.birthday(s, d, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
