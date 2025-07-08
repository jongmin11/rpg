namespace rpg
{
    public class RtanStatus
    {
        private int level = 1;
        private string name = "르탄";
        private string job = "전사";
        private int attack = 10;
        private int defense = 5;
        private int health = 100;
        private int gold = 1500;

        public int Level //Property 클래스의 필드 값을 읽거나 쓸 때 사용하는 코드
                                // 외부에서 필드에 직접 접근하지 않고 안전하게 값을 관리하도록 도와줌
        {
            get => level;
            set
            {
                if (value > 0) 
                    level = value;
            }
        }
        private string Name
        {
            get => name;
            set => name = value;
        }
        public string Job
        {
            get => job;
            set => job = value;
        }
        public int Attack
        {
            get => attack;
            set => attack = value;
        }
        public int Defense
        {
            get => defense;
            set => defense = value;
        }
        public int Health
        {
            get => health;
            set
            {
                if (value < 0)
                    health = 0;
                else if (value > 100)
                    health = 100;
                else
                    health = value;
            }
        }
        public int Gold
        {
            get => gold;
            set => gold = value;
        }
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상태 보기");
            Console.ResetColor();
            Console.WriteLine("현재 나의 캐릭터 상태");
            Console.WriteLine($"Lv. {level}");
            Console.WriteLine($"이름:{Name} 직업:{(job)}");
            Console.WriteLine($"공격력: {attack}");
            Console.WriteLine($"방어력: {defense}");
            Console.WriteLine($"체력: {health}");
            Console.WriteLine($"Gold: {gold}");
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("\n\n0. 나가기");
            Console.ResetColor();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.ForegroundColor= ConsoleColor.Yellow;
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


