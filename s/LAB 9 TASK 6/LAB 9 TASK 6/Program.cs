using System;
using System.Collections.Generic;
using System.IO;

class Node
{
    public string Team { get; set; }
    public int Score { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(string team)
    {
        Team = team;
        Score = -1; // -1 для неизвестного результата
        Left = null;
        Right = null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Чтение названий команд из файла
        string[] teams = File.ReadAllLines("teams.txt");

        // Создание дерева с пустыми результатами
        Node root = CreateTree(teams);

        // Генерация результатов и заполнение дерева
        GenerateResults(root);

        // Вывод результатов
        PrintResults(root);
    }

    static Node CreateTree(string[] teams)
    {
        Node root = new Node("");

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            Node node = queue.Dequeue();

            if (node != null)
            {
                if (node.Left == null && node.Right == null)
                {
                    int index = (int)(Math.Log(queue.Count + 1, 2));
                    if (index < teams.Length)
                    {
                        node.Left = new Node(teams[index]);
                        node.Right = new Node(teams[teams.Length - index - 1]);
                    }
                }

                queue.Enqueue(node.Left);
                queue.Enqueue(node.Right);
            }
        }

        return root;
    }

    static void GenerateResults(Node node)
    {
        if (node != null)
        {
            GenerateResults(node.Left);
            GenerateResults(node.Right);

            if (node.Left == null && node.Right == null)
            {
                Random random = new Random();
                node.Score = random.Next(0, 5); // Генерация случайного результата
            }
        }
    }

    static void PrintResults(Node node)
    {
        if (node != null)
        {
            PrintResults(node.Left);
            PrintResults(node.Right);

            if (node.Left != null && node.Right != null)
            {
                Console.WriteLine($"{node.Left.Team} - {node.Right.Team} : {node.Left.Score} - {node.Right.Score}");
            }
        }
    }
}
