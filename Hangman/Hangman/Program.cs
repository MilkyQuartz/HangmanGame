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
            string json = File.ReadAllText("animals.json"); // json 불러오는거
            List<string> animals = JsonConvert.DeserializeObject<List<string>>(json);
            List<string> shortWords = animals.Where(word => word.Length >= 5 && word.Length <= 10).ToList();
            Random rand = new Random();
            string randTopic = shortWords[rand.Next(0, shortWords.Count)].ToLower();
            char[] word = new char[randTopic.Length];
            int tryCount = randTopic.Length + 6;

            for (int i = 0; i < randTopic.Length; i++)
            {
                word[i] = '_';
            }

            while (true)
            {
                //Console.WriteLine($"[ 답: {randTopic} ]");
                Console.WriteLine($"[ 남은 기회: {tryCount} ]");
                if (tryCount == 0)
                {
                    Console.WriteLine($"Draw! 정답은 {randTopic}입니다!");
                    break;
                }

                string playerName = (tryCount % 2 == 0) ? "Blue" : "Red";
                ConsoleColor playerColor = (tryCount % 2 == 0) ? ConsoleColor.Blue : ConsoleColor.Red;
                Console.ForegroundColor = playerColor;
                Console.Write($">> {playerName}: ");
                Console.ResetColor();
                string input = Console.ReadLine().ToLower(); // 입력된 문자열을 소문자로 변환하여 저장

                if (input.Length == 1)
                {
                    bool includedCheck = randTopic.Contains(input);
                    Console.WriteLine($"이 단어에는 {input} 스펠링이 {(includedCheck ? "존재해" : "존재하지 않아...")}");

                    for (int i = 0; i < randTopic.Length; i++)
                    {
                        if (randTopic[i] == input[0])
                        {
                            word[i] = input[0];
                            if(Array.IndexOf(word, '_') == -1)
                            {
                                Console.WriteLine($"{playerName} 승!");
                                return;
                            }
                        }
                    }
                }
                else if (input == randTopic)
                {
                    Console.WriteLine($"{playerName} 승!");
                    return;
                }

                tryCount--;
                WordWrite(word);
                Console.WriteLine();
            }
        }

        private static void WordWrite(char[] word)
        {
            string wordString = new string(word);
            Console.WriteLine(wordString);
        }
    }
}