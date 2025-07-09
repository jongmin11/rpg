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
                PrintOption("\n0. 나가기\n");
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
            PrintOption("\n0. 뒤로 가기");
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

            if (index > 0 && index <= sortedList.Count)
            {
                var invItem = sortedList[index - 1];
                var item = invItem.ItemData;
                bool isEquipped = invItem.IsEquipped;

                if (!isEquipped)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{item.Name}을(를) 장착하시겠습니까? (Y/N)");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{item.Name}을(를) 해제하시겠습니까? (Y/N)");
                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(">>");
                Console.ResetColor();
                string? confirm = Console.ReadLine();

                if (confirm?.ToUpper() == "Y")
                {
                   if (!isEquipped)
                   { 
                     foreach (var i in GameData.Inventory)
                     {
                        if (i != invItem && i.IsEquipped && i.ItemData.Slot == item.Slot)
                        {
                            i.IsEquipped = false;
                            Console.ForegroundColor= ConsoleColor.Yellow;
                            Console.WriteLine($"기존 {i.ItemData.Name}이(가) 해제되었습니다.");
                            Console.ResetColor();
                        }
                     }

                        invItem.IsEquipped = true;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{item.Name}이(가) 장착되었습니다.");
                        Console.ResetColor();
                   }
                   else
                   {
                        invItem.IsEquipped = false;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{item.Name}이(가) 해제되었습니다.");
                        Console.ResetColor();
                   }
                }
                else
                { 
                    Console.WriteLine("작업이 취소되었습니다.");
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
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
        private void PrintOption(string option) => ConsoleHelper.PrintOption(option);
        private void PrintPrompt() => ConsoleHelper.PrintPrompt();
        private string? GetInput() => ConsoleHelper.GetInput();

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


