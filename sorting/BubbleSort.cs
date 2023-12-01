
using System;

public class SortAlgo
{
    int[] arr;
    public static void Main(string[] args)
    {
        int[] arr = {72,122,90,352,633,235,362};
        BubbleSort(arr);
        //Print Result
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr[i]);
            //Result : 72, 90, 122, 235, 352, 362, 633
        }
    }
    static void BubbleSort(int []arr) 
    { 
        int n = arr.Length; 
        for (int i = 0; i < n - 1; i++) 
            for (int j = 0; j < n - i - 1; j++) 
                if (arr[j] > arr[j + 1]) 
                { 
                    // swap temp and arr[i] 
                    int temp = arr[j]; 
                    arr[j] = arr[j + 1]; 
                    arr[j + 1] = temp; 
                } 
    } 
}
