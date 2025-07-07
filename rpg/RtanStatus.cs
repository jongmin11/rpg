namespace rpg
{
    public static class RtanStatus
    {
        private static int level = 1;
        private static string name = "르탄";
        private static string job = "전사";
        private static int attack = 10;
        private static int defense = 5;
        private static int health = 100;
        private static int gold = 1500;

        public static int Level //Property 클래스의 필드 값을 읽거나 쓸 때 사용하는 코드
                                // 외부에서 필드에 직접 접근하지 않고 안전하게 값을 관리하도록 도와줌
        {
            get => level;
            set
            {
                if (value > 0) 
                    level = value;
            }
        }
        public static string Name
        {
            get => name;
            set => name = value;
        }
        public static string Job
        {
            get => job;
            set => job = value;
        }
        public static int Attack
        {
            get => attack;
            set => attack = value;
        }
        public static int Defense
        {
            get => defense;
            set => defense = value;
        }
        public static int Health
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
        public static int Gold
        {
            get => gold;
            set => gold = value;
        }
        public static void Show()
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
            string? exit = Console.ReadLine();

            while (true)
            {
                if (!string.IsNullOrWhiteSpace(exit) && sbyte.TryParse(exit, out sbyte choice))
                {
                    if (choice == 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}


