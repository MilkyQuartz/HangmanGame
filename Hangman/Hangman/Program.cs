using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WordChain
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine($"--------------");
            Console.WriteLine($"HangmanGame!!");
            Console.WriteLine($"--------------");

            Console.WriteLine("[ 단어는 5~10 글자로 이루어져 있습니다. ]");
            Console.WriteLine("1. 게임시작\t2. 게임종료");
            Console.Write(">> ");
            string num = Console.ReadLine();
            if (num == "0")
            {
                return;
            }
            else
            {
                StartGame();
            }

        }

        private static void StartGame()
        {
            string a = "", b = "";
            bool turn = false;
            string json = File.ReadAllText("animals.json"); // json 불러오는거
            List<string> animals = JsonConvert.DeserializeObject<List<string>>(json);
            List<string> shortWords = animals.Where(word => word.Length >= 5 && word.Length <= 10).ToList();
            Random rand = new Random();
            string randTopic = shortWords[rand.Next(0, shortWords.Count)];
            char[] word = new char[randTopic.Length];
            int tryCount = randTopic.Length + 5;

            for (int i = 0; i < randTopic.Length; i++)
            {
                word[i] = '_';
            }

            while (true)
            {
                Console.WriteLine($"[ 남은 기회: {tryCount} ]");
                if (tryCount == 0)
                {
                    Console.WriteLine($"Draw! 정답은 {randTopic}입니다!");
                    break;
                }
                if (!turn)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(">> 유수정: ");
                    Console.ResetColor();
                    a = Console.ReadLine();

                    if (a.Length == 1)
                    {
                        if (randTopic.Contains(a))
                        {
                            Console.WriteLine($"이 단어에는 {a} 스펠링이 존재해");
                            for (int i = 0; i < randTopic.Length; i++)
                            {
                                if (randTopic[i] == a[0])
                                {
                                    word[i] = a[0];
                                }
                            }
                        }
                        else Console.WriteLine($"이 단어에는 {a} 스펠링이 존재하지않아...");
                    }
                    else if (a == randTopic)
                    {
                        Console.WriteLine("유수정 승!");
                        return;
                    }
                    turn = true;
                    tryCount--;
                    WordWrite(word);
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(">> 짝퉁 유수정: ");
                    Console.ResetColor();
                    b = Console.ReadLine();
                    if (b.Length == 1)
                    {
                        if (randTopic.Contains(b))
                        {
                            Console.WriteLine($"이 단어에는 {b} 스펠링이 존재해");
                            for (int i = 0; i < randTopic.Length; i++)
                            {
                                if (randTopic[i] == b[0])
                                {
                                    word[i] = b[0];
                                }
                            }
                        }
                        else Console.WriteLine($"이 단어에는 {b} 스펠링이 존재하지않아...");
                    }
                    else if (b == randTopic)
                    {
                        Console.WriteLine("짝퉁 유수정 승!");
                        return;
                    }
                    turn = false;
                    tryCount--;
                    WordWrite(word);
                    Console.WriteLine();
                }
            }
        }

        private static void WordWrite(char[] word)
        {
            string wordString = new string(word);
            Console.WriteLine(wordString);
        }
    }
}