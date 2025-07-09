using System.Diagnostics;

namespace rpg
{
    public class RtanShop
    {
        private bool[] purchased = new bool[ItemDB.Items.Count];
        public RtanShop()
        {
           foreach (var invitem in GameData.Inventory)
           {
                for (int i = 0; i < ItemDB.Items.Count; i++)
                { 
                    if(invitem.ItemData == ItemDB.Items[i])
                        purchased[i] = true;
                }
           }
        }
        public void Show()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("====================상점====================");
                Console.ResetColor();

                Console.WriteLine($"보유 Gold: {GameData.Player.Gold}");
                PrintShopItems();

                PrintOption("0. 나가기");
                Console.WriteLine("\n구매할 아이템번호를 입력하세요");

                string? input = GetInput();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("숫자를 입력해주세요.");
                    continue;
                }

                switch (choice)
                {
                    case 0:
                        return;
                    default:
                        if (choice > 0 && choice <= ItemDB.Items.Count)
                        {
                            ProcessPurchase(choice - 1);
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                        }
                        break;
                }
            }
        }
        private void PrintShopItems()
        {
            Console.WriteLine("[판매 목록]");
            for (int i = 0; i <= ItemDB.Items.Count; i++)
            {
                var item = ItemDB.Items[i];
                int price = (item.Attack + item.Defense) * 100;
                string status = purchased[i] ? "**[구매완료]**" : $"가격: {price} Gold";

                Console.WriteLine($"{i + 1}. {item.Name} | {item.Description} | 공격력 +{item.Attack} | 방어력 +{item.Defense} | {status}");
            }
        }

        private void ProcessPurchase(int index)
        {
            var item = ItemDB.Items[index];
            int price = (item.Attack + item.Defense) * 100;

            if (purchased[index])
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
                return;
            }

            Console.WriteLine($"정말 {item.Name}을(를) 구매하시겠습니까? (Y/N)");
            PrintPrompt();
            string? confirm = Console.ReadLine();

            if (confirm?.ToUpper() != "Y")
            {
                Console.WriteLine("작업이 취소되었습니다");
                return;
            }

            if (GameData.Player.Gold >= price)
            {
                GameData.Player.Gold -= price;
                GameData.Inventory.Add(new RtanInven.RtanItem(item));
                purchased[index] = true;
                Console.WriteLine($"{item.Name} 구매 완료! 남은 Gold: {GameData.Player.Gold}");
            }
            else { Console.WriteLine("Gold가 부족합니다"); }
        }

        private void PrintOption(string option)
        { 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n{option}");
            Console.ResetColor();
        }

        private void PrintPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(">> ");
            Console.ResetColor();
        }

        private string? GetInput()
        {
            PrintPrompt();
            return Console.ReadLine();
        }
    }
}


