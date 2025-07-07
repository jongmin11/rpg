namespace rpg
{
    public static class RtanStatus
    {
        private static int level = 1;
        private static string name = "Chad";
        private static string job = "전사";
        private static int attack = 10;
        private static int defense = 5;
        private static int health = 100;
        private static int gold = 1500;

        public static int Level
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
            Console.WriteLine($"Lv [level]");
        }
    }
}


