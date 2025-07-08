namespace rpg
{
    class RtanRpg
    {
        static void Main(String[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=====================================================================================");
                Console.ResetColor();
                Console.ForegroundColor= ConsoleColor.Cyan;
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다 \n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.ResetColor();
                Console.WriteLine("\n");
                Console.WriteLine("1.\t상태보기");
                Console.WriteLine("2.\t인벤토리");
                Console.WriteLine("3.\t상점");
                Console.WriteLine("\'exit\'  게임종료");
                Console.WriteLine("\n\n어떤 행동을 하시겟습니까?");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=====================================================================================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(">>");
                Console.ResetColor();
                
                string? pick = Console.ReadLine();//string?은 null 가능성을 고려한 안전한 선언

                if (!string.IsNullOrWhiteSpace(pick))
                {
                    if (pick.Trim().ToLower() == "exit") //대소문자 혹은 띄어쓰기를 입력해도 exit 호출 
                    {
                        Console.WriteLine("게임을 종료합니다...");
                        break;
                    }

                    if (sbyte.TryParse(pick, out sbyte choice)) // pick을 sbyte값으로 변환후 choice로 대입
                    {
                        switch (choice)
                        {
                            case 1:
                                GameData.Player.Show();
                                break;
                            case 2:
                                RtanInven Inven = new RtanInven();
                                Inven.Show();
                                break;
                            case 3:
                                RtanShop Shop = new RtanShop();
                                Shop.Show();
                                break;
                            default:
                                Console.WriteLine("올바른 선택이 아닙니다.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("숫자를 입력해주세요.");
                    }
                }
                else
                {
                    Console.WriteLine("입력이 비어있습니다.");
                }
            }
        }
    }
}
                
    



