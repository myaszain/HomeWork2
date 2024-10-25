using System;
using System.Collections.Generic;

public class GenericBinarySearch<T> where T : IComparable<T>
    // I used this instruction(where T : IComparable<T>) to make sure that T is able to compare 
{
    // Binary search using iterative method:
    public int IterativeBinarySearch(T[] array, T value)
    {
        // to check if the array is empty or not
        if (array == null || array.Length == 0)
        {
            Console.WriteLine("the array is empty");
        }

        int leftpointer = 0; // to the beginning of the array.

        int rightpointer = array.Length - 1; // to the end of the array.

        // Start a while loop that continues as long as the pointer is less than or equal to the pointer to the right.
        while (leftpointer <= rightpointer)
        {
            int middle = leftpointer + (rightpointer - leftpointer) / 2; //the middle of the array

            int comparingResult = array[middle].CompareTo(value); //Compare the value in the middle of the array with the value you want to search for.
            if (comparingResult == 0)
            {
                return middle; // The value I'm looking for is found in the middle
            }
            else if (comparingResult < 0)
            {
                leftpointer = middle + 1; // Ignore the left part
            }
            else
            {
                rightpointer = middle - 1; // Ignore the right part
            }
        }

        return -1; // The value I'm looking for is not found 
    }

    // Binary search using recursive method
    public int RecursiveBinarySearch(T[] array, T value)
    {
        if (array == null || array.Length == 0)
        {
            Console.WriteLine("the array is empty");
        }
        
        return RecursiveBinarySearchHelper(array, value, 0, array.Length - 1);
    }

    private int RecursiveBinarySearchHelper(T[] array, T value, int leftpointer, int rightpointer)
    {
        if (leftpointer > rightpointer) //Check if the pointers have crossed each other.
        {
            return -1; // The value I'm looking for is not found 
        }

        int middle = leftpointer + (rightpointer - leftpointer) / 2;

        int comparingResult = array[middle].CompareTo(value);

        if (comparingResult == 0)
        {
            return middle; // If the value exists in the middle, its position is returned.
        }

        else if (comparingResult < 0)
        {
            return RecursiveBinarySearchHelper(array, value, middle + 1, rightpointer); // If the value in the middle position is less than the value I'm looking for, the left part is ignored and the function is called again with the left pointer updated.
        }

        else
        {
            return RecursiveBinarySearchHelper(array, value, leftpointer, middle - 1); // If the value in the middle position is more than the value I'm looking for, the right part is ignored and the function is called again with the right pointer updated.
        }
    }
}
public class Program
{
    public static void Main()
    {
        GenericBinarySearch<int> binarySearch = new GenericBinarySearch<int>();

        int[] array = new int[15];
        Random random = new Random(); // random value generater

        for(int i = 0; i < array.Length; i++) // to fill the array with random values
        {
            array[i] = random.Next(0,100);
        }

        for(int i = 0;i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }

        Console.WriteLine("Enter the value that you want to look for");
        int valueToFind = int.Parse(Console.ReadLine());
        Console.WriteLine("------------------------------------------");

        // Binary search using iterative method:
        int iterativeResult = binarySearch.IterativeBinarySearch(array, valueToFind);
        Console.WriteLine("The result of the iterative binary search : " + iterativeResult);

        Console.WriteLine("------------------------------------------");

        //  Binary search using recursive method
        int recursiveResult = binarySearch.RecursiveBinarySearch(array, valueToFind);
        Console.WriteLine("The result of the recusive binary search : " + recursiveResult);
    }
}
