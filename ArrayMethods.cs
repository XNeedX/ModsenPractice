using System;

public static class ArrayMethods
{
    public static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
    public static int GetSumArray(int[] array)
    {
        int sum = 0;

        foreach (int number in array)
        {
            sum += number;
        }

        return sum;
    }

    public static int GetMaxValue(int[] array)
    {
        int max = array[0];

        foreach (int number in array)
        {
            if (number > max)
                max = number;
        }

        return max;
    }

    public static int GetSecondMaxValue(int[] array)
    {
        if (array.Length < 2)
            throw new ArgumentException("Массив должен содержать хотя бы два элемента.");

        int max = int.MinValue;
        int secondMax = int.MinValue;

        foreach (int number in array)
        {
            if (number > max)
            {
                secondMax = max;
                max = number;
            }
            else if (number > secondMax && number != max)
            {
                secondMax = number;
            }
        }

        if (secondMax == int.MinValue)
            throw new ArgumentException("Все элементы массива одинаковы.");

        return secondMax;
    }

    public static int FindCountOfUnique(int[] array)
    {
        Dictionary<int, int> elements = new ();

        foreach (int element in array)
        {
            if (!elements.ContainsKey(element))
                elements.Add(element, 1);
            elements[element]++;
        }

        return elements.Count;
    }

    public static int GetFirstUnique(int[] array)
    {
        Dictionary<int, int> elements = new ();

        foreach (int element in array)
        {
            if (elements.ContainsKey(element))
                elements[element]++;
            else
                elements.Add(element, 1);
        }

        foreach (int element in array)
        {
            if (elements[element] == 1)
                return element; 
        }

        return -1; 
    }

    public static void SwapMaxAndMin(int[] array)
    {
        int indexOfMin = 0, indexOfMax = 0;

        for(int i = 0; i <  array.Length; i++)
        {
            if (array[i] > array[indexOfMax])
                indexOfMax = i;
            if (array[i] < array[indexOfMin])
                indexOfMin = i;
        }

        (array[indexOfMax], array[indexOfMin])
            = (array[indexOfMin], array[indexOfMax]);

        PrintArray(array);
    }

    public static void SwapFirstAndLast(int[] array)
    {
        (array[0], array[array.Length - 1]) 
            = (array[array.Length - 1], array[0]);

        PrintArray(array);
    }

    public static void SortByAscending(int[] array)  //В данной функции была реализована сортировка вставками
    {
        int n = array.Length;

        for (int i = 1; i < n; ++i)
        {
            int key = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j = j - 1;
            }
            array[j + 1] = key;
        }

        PrintArray(array);
    }

    public static void SortDescending(int[] array)  
    { 
        int n = array.Length;

        for (int i = 1; i < n; ++i)
        {
            int key = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] < key)
            {
                array[j + 1] = array[j];
                j = j - 1;
            }
            array[j + 1] = key;
        }

        PrintArray(array);
    }

    public static void MoveEvenToFront(int[] array)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left < right)
        {
            if (array[left] % 2 == 0)
            {
                left++;
            }
            else if (array[right] % 2 != 0)
            {
                right--;
            }
            else
            {
                (array[left], array[right]) = (array[right], array[left]);
                left++;
                right--;
            }
        }

        PrintArray(array);
    }
}
