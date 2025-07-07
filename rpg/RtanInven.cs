using System.Security.Cryptography;
namespace rpg
{  
    public class RtanInven
    {
        public void Show()
        {
            Console.WriteLine("인밴토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("\n[아이템 목록]");
            Console.WriteLine("\n\n1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("\n\n어떤 행동을 하시겟습니까?");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(">>");
            Console.ResetColor();



            while (true)
            {
                string? exit = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(exit) && sbyte.TryParse(exit, out sbyte choice))
                {
                    if (choice == 0)
                    {
                        break;
                    }
                    else if (choice == 1)
                    {
                        
                    }
                    else
                    {
                        Console.WriteLine("올바른 번호를 입력하세요.");
                    }
                }
                else
                {
                    Console.WriteLine("숫자를 입력해 주세요.");
                }
            }
        }
    }
}


