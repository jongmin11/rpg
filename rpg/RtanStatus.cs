namespace rpg
{
    public class RtanStatus
    {
        private int level = 1;
        private string name = "Chad";
        private string job = "전사";
        private int attack = 10;
        private int defense = 5;
        private int health = 100;
        private int gold = 1500;
        public int Level 
        {
            get => level;
            set => level = value > 0 ? value : level;
        }
        private string Name
        {
            get => name;
            set => name = value ?? name;
        }
        public string Job
        {
            get => job;
            set => job = value ?? job;
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
            set => health = value switch
            {
                < 0 => 0,
                > 100 => 100,
                _ => value
            };
        }
        public int Gold
        {
            get => gold;
            set => gold = value < 0 ? 0 : value;
        }
        public (int totalAttack, int totalDefence) GetTotalStats()
        {
            int totalAttack = attack;
            int totalDefence = defense;
            foreach (var invItem in GameData.Inventory)
            {
                if (invItem.IsEquipped)
                {
                    totalAttack += invItem.ItemData.Attack;
                    totalDefence += invItem.ItemData.Defense;
                }
            }

            return (totalAttack, totalDefence);
        }
        public void Show()
        {
            var (totalAttack, totalDefence) = GetTotalStats();
            ConsoleHelper.Highlight("상태 보기", ConsoleColor.Yellow);
            Console.WriteLine();
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine($"Lv. {level:D2}");
            Console.WriteLine($"{Name} ( {job} )");
            Console.WriteLine($"공격력: {totalAttack} {(totalAttack != attack ? $"({attack} + {totalAttack - attack})" : "")}");
            Console.WriteLine($"방어력: {totalDefence} {(totalDefence != defense ? $"({defense} + {totalDefence - defense})" : "")}");
            Console.WriteLine($"체력: {health}");
            Console.WriteLine($"Gold: {gold}");
            Console.WriteLine("[장착 중인 아이템]");
            foreach (var invItem in GameData.Inventory)
            {
                if (invItem.IsEquipped)
                {
                    Console.WriteLine($"{invItem.ItemData.Name} ({invItem.ItemData.Slot})");
                }
            }
            Console.WriteLine("\n0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            while (true)
            {
                string? Input = ConsoleHelper.GetInput();
                if (!sbyte.TryParse(Input, out sbyte choice))
                {
                    Console.WriteLine("잘못된 입력입니다");
                    continue;
                }

                switch (choice)
                { 
                    case 0: 
                        return;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }
    }
}


