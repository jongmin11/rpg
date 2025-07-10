namespace rpg
{
    public static class ConsoleHelper
    {
        public static void PrintPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(">>");
            Console.ResetColor();
        }
        public static void PrintOption(string option) //(string option) 출력할 텍스트(문자열)를 받아온다
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{option}"); //option값은 고정되어있지않음 상황마다 부여함
            Console.ResetColor();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
        }
        public static void Highlight(string text, ConsoleColor color) //색깔적용 코드
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
        public static string? GetInput() //사용자가 아무것도 입력하지않으면 반환
        {
            PrintPrompt();
            return Console.ReadLine();
        }
    }

    public static class BannerAndMenu
    {
        public static void UIBannerAndMenu()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine("\n1.\t상태보기");
            Console.WriteLine("2.\t인벤토리");
            Console.WriteLine("3.\t상점");
            Console.WriteLine("'exit'  게임종료");
            Console.WriteLine("\n어떤 행동을 하시겠습니까?");
        }
    }
} 




