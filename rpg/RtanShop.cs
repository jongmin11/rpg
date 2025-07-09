using System.Diagnostics;

namespace rpg
{
    public class RtanShop
    {

        public void Show()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("====================상점====================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White; 
                Console.Write("\t\t[보유 Gold]:");
                Console.ResetColor();
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.WriteLine($" {GameData.Player.Gold}");
                Console.ResetColor();
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
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine("\n\t\t[판매 목록]\n");
            Console.ResetColor();
            for (int i = 0; i < ItemDB.Items.Count; i++)
            {
                var item = ItemDB.Items[i];
                int price = item.Price;
                bool isPurchased = GameData.Inventory.Any(x => x.ItemData == item);
                string status = isPurchased ? Highlight("[구매완료]", ConsoleColor.Green) : $"가격: {price} Gold";
                Console.WriteLine($"{i + 1}. {item.Name} | {item.Description} | 공격력 +{item.Attack} | 방어력 +{item.Defense} | {status}");
            }
        }
        private void ProcessPurchase(int index)
        {
            var item = ItemDB.Items[index];
            int price = item.Price;

            if (GameData.Inventory.Any(x => x.ItemData == item))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("이미 구매한 아이템입니다.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"정말 {item.Name}을(를) 구매하시겠습니까? (Y/N)");
            Console.ResetColor();
            PrintPrompt();
            string? confirm = Console.ReadLine();

            if (confirm?.ToUpper() != "Y")
            {
                Console.WriteLine("작업이 취소되었습니다");
                return;
            }

            if (GameData.Player.Gold < price)
            { 
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Gold가 부족합니다!");
                Console.WriteLine($"필요: {price} Gold, 현재: {GameData.Player.Gold} Gold");
                Console.ResetColor();
                return;
            }

            GameData.Player.Gold -= price;
            
            if(GameData.AddItem(item))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{item.Name} 구매완료! 남은 Gold: {GameData.Player.Gold}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("이미 소지중인 아이템이라 구매가 불가능합니다!");
                GameData.Player.Gold += price;
            }
  
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

        private string Highlight(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
            return "";
        }
    }
}


