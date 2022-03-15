using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Union13_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ваша задача — написать программу, которая позволит понять, какие 10 слов чаще всего встречаются в тексте.

            OftenUsedWords();

            Console.ReadKey();
        }

        /// <summary>
        /// Найдем часто используемые слова
        /// </summary>
        static void OftenUsedWords()
        {
            // читаем весь файл с рабочего стола в строку текста
            string text = "";

            try
            {
                text = File.ReadAllText("C:\\_МОЯ\\Text1.txt");
            }
            catch(Exception e)
            {
                Console.WriteLine($"Ошибка при загрузке файла: {e.Message}");
                return;
            }
            

            // убираем из текста знаки пунктуации
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '\r', '\n' };

            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители, и сохраняем в List<T>
            var listWords = new List<string>();
            listWords.AddRange(noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries));

            // Создаем словарь Dictionary<TKey, TValue>, в котором TKey - это слово, TValue - это количество повторений
            var wordCount = new Dictionary<string, int>();

            // Перебираем все слова, подсчитываем их количество и записываем в словарь
            foreach (var w in listWords)
            {
                if(wordCount.ContainsKey(w))
                {
                    wordCount[w]++;
                }
                else
                {
                    wordCount.Add(w, 1);
                }
            }

            int c = 0;

            // 10 раз повторяем поиск записи с максимальным значением в словаре
            for (int i = 0; i < 10; i++)
            {
                c = wordCount.Values.Max();

                foreach (var w in wordCount)
                    if (w.Value == c)
                    {
                        Console.WriteLine($"{w.Key} - {w.Value}");  // выводим слово на консоль
                        wordCount.Remove(w.Key);                    // удаляем это слово из словаря
                    }
            }
        }
    }
}
