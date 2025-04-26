// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Collections.Generic;
using System.Linq;

public class SortingQuestion
{
    static int inputCount = 100;
    static int minNumber = 1;
    static int maxNumber = 1000;
    static bool isManualInput = false; //switch this to false if you want to self generate unique list or just lazy to type

    static List<int> inputList;

    public static void Main(string[] args)
    {
        Console.WriteLine("Before Sort");
        if (isManualInput)
            ManualInput();
        else
            RandomGenerateInput();

        QuickSort(inputList, 0, inputList.Count - 1);
        DoubleCheck();
    }

    #region Input

    public static void ManualInput()
    {
        inputList = new();
        for (int i = 1; i < inputCount + 1; i++)
        {
            //Console.WriteLine($"Please input number of position {i}");
            //int t = Console.ReadLine();
            //randomInput.Add(t);
            inputList.Add(ManualInputChecker(i));
        }
        DoubleCheck();
    }

    public static void DoubleCheck()
    {
        if (inputList != null)
        {
            foreach (var s in inputList)
            {
                Console.Write($"Number {s} _");
            }
            Console.WriteLine();
        }
    }

    public static int ManualInputChecker(int i)
    {
        Console.WriteLine($"Please input number of position {i}");
        string s = Console.ReadLine();
        int o;
        if (!int.TryParse(s, out o))
        {
            Console.WriteLine("Wrong input, please input only integer numbers !");
            return HandleInputError(i);
        }
        Console.WriteLine($"Parsed {o}");
        if (o > maxNumber)
        {
            Console.WriteLine($"Invalid input, please input integer number less than {maxNumber} !");
            return HandleInputError(i);
        }
        return o;
    }

    public static int HandleInputError(int i)
    {
        return ManualInputChecker(i);
    }

    public static void RandomGenerateInput()
    {
        //actualy i won't write this, just because i'm lazy to type 100 numbers
        inputList = GenerateInputList(inputCount, minNumber, maxNumber);
        if (inputList != null)
        {
            foreach (int number in inputList)
            {
                Console.Write(number + " _ ");
            }
            Console.WriteLine();
        }
    }

    public static List<int> GenerateInputList(int count, int min, int max)
    {
        if (count > (max - min + 1)) //100 // 1000-1+1 //make sure this input will be unique
        {
            return null;
        }
        Random random = new Random();
        HashSet<int> genNumbers = new HashSet<int>();

        while (genNumbers.Count < count)
        {
            genNumbers.Add(random.Next(min, max + 1));
        }
        return genNumbers.ToList();
    }

    #endregion

    #region Sorting
    //well, actually C# already have List.Sort(). But i assume you won't accept that result.
    //so, let do quick sort, seem that will be fastest for this case
    public static void QuickSort(List<int> input, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(input, left, right);
            QuickSort(input, left, pivotIndex - 1);
            QuickSort(input, pivotIndex + 1, right);
        }
    }

    private static int Partition(List<int> input, int left, int right)
    {
        int pivot = input[right];
        int i = left - 1;
        for (int j = left; j < right; j++)
        {
            if (input[j] < pivot)
            {
                i++;
                Swap(input, i, j);
            }
        }
        Swap(input, i + 1, right);
        return i + 1;
    }

    private static void Swap(List<int> input, int index1, int index2)
    {
        int temp = input[index1];
        input[index1] = input[index2];
        input[index2] = temp;
    }
    #endregion
}