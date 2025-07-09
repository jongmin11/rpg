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
            Console.WriteLine("어떤 행동을 하시겠습니까?");
        }
        public static void Highlight(string text, ConsoleColor color) //색깔적용 코드
        {
            Console.ForegroundColor= color;
            Console.Write(text);
            Console.ResetColor();
        }
        public static string? GetInput()
        {
            PrintPrompt();
            return Console.ReadLine();
        }
    } 
}


