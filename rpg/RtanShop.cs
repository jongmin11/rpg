using System;
using System.Diagnostics;

namespace rpg
{
    public class RtanShop
    {
        public void Show()
        {
            while (true)
            {
                ConsoleHelper.Highlight("====================상점====================", ConsoleColor.White);
                Console.WriteLine();
                Console.WriteLine($"[보유 Gold]: \n{GameData.Player.Gold} G\n");
                PrintShopItems();
                Console.WriteLine("\n0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
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
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < ItemDB.Items.Count; i++)
            {
                var item = ItemDB.Items[i];
                string stat = item.Attack > 0
                    ? $"공격력 +{item.Attack}"
                    : $"방어력 +{item.Defense}";
                bool isPurchased = GameData.Inventory.Any(x => x.ItemData == item);
                string priceText = isPurchased ? "구매완료" : $"{item.Price} G";

                Console.WriteLine(
                $"- {i + 1} {item.Name.PadRight(12)} | " +
                $"{stat.PadRight(8)} | " +
                $"{item.Description.PadRight(40)} | " +
                $"{priceText.PadLeft(8)}"
                );
            }
        }
        private void ProcessPurchase(int index)
        {
            var item = ItemDB.Items[index];
            int price = item.Price;

            if (GameData.Inventory.Any(x => x.ItemData == item))
            {
                Console.WriteLine("이미 구매한 아이템입니다.");

                return;
            }

            ConsoleHelper.Highlight($"정말 {item.Name}을(를) 구매하시겠습니까? (Y/N)", ConsoleColor.White);
            Console.WriteLine();
            PrintPrompt();
            string? confirm = Console.ReadLine();

            if (confirm?.ToUpper() != "Y")
            {
                Console.WriteLine("작업이 취소되었습니다");
                return;
            }

            if (GameData.Player.Gold < price)
            {
                ConsoleHelper.Highlight("Gold가 부족합니다.", ConsoleColor.Magenta);
                Console.WriteLine();
                ConsoleHelper.Highlight($"필요: {price} Gold, 현재: {GameData.Player.Gold} Gold", ConsoleColor.Magenta);
                Console.WriteLine();
                return;
            }

            GameData.Player.Gold -= price;
            
            if(GameData.AddItem(item))
            {
                Console.WriteLine($"{item.Name} 구매완료했습니다.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("이미 소지중인 아이템이라 구매가 불가능합니다!");
                GameData.Player.Gold += price;
            }
  
        }
        private void PrintOption(string option)
        { 
            ConsoleHelper.PrintOption(option);
        }
        private void PrintPrompt()
        {
            ConsoleHelper.PrintPrompt();
        }
        private string? GetInput()
        {
            return ConsoleHelper.GetInput();
        }
        private void Highlight(string text, ConsoleColor color)
        {
            ConsoleHelper.Highlight(text, color);
        }
    }
}


