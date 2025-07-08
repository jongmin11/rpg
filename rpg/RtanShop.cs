namespace rpg
{
    public class RtanShop
    {
        private bool[] purchased = new bool[ItemDB.Items.Count];
        public RtanShop()
        {
            for (int i = 0; i < GameData.Inventory.Count; i++)
            { 
                var invItem = GameData.Inventory[i].ItemData;
                for (int j = 0; j < ItemDB.Items.Count; j++)
                { 
                    if (invItem == ItemDB.Items[j])
                    {
                        purchased[j] = true;
                    }
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
                Console.WriteLine("\n[판매 목록]");

                for (int i = 0; i < ItemDB.Items.Count; i++)
                {
                    var item = ItemDB.Items[i];
                    int price = (item.Attack + item.Defense) * 100;

                    string status = purchased[i] ? "**구매완료**" : $"가격: {price} Gold";

                    Console.WriteLine($"{i + 1}. {item.Name} | {item.Description} | 공격력 +{item.Attack} | 방어력 +{item.Defense} | {status}");
                }

                Console.WriteLine("\n0. 나가기");
                Console.WriteLine("\n구매할 아이템번호를 입력하세요.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(">>");
                Console.ResetColor();

                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out int choice))
                {
                    if (choice == 0)
                    {
                        break;
                    }
                    else if (choice > 0 && choice <= ItemDB.Items.Count)
                    {
                        int index = choice - 1;
                        var item = ItemDB.Items[index];
                        int price = (item.Attack + item.Defense) * 100;

                        if (purchased[index])
                        {
                            Console.WriteLine("이미 구매한 아이템 입니다.");
                        }
                        else if (GameData.Player.Gold >= price)
                        {
                            GameData.Player.Gold -= price; 
                            GameData.Inventory.Add(new RtanInven.RtanItem(item));
                            purchased[index] = true;
                            Console.WriteLine($"{item.Name} 구매 완료! 남은 Gold: {GameData.Player.Gold}");
                        }
                        else
                        {
                            Console.WriteLine("Gold가 부족합니다.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }
    }
}


