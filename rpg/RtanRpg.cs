namespace rpg
{
    class RtanRpg
    {
        static void Main(String[] args)
        {
            while (true)
            {
                BannerAndMenu.UIBannerAndMenu();
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
        static void PrintPrompt() => ConsoleHelper.PrintPrompt();
        static string? GetInput() => ConsoleHelper.GetInput();
    }
}
                
    



