using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace rpg
{
    public class RtanInven
    {
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("인밴토리\n보유 중인 아이템을 관리할 수 있습니다.\n");
                PrintItemList();

                Console.WriteLine("\n\n1. 장착 관리");
                PrintOption("0. 나가기");

                string? input = GetInput();

                switch (input)
                {
                    case "0":
                        return;
                    case "1":
                        ShowEquipMenu();
                        break;
                    default:
                        Console.WriteLine("올바른 번호를 입력하세요.");
                        break;
                }
            }
        }
        private void ShowEquipMenu()
        {
            Console.WriteLine("\n장착 관리");
            PrintItemList();

            PrintOption("0. 뒤로 가기");

            string? input = GetInput();

            if (!int.TryParse(input, out int index))
            {
                Console.WriteLine("숫자를 입력해주세요.");
                return;
            }

            if (index == 0) return;

            var sortedList = GameData.Inventory
                .OrderByDescending(i => i.IsEquipped)
                .ToList();

            if (index > 0 && index <= GameData.Inventory.Count)
            {
                var invItem = GameData.Inventory[index - 1];
                var item = invItem.ItemData;
                bool isEquipped = invItem.IsEquipped;

                if (!isEquipped)
                { 
                    bool slotConflict = GameData.Inventory.Any(i => i.IsEquipped && i.ItemData.Slot == item.Slot);
                    if (slotConflict)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"이미 {item.Slot} 슬롯아이템이 장착되어 있습니다.");
                        Console.ResetColor();
                        return;
                    }
                }

                Console.WriteLine(
                    isEquipped
                        ? $"{item.Name}은(는) 현재 장착중입니다. 해제하시겠습니까? (Y/N)"
                        : $"{item.Name}을(를) 장착하시겠습니까? (Y/N)"
                );

                PrintPrompt();
                string? confirm = Console.ReadLine();

                if (confirm?.ToUpper() == "Y")
                {
                    invItem.IsEquipped = !isEquipped;
                    Console.WriteLine($"{item.Name} {(invItem.IsEquipped ? "장착" : "장착 해제")}되었습니다.");
                }
                else {Console.WriteLine("작업이 취소되엇습니다.");}
            }
            else {Console.WriteLine("잘못된 입력입니다.");}
        }

        private void PrintItemList()
        {
            Console.WriteLine("\n[아이템 목록]");

            var sorted = GameData.Inventory
                .OrderByDescending(i => i.IsEquipped)
                .ToList();

            for (int i = 0; i < sorted.Count; i++)
            {
                var invItem = sorted[i];
                var item = invItem.ItemData;

                Console.Write($"- {i + 1} ");

                if (invItem.IsEquipped)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("[E] ");
                    Console.ResetColor();
                }

                Console.WriteLine($"{item.Name}| 슬롯: {item.Slot} | 공격력 +{item.Attack} | 방어력 +{item.Defense} | {item.Description}");
            }
        }
        private void PrintOption(string option)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n{option}");
            Console.ResetColor();
            Console.WriteLine("\n어떤 행동을 하시겠습니까?");

        }

        private void PrintPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(">>");
            Console.ResetColor();
        }

        private string? GetInput()
        {
            PrintPrompt();
            return Console.ReadLine();
        }

        public class RtanItem
        {
            public RtanItemDB ItemData { get; }
            public bool IsEquipped { get; set; }
            public RtanItem(RtanItemDB itemData)
            {
                ItemData = itemData;
                IsEquipped = false;
            }
        }
    }
}


