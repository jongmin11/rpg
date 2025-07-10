namespace rpg
{
    class RtanRpg
    {
        static void Main(String[] args)
        {
            while (true)
            {
                PrintBannerAndMenu();
                string? pick = GetInput();

                if (string.IsNullOrWhiteSpace(pick))
                {
                    ConsoleHelper.Highlight("입력이 비어있습니다.\n", ConsoleColor.White);
                    continue;
                }

                if (pick.Trim().ToLower() == "exit")
                {
                    Console.WriteLine("게임을 종료합니다...");
                    break;
                }

                if (!sbyte.TryParse(pick, out sbyte choice))
                {
                    Console.WriteLine("숫자를 입력해주세요");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        GameData.Player.Show();
                        break;
                    case 2:
                        new RtanInven().Show();
                        break;
                    case 3:
                        new RtanShop().Show();
                        break;
                    default:
                        Console.WriteLine("올바른 선택이 아닙니다.");
                        break;
                }
            }
        }
        static void PrintBannerAndMenu()
        {
            ConsoleHelper.Highlight("=====================================================================================", ConsoleColor.Green);
            Console.WriteLine();
            ConsoleHelper.Highlight("스파르타 마을에 오신 여러분 환영합니다.", ConsoleColor.Cyan);
            Console.WriteLine();
            ConsoleHelper.Highlight("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.", ConsoleColor.Cyan);
            Console.WriteLine();
            Console.WriteLine("\n1.\t상태보기");
            Console.WriteLine("2.\t인벤토리");
            Console.WriteLine("3.\t상점");
            Console.WriteLine("'exit'  게임종료");
            Console.WriteLine("\n어떤 행동을 하시겠습니까?");
            ConsoleHelper.Highlight("=====================================================================================", ConsoleColor.Green);
            Console.WriteLine();
        }

        static void PrintPrompt() => ConsoleHelper.PrintPrompt();
        static string? GetInput() => ConsoleHelper.GetInput();
    }
}
                
    



