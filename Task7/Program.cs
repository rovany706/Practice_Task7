using System;
using System.Collections.Generic;
using System.Linq;
using InputHelper;

namespace Task7
{
    class Program
    {
        private static List<string> words;
        //проверка длин кодовых слов по неравенству Макмиллана
        static bool CheckLengths(int[] lengths)
        {
            double sum = 0;
            foreach (int num in lengths)
                sum += 1 / Math.Pow(3, num);

            if (sum <= 1)
                return true;
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 7\n=================");
            Console.WriteLine("Условие задачи:\nПостроить префиксный троичный код с заданными длинами кодовых слов.\n" +
                              "Кодовые слова выписать в лексикографическом порядке.\n" +
                              "=================");

            bool isOk;
            int[] lengthsOfWords;
            do
            {
                lengthsOfWords = Input.ReadIntLine("Введите длины кодовых слов, разделяя их пробелом: ");
                isOk = CheckLengths(lengthsOfWords);
                if (!isOk)
                    Console.WriteLine("Ошибка! Введенные длины кодовых слов не прошли проверку по неравенству Макмиллана. Повторите ввод.");
            } while (!isOk);

            lengthsOfWords = lengthsOfWords.OrderBy(num => num).ToArray();

            words = new List<string>(lengthsOfWords.Length);
            foreach (int length in lengthsOfWords)
                GenerateWord(length, 0, "");

            Console.Write("Полученный префиксный код: ");
            foreach (string word in words)
                Console.Write("{0} ", word);
            Console.ReadLine();
        }

        static void GenerateWord(int length, int currentLength, string word)
        {
            if (currentLength == length)
                words.Add(word);
            else
            {
                if (!words.Contains(word + '0'))
                    GenerateWord(length, currentLength + 1, word + '0');
                else if (!words.Contains(word + '1'))
                    GenerateWord(length, currentLength + 1, word + '1');
                else if (!words.Contains(word + '2'))
                    GenerateWord(length, currentLength + 1, word + '2');
            }
        }
    }
}
