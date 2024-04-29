using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace WordChain
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n~ 평범한 직장인이였던 내가 차에 치였더니 교수대 위 스파르타 백작가의 외동딸이 되어있다? ~\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~\n");
            Console.ResetColor();

            Console.Write("Enter를 누르면 계속합니다...\n");
            WritePrompt();

            Console.Write("\n커다란 광장 한가운데 환호성과 절규가 섞인듯한 소리가 섞여 귀가 찢길듯 웅웅거린다.\n");
            WritePrompt();

            Console.Write("\n\'아니 나 분명.. 차에 치였는데.. 이 사람들은 뭐고.. 나는 왜 이런곳에...'\n");
            WritePrompt();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n\"죽여라!!!!!!!!!!!!!!!!!!!!!!!!!!\" ");
            Console.Write("\n\"어이구 성녀님을 괴롭히더니.. 잘됐군 잘됐어!\" ");
            Console.Write("\n\"마음씨도 고운 성녀님은 용서해주자고 하셨지만 르탄 황제폐하께서 크게 노하셨지.. \" \n");
            Console.ResetColor();
            WritePrompt();

            Console.WriteLine($"\n\'이게 다 무슨소리야..? 성녀..? 황제..?'");
            WritePrompt();

            WriteRed("\n\"지옥에나 떨어져라 이사벨라 유니티!!!!!!\" \n");

            Console.WriteLine("\n\'이사벨라.. 유니티? 그건 내가 어제 읽고 잤던 로판 속 악녀 이름이잖아!! 그 악녀는 교수형으로 죽게되는데..! 설마..!! '");
            WritePrompt();

            Console.Write("\n주위를 둘러보니 우리 가문은 아직 차례가 아닌듯 스파르타 백작가 내 시녀들과 하인들이 벌벌 떨면서 눈물을 흘리고있다.\n");
            WritePrompt();

            Console.WriteLine("\n\'안돼... 스파르타 가문은 잘못하지않았어..! 여기서 살아남아야해!'");
            WritePrompt();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~\n");
            Console.ResetColor();
            Console.WriteLine("\'살아남기위해 머리를 잘 써보자..! 내가 로판 속 행맨이 되버리다니!'\n");
            Console.WriteLine("[ 게임규칙 ]");
            Console.WriteLine("1. 단어는 모두 동물입니다.\n2. 단어는 5~10 글자로 이루어져 있습니다. \n3. 단어는 랜덤으로 나오며 주어지는 기회는 단어길이의 +5 입니다." +
                "\n4. 단어는 영어(소문자)로 입력해주세요. \n5. 이사벨라 유니티는 블루팀이며 블루팀이 승리해야합니다. \n6. 승리시 누명을 벗어야만 진짜 범인을 잡을 수 있습니다. \n7. 패배시 스파르타 가문의 몰락과 함께 이사벨라 유니티는 이름마저 지워집니다.\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~\n");
            Console.ResetColor();
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
            int tryCount = randTopic.Length + 5;
            string winner = "";

            for (int i = 0; i < randTopic.Length; i++)
            {
                word[i] = '_';
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"[ 답: {randTopic} ] ... 답은 테스트 하는데 못맞추면 안되잖아요........");
                Console.ResetColor();
                Console.WriteLine($"[ 남은 기회: {tryCount} ]");
                if (tryCount == 0)
                {
                    Console.WriteLine($"Draw! 정답은 {randTopic}입니다!");
                    break;
                }
                else if(tryCount == 3)
                {
                    Console.WriteLine("\n\'진짜로 모르겠어... 어떻게하지..? '");
                    Console.Write("\n부정부패를 일삼던 화이선 가문의 양자의 발 밑에 찢어진 답지가 보인다. \n귀가 얇으니 누명을 푼 뒤 두둑하게 챙겨준다는 약속으로 조금만 꼬드기면 될지도.....\n");
                    Console.WriteLine("1. 말을건다.\t2. 참는다.");
                    Console.Write($">> ");
                    string num = Console.ReadLine();

                    if (num == "1")
                    {
                        string hint = randTopic.Substring(0, randTopic.Length / 2);
                        Console.WriteLine($"찢어진 답지의 앞면을 알아냈다! {hint}");

                        for (int i = 0; i < hint.Length; i++)
                        {
                            if (word[i] == '_')
                            {
                                word[i] = hint[i];
                                if (!word.Contains('_'))
                                {
                                    Console.WriteLine("힌트로 모두 찾았습니다!");
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        char hintLetter = randTopic[rand.Next(randTopic.Length)];
                        Console.WriteLine("\n\'그래도 저 더러운 가문과 엮일바에는 내가 알아서 해보자..'");
                        Console.WriteLine($"'내 생각엔 이게 들어갈 것 같아!': {hintLetter}");

                        for (int i = 0; i < word.Length; i++)
                        {
                            if (word[i] == '_')
                            {
                                word[i] = hintLetter;
                                if (!word.Contains('_'))
                                {
                                    Console.WriteLine("힌트로 모두 찾았습니다!");
                                    break;
                                }
                                break;
                            }
                        }
                    }


                }

                string playerName = (tryCount % 2 == 0) ? "Red" : "Blue";
                ConsoleColor playerColor = (tryCount % 2 == 0) ? ConsoleColor.Red : ConsoleColor.Blue;
                Console.ForegroundColor = playerColor;
                Console.Write($">> {playerName}: ");
                Console.ResetColor();

                string input;
                if (playerName == "Red") // 레드 팀일 때는 무작위로 알파벳을 입력
                {
                    char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray(); // 레드 팀용 알파벳 리스트
                    char redAlphabet = alphabet[rand.Next(alphabet.Length)]; // 무작위 알파벳 선택
                    input = redAlphabet.ToString();
                    Console.WriteLine(input);
                }
                else
                {
                    input = Console.ReadLine().ToLower(); 
                }

                if (input.Length == 1)
                {
                    bool includedCheck = randTopic.Contains(input);
                    Console.WriteLine($"이 단어에는 {input} 스펠링이 {(includedCheck ? "존재해" : "존재하지 않아...")}");

                    for (int i = 0; i < randTopic.Length; i++)
                    {
                        if (randTopic[i] == input[0])
                        {
                            word[i] = input[0];
                            if (Array.IndexOf(word, '_') == -1)
                            {
                                Console.WriteLine($"{playerName} 승!");
                                winner = playerName;
                                break;
                            }
                        }
                    }
                }
                else if (input == randTopic)
                {
                    Console.WriteLine($"{playerName} 승!");
                    winner = playerName;
                    break;
                }

                tryCount--;
                WordWrite(word);
                Console.WriteLine();
            }

            switch (winner)
            {
                case "Red":
                    Leave_Unity();
                    break;
                case "Blue":
                    //Find_Criminal();
                    Leave_Unity();
                    break;
                default:
                    Console.WriteLine("'이렇게 죽을 수 없어. 모든걸 아는 내가 밝혀야해. 다시해보자..'");
                    StartGame();
                    break;
            }
        }

        private static void Find_Criminal()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n~ 평범한 직장인이였던 내가 차에 치였더니 교수대 위 스파르타 백작가의 외동딸이 되어있다? ~\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~.~");
            Console.ResetColor();

            WriteDarkGray("\n\"..\"\n");

            WriteDarkGray("\n\"...\"\n");

            WriteDarkGray("\n\"..\"\n");

            Console.WriteLine("\n\"살.. 았다....\"");
            WritePrompt();

            Console.WriteLine("\n내 눈을 마주친 성녀가 뒷걸음을 친다. 몰래 빠져나가려는 모양이다.");
            WritePrompt();

            Console.WriteLine("\n\"안돼...\"");
            WritePrompt();

            WriteRed("\n\"거기서 뿌링클허니콤보스노윙슈프림양념 자바!!!!!\"");

            Console.WriteLine("\n사람들의 눈이 우리를 향하고 뿌링클허니콤.. 뭐 자바는 당황한 표정으로 사람들에게 둘러쌓인다.");
            WritePrompt();

            Console.WriteLine("\n\"또 저에게 못된짓을 하려고 하는거 아닐까요..? 소녀 너무 무서워요... 흑...\"");
            WritePrompt();

            Console.WriteLine("\n\"사실... 쟤가 나쁜애고 어... 그... 거짓말해서 코도 길고... 어쨌든 진짜 못됐어요. \n황제폐하 어머니도 쟤가 돌아가시게 했어요. 제가 다 알아요!\"");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n웅성웅성");
            Console.Write("\n\"그게 무슨소리야!\" ");
            Console.Write("\n\"어여쁜 성녀님이 못되쳐먹은 인간이라니?\" ");
            Console.Write("\n\"하지만 교수형 게임에서 이기는자는 하늘의 선택을 받은자잖소..!\"");
            Console.Write("\n\"이 게임에서 살아남은 자는 스파르타 백작가의 이사벨라 유니티 밖에 없어요..!\" \n");
            Console.Write("쑥덕쑥덕\n");
            Console.ResetColor();
            WritePrompt();

            Console.WriteLine("\n\"뭐... 뭐라고!!!!!! 으억.\"");
            WritePrompt();

            Console.WriteLine("\n충격을 받은 르탄 황제폐하가 쓰러져서 교수형은 중단되게 되었고, 나는 모든 진상을 밝히겠다며 책의 내용을 모두 말해주었다.");
            WritePrompt();

            WriteRed("\n\"어디서 거지같은게.. ! 거의 이겼는데..!\"");

            Console.WriteLine("\n뿌링클..뭐시기 걔는 감옥에 가게되었고 화가났다고 했다.");
            WritePrompt();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("~.~.~.~.~.~.~.~");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n~ YOU WIN ~\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("~.~.~.~.~.~.~.~");
            Console.ResetColor();
        }

        private static void Leave_Unity()
        {

            WriteRed("\n\"역시 너 별 것 없구나? 괴롭힘 당해주는 척 해줬더니 기어오르긴..... 잘가.\"");

            Console.WriteLine("\n스파르타 가문은 몰살당했고 내 이름은 기록속에 조차 남겨지지않았다. 그리고 나는... ");
            WritePrompt();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("~.~.~.~.~.~.~.~");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n~ YOU LOSE ~\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("~.~.~.~.~.~.~.~");
            Console.ResetColor();
        }

        private static void WordWrite(char[] word)
        {
            string wordString = new string(word);
            Console.WriteLine(wordString);
        }

        static void WritePrompt()
        {
            Console.Write($">> ");
            Console.ReadLine();
        }

        static void WriteDarkGray(string response)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(response);
            Console.ResetColor();
            Console.Write($">> ");
            Console.ReadLine();
        }

        static void WriteRed(string response)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(response);
            Console.ResetColor();
            Console.Write($">> ");
            Console.ReadLine();
        }
    }
}