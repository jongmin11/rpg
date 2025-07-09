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
        public static void PrintOption(string option)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{option}");
            Console.ResetColor();
            Console.WriteLine("어떤 행동을 하시겠습니까?");
        }
        public static void Highlight(string text, ConsoleColor color)
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


