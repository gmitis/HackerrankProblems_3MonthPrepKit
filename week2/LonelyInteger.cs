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
    public static int lonelyinteger(List<int> a)
    {
        Dictionary<int, int> elem_frequency = new Dictionary<int, int>();

        foreach (int x in a)
        {
            if (!elem_frequency.ContainsKey(x)) elem_frequency[x] = 1;
            else elem_frequency[x]++;
        }

        foreach (int x in elem_frequency.Keys)
        {
            if (elem_frequency[x] == 1) return x;
        }

        throw new Exception("Wrong Input");
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        int result = Result.lonelyinteger(a);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
