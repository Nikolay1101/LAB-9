using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

        // Читаем содержимое файла
        string filePath = "путь_к_файлу";
        string text = File.ReadAllText(filePath);

        // Разбиваем текст на слова
        string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Подсчитываем частоту встречаемости слов
        foreach (string word in words)
        {
            if (wordFrequency.ContainsKey(word))
            {
                wordFrequency[word]++;
            }
            else
            {
                wordFrequency[word] = 1;
            }
        }

        // Сортируем слова по частоте встречаемости и алфавиту
        var sortedWords = wordFrequency.OrderByDescending(pair => pair.Value).ThenBy(pair => pair.Key);

        // Выводим 10 наиболее встречаемых слов
        int count = 0;
        foreach (var pair in sortedWords)
        {
            Console.WriteLine(pair.Key + ": " + pair.Value);
            count++;
            if (count == 10)
            {
                break;
            }
        }
    }
}
