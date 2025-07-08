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
                Console.WriteLine("인밴토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine("\n[아이템 목록]");
                for (int i = 0; i < GameData.Inventory.Count; i++)
                { 
                    var invItem = GameData.Inventory[i];
                    var item = invItem.ItemData;
                    string equipMark = invItem.IsEquipped ? "[E]" : "   ";
                    Console.WriteLine($"- {i + 1} {equipMark}{item.Name} | 공격력 +{item.Attack} | 방어력 +{item.Defense} | {item.Description}");
                }
                Console.WriteLine("\n\n1. 장착 관리");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("0. 나가기");
                Console.ResetColor();
                Console.WriteLine("\n\n어떤 행동을 하시겟습니까?");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(">>");
                Console.ResetColor();

                string? exit = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(exit) && sbyte.TryParse(exit, out sbyte choice))
                {
                    if (choice == 0)
                    {
                        break;
                    }
                    else if (choice == 1)
                    {
                        ShowEquipMenu();
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
        private void ShowEquipMenu()
        {
            Console.WriteLine("\n장착 관리");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n0. 뒤로 가기");
            Console.ResetColor();
            Console.WriteLine("\n\n어떤 행동을 하시겟습니까?");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(">>");
            Console.ResetColor();
            
            for (int i = 0; i < GameData.Inventory.Count; i++)
            { 
                var invItem = GameData.Inventory[i];
                var item = invItem.ItemData;
                string equipMark = invItem.IsEquipped ? "[E] " : "";
                Console.WriteLine($"- {i + 1} {equipMark}{item.Name} | 공격력 +{item.Attack} | 방어력 +{item.Defense} | {item.Description}");
            }
            
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int index))
            {
                if (index == 0)
                {
                    return;
                }
                else if (index > 0 && index < GameData.Inventory.Count)
                {
                    var invItem = GameData.Inventory[index - 1];
                    invItem.IsEquipped = !invItem.IsEquipped;

                    if (invItem.IsEquipped)
                    {
                        Console.WriteLine($"{invItem.ItemData.Name}을(를) 장착했습니다.");
                    }
                    else
                    {
                        Console.WriteLine($"{invItem.ItemData.Name}을(를) 장착해제했습니다..");
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다");
                }
            }
            else
            {
                Console.WriteLine("숫자를 입력해주세요");
            }
        }
         public class RtanItem
         {
            public RtanItemDB ItemData;
            public bool IsEquipped;
            public RtanItem(RtanItemDB itemData)
            { 
                ItemData = itemData;
                IsEquipped = false;
            }
         }
    }
}


