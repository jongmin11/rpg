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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===========상태 보기==========");
            Console.ResetColor();
            Console.WriteLine("현재 나의 캐릭터 상태");
            Console.WriteLine($"Lv. {level}");
            Console.WriteLine($"이름:{Name} 직업:{(job)}");
            Console.WriteLine($"공격력: {totalAttack} {(totalAttack != attack ? $"({attack} + {totalAttack - attack})" : "")}");
            Console.WriteLine($"방어력: {totalDefence} {(totalDefence != defense ? $"({defense} + {totalDefence - defense})" : "")}");
            Console.WriteLine($"체력: {health}");
            Console.Write("Gold: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{gold}");
            Console.ResetColor();
            Console.WriteLine("[장착 중인 아이템]");
            foreach (var invItem in GameData.Inventory)
            {
                if (invItem.IsEquipped)
                {
                    Console.WriteLine($"{invItem.ItemData.Name} ({invItem.ItemData.Slot})");
                }
            }
            PrintOption("\n0. 나가기\n");

            while (true)
            {
                string? Input = GetInput();
                if (!sbyte.TryParse(Input, out sbyte choice))
                {
                    Console.WriteLine("숫자를 입력해 주세요.");
                    continue;
                }

                switch (choice)
                { 
                    case 0: 
                        return;
                    default:
                        Console.WriteLine("올바른 번호를 입력하세요.");
                        break;
                }
            }
        }
        private void PrintOption(string option) => ConsoleHelper.PrintOption(option);
        private void PrintPrompt() => ConsoleHelper.PrintPrompt();
        private string? GetInput() => ConsoleHelper.GetInput();
    }
}


