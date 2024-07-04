﻿using System;

namespace Modsen
{
    class Program
    {
        static void Main()
        {
            int size;
            bool isValidInput = false;

            do
            {
                Console.WriteLine("Введите размер массива: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out size) && size > 0)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Ошибка: введите положительное целое число.");
                }
            } while (!isValidInput);

            int[] array = new int[size];

            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1, 101); // Генерация случайных чисел от 1 до 100
            }

            Console.WriteLine("Сгенерированный массив: ");
            ArrayMethods.PrintArray(array);

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Сортировать массив по возрастанию");
                Console.WriteLine("2. Сортировать массив по убыванию");
                Console.WriteLine("3. Переместить четные элементы в начало");
                Console.WriteLine("4. Найти сумму элементов массива");
                Console.WriteLine("5. Найти максимальное значение");
                Console.WriteLine("6. Найти второе максимальное значение");
                Console.WriteLine("7. Найти количество уникальных элементов");
                Console.WriteLine("8. Найти первый уникальный элемент");
                Console.WriteLine("9. Поменять местами максимальный и минимальный элементы");
                Console.WriteLine("10. Поменять местами первый и последний элементы");
                Console.WriteLine("11. Вывести массив");
                Console.WriteLine("12. Выйти");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ArrayMethods.SortByAscending(array);
                        break;
                    case "2":
                        ArrayMethods.SortDescending(array);
                        break;
                    case "3":
                        ArrayMethods.MoveEvenToFront(array);
                        Console.WriteLine("Массив после перемещения четных элементов в начало:");
                        ArrayMethods.PrintArray(array);
                        break;
                    case "4":
                        int sum = ArrayMethods.GetSumArray(array);
                        Console.WriteLine("Сумма элементов массива: " + sum);
                        break;
                    case "5":
                        int max = ArrayMethods.GetMaxValue(array);
                        Console.WriteLine("Максимальное значение: " + max);
                        break;
                    case "6":
                        try
                        {
                            int secondMax = ArrayMethods.GetSecondMaxValue(array);
                            Console.WriteLine("Второе максимальное значение: " + secondMax);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "7":
                        int uniqueCount = ArrayMethods.FindCountOfUnique(array);
                        Console.WriteLine("Количество уникальных элементов: " + uniqueCount);
                        break;
                    case "8":
                        int firstUnique = ArrayMethods.GetFirstUnique(array);
                        if (firstUnique != 0)
                        {
                            Console.WriteLine("Первый уникальный элемент: " + firstUnique);
                        }
                        else
                        {
                            Console.WriteLine("Уникальные элементы отсутствуют.");
                        }
                        break;
                    case "9":
                        ArrayMethods.SwapMaxAndMin(array);
                        Console.WriteLine("Массив после замены максимального и минимального элементов:");
                        ArrayMethods.PrintArray(array);
                        break;
                    case "10":
                        ArrayMethods.SwapFirstAndLast(array);
                        Console.WriteLine("Массив после замены первого и последнего элементов:");
                        ArrayMethods.PrintArray(array);
                        break;
                    case "11":
                        ArrayMethods.PrintArray(array);
                        break;
                    case "12":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ошибка: выберите допустимый вариант.");
                        break;
                }
            }
        }
    }
}
