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
     * Complete the 'plusMinus' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void plusMinus(List<int> arr) {
        int[] results   = { 0, 0, 0 };
        int len         = arr.Count; 
        decimal pos=0.0m, neg=0.0m, zer=0.0m;

        for (int i=0; i<len; i++) {
            if      (arr[i] > 0) results[0]++;
            else if (arr[i] < 0) results[1]++;
            else                 results[2]++; 
        }

        pos = (decimal) results[0]/len;
        neg = (decimal) results[1]/len;
        zer = (decimal) results[2]/len;

        Console.WriteLine($"{pos:F6}\n{neg:F6}\n{zer:F6}");
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.plusMinus(arr);
    }
}
