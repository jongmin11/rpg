namespace rpg
{
    public class RtanShop
    {
        private bool[] purchased = new bool[ItemDB.Items.Count];
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

                    Console.WriteLine($"{i + 1}. {item.Name} l {item.Description} l 공격력 +{item.Attack} l 방어력 +{item.Defense} l {status}");
                }

                Console.WriteLine("\n0. 나가기");
                Console.WriteLine("\n구매할 아이템번호를 입력하세요.");
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.Write(">>");
                Console.ResetColor();

                if (int.TryParse(input, out int choice))
                {
                    if (choice == 0)
                    {
                        break;
                    }
                    else if (choice == 1) 
                    {

                    }
                }
            }
        }
    }
}


