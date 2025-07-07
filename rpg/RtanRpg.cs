namespace rpg
{ 
    class RtanRpg
    {
        static void Main(String[] args) 
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다 \n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("\n");
            Console.WriteLine("1.\t상태보기");
            Console.WriteLine("2.\t인벤토리");
            Console.WriteLine("3.\t상점");
            Console.WriteLine("\n\n어떤 행동을 하시겟습니까?");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(">>");
            Console.ResetColor();
            string? pick = Console.ReadLine(); //[string?] string이 null이될수잇음을 확인

            //[!string.IsNullOrWhiteSpace(pick)]pick이 비어있거나 공백만 있는 게 아니면 true
            if (!string.IsNullOrWhiteSpace(pick) && sbyte.TryParse(pick, out sbyte choice))  
            {
                switch (choice)
                {
                    case 1:
                        RtanStatus.Show();
                        break;
                    case 2:
                        RtanInven.Show();
                        break;
                    case 3:
                        RtanShop.Show();
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
    }



}


