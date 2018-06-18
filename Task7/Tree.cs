using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Node
    {
        public int Number { get; set; }
        public Node Left { get; set; } //0
        public Node Middle { get; set; } //1
        public Node Right { get; set; } //2
        public bool IsEnd { get; set; } //занято ли

        public Node(int number)
        {
            Number = number;
            Left = Middle = Right = null;
            IsEnd = false;
        }
    }
    class Tree
    {
        public Tree()
        {
            root = new Node(-1);
        }
        public Node root { get; set; }
        public static bool isGenereated;
        public static List<string> words;

        public static void GenerateTree(Node p, int currentLength, int length)
        {
            if (currentLength == 0)
            {
                if (p.Left == null)
                {
                    p.Left = new Node(0);
                }

                if (p.Middle == null)
                {
                    p.Middle = new Node(1);
                }

                if (p.Right == null)
                {
                    p.Right = new Node(2);
                }
            }
            if (p != null && currentLength != length)
            {
                if (p.Left == null)
                {
                    p.Left = new Node(0);
                }

                if (p.Middle == null)
                {
                    p.Middle = new Node(1);
                }

                if (p.Right == null)
                {
                    p.Right = new Node(2);
                }
                GenerateTree(p.Left, currentLength + 1, length);
                GenerateTree(p.Middle, currentLength + 1, length);
                GenerateTree(p.Right, currentLength + 1, length);
            }
        }

        public static void ShowTree(Node p, int l)
        {
            if (p != null)
            {
                ShowTree(p.Right, l + 5);
                for (int i = 0; i < l; i++)
                    Console.Write(" ");
                Console.WriteLine("{0,10:F4}", p.Number);
                ShowTree(p.Middle, l + 5);
                ShowTree(p.Left, l + 5);
            }
        }

        public static void GenerateEndpoints(Node p, int currentLength, int length)
        {
            if (!isGenereated)
            {
                if (p != null)
                {
                    if (currentLength == length - 1)
                    {
                        if (p.Left.IsEnd == false)
                            p.Left.IsEnd = true;

                        else if (p.Middle.IsEnd == false)
                            p.Middle.IsEnd = true;

                        else if (p.Right.IsEnd == false)
                            p.Right.IsEnd = true;
                        isGenereated = true;
                    }

                    else if (p.Left.IsEnd == false)
                        GenerateEndpoints(p.Left, currentLength + 1, length);
                    else if (p.Middle.IsEnd == false)
                        GenerateEndpoints(p.Middle, currentLength + 1, length);
                    else if (p.Right.IsEnd == false)
                        GenerateEndpoints(p.Right, currentLength + 1, length);
                }
            }
        }

        public static void GenerateWords(Node p, string word)
        {
            if (p != null && p.IsEnd == false)
            {
                word += p.Number;
                GenerateWords(p.Left, word);
                GenerateWords(p.Middle, word);
                GenerateWords(p.Right, word);
            }
            else if (p != null && p.IsEnd == true)
            {
                word += p.Number;
                word = word.Remove(0, 2);//удалить -1
                words.Add(word);
            }
        }
    }
}
