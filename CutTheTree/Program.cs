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
    public static Dictionary<int, int> sums = new Dictionary<int, int>();

    public static int cutTheTree(List<int> data, List<List<int>> edges)
    {
        int[] a = new int[data.Count];
        int[] b = new int[data.Count];
        int[] c = new int[data.Count];
        int sum;
        int sum2 =  data.Sum();
        int sum3;
        int sumsub;
        //a[0] = edges[0][0];
        //for (int i = 1; i < data.Count; i++)
        //{
        //    a[i] = edges[sum][1];
        //    for (int j = 0; j < edges.Count; j++)
        //    {
        //        if (edges[j][0] == a[i])
        //            sum = j;
        //    }
        //    sum2 = sum2 + data[i];
        //}
        //Console.WriteLine(edges.Count + " " + data.Count);
        for (int i = 0; i < edges.Count; i++)
        {
            if (a[edges[i][1] - 1] == 0)
            {
                a[edges[i][1] - 1] = edges[i][0];
                c[a[edges[i][1] - 1]-1]++;
            }
            else
            {
                a[edges[i][0] - 1] = edges[i][1];
                c[a[edges[i][0] - 1]-1]++;
            }
        }

        //for (int i = 1; i < data.Count; i++)
        //{
        //    sum3 = 0;
        //    for (int j = i; j < data.Count; j++)
        //    {
        //        sum3 = sum3 + data[a[j] - 1];
        //    }
        //    sum = Math.Abs(sum2 - sum3);
        //    b[i - 1] = Math.Abs(sum - sum3);
        //}
        if(c.Max()>1)
        {
            for(int i=0;i<c.Max();i++)
            {
                for (int j = 0; j < data.Count;j++)
                {
                    if(c[j] == i)
                    {

                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < data.Count; i++)
            {
                sum3 = 0;
                int k = i;  
                while (k >= 0)
                {
                   sum3 = sum3 + data[k];
                   k = a[k] - 1;   
                }
                 sum = Math.Abs(sum2 - sum3);
                 b[i] = Math.Abs(sum - sum3);
             }
        }
        

        sumsub = b.Min();
        return sumsub;
    }

   
}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> data = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(dataTemp => Convert.ToInt32(dataTemp)).ToList();

        List<List<int>> edges = new List<List<int>>();

        for (int i = 0; i < n - 1; i++)
        {
            edges.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(edgesTemp => Convert.ToInt32(edgesTemp)).ToList());
        }

        int result = Result.cutTheTree(data, edges);
        Console.WriteLine(result);
        Console.ReadKey();
        //textWriter.Flush();
        //textWriter.Close();
    }
}
