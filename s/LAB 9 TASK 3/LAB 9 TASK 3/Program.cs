using System;

class Program
{
    static void Main(string[] args)
    {
        string[] participants = { "Иван", "Петр", "Анна", "Мария", "Алексей", "Ольга", "Николай", "Елена", "Дмитрий", "Светлана" };

        Console.WriteLine("Введите строку считалки:");
        string countingString = Console.ReadLine();

        Console.WriteLine("Укажите человека, с которого нужно начать:");
        string startingPerson = Console.ReadLine();

        int startingIndex = Array.IndexOf(participants, startingPerson);
        if (startingIndex == -1)
        {
            Console.WriteLine("Указанного человека нет в списке участников.");
            return;
        }

        int totalCount = countingString.Length;
        int currentIndex = startingIndex;
        int direction = countingString.Length % 2 == 0 ? 1 : -1;

        for (int i = 0; i < totalCount - 1; i++)
        {
            currentIndex = (currentIndex + participants.Length + direction) % participants.Length;
            direction *= -1;
        }

        Console.WriteLine("Последнее слово придется на: " + participants[currentIndex]);
    }
}