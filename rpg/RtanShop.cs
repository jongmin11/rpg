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
                ConsoleHelper.Highlight("\t\t[보유 Gold]:", ConsoleColor.White);
                ConsoleHelper.Highlight($" {GameData.Player.Gold}", ConsoleColor.Yellow);
                Console.WriteLine();
                PrintShopItems();
                PrintOption("\n0. 나가기");
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
            
            ConsoleHelper.Highlight("\n\t\t[판매 목록]\n", ConsoleColor.White);
            Console.WriteLine();

            for (int i = 0; i < ItemDB.Items.Count; i++)
            {
                var item = ItemDB.Items[i];
                int price = item.Price;
                bool isPurchased = GameData.Inventory.Any(x => x.ItemData == item);
                Console.Write($"{i + 1}. {item.Name} | {item.Description} | 공격력 +{item.Attack} | 방어력 +{item.Defense} | ");

                if (isPurchased)
                {
                    ConsoleHelper.Highlight("[구매완료]", ConsoleColor.Green);
                }
                else
                {
                    Console.Write($"가격: {price} Gold");
                }

                Console.WriteLine();
            }
        }
        private void ProcessPurchase(int index)
        {
            var item = ItemDB.Items[index];
            int price = item.Price;

            if (GameData.Inventory.Any(x => x.ItemData == item))
            {
                ConsoleHelper.Highlight("이미 구매한 아이템입니다.", ConsoleColor.Green);
                Console.WriteLine();
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
                ConsoleHelper.Highlight("Gold가 부족합니다!", ConsoleColor.Magenta);
                Console.WriteLine();
                ConsoleHelper.Highlight($"필요: {price} Gold, 현재: {GameData.Player.Gold} Gold", ConsoleColor.Magenta);
                Console.WriteLine();
                return;
            }

            GameData.Player.Gold -= price;
            
            if(GameData.AddItem(item))
            {
                ConsoleHelper.Highlight($"{item.Name} 구매완료! 남은 Gold: {GameData.Player.Gold}", ConsoleColor.Green);
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


