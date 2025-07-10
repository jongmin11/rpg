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

            if (!int.TryParse(input, out int index)) // input이 정수로 전해지지않으면...
            {
                Console.WriteLine("숫자를 입력해주세요.");
                return;
            }

            if (index == 0) return;

            var sortedList = GameData.Inventory
                .OrderByDescending(i => i.IsEquipped)
                .ToList(); // 장착한 아이템을 ture인지 false인지 구분후 true면 위쪽으로배치 내림차순으로

            if (index > 0 && index <= sortedList.Count)
            {
                var invItem = sortedList[index - 1];
                var item = invItem.ItemData;
                bool isEquipped = invItem.IsEquipped;

                if (!isEquipped)
                {
                    ConsoleHelper.Highlight($"{item.Name}을(를) 장착하시겠습니까? (Y/N)", ConsoleColor.White);
                    Console.WriteLine();
                }
                else
                {
                    ConsoleHelper.Highlight($"{item.Name}을(를) 해제하시겠습니까? (Y/N)", ConsoleColor.White);
                    Console.WriteLine();
                }

                ConsoleHelper.Highlight(">>", ConsoleColor.Yellow);
                
                string? confirm = Console.ReadLine();

                if (confirm?.ToUpper() == "Y") //confirm이 null일때 false처리 And y를입력해도 대문자로 변환시킴
                {
                   if (!isEquipped)
                   { 
                     foreach (var i in GameData.Inventory) //인벤토리내에 있는 리스트 모두검사
                     {
                        if (i != invItem && i.IsEquipped && i.ItemData.Slot == item.Slot) // i가 선택한 invItem이아니고,장착된상태이고,같은 Slot아이템일떄
                        {
                            i.IsEquipped = false;//기존장비해제
                            ConsoleHelper.Highlight($"기존 {i.ItemData.Name}이(가) 해제되었습니다.", ConsoleColor.Yellow);
                            Console.WriteLine();
                        }
                     }

                        invItem.IsEquipped = true;//내가 선택한장비 장착
                        ConsoleHelper.Highlight($"{item.Name}이(가) 장착되었습니다.", ConsoleColor.Yellow);
                        Console.WriteLine();
                   }
                   else
                   {
                        invItem.IsEquipped = false; //이미 장착된 아이템 다시선택됐으면 해제
                        ConsoleHelper.Highlight($"{item.Name}이(가) 해제되었습니다.", ConsoleColor.Yellow);
                        Console.WriteLine();
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
                .ToList();// 장착한 아이템을 ture인지 false인지 구분후 true면 위쪽으로배치 내림차순으로

            for (int i = 0; i < sorted.Count; i++)
            {
                var invItem = sorted[i];
                var item = invItem.ItemData;

                Console.Write($"- {i + 1} ");

                if (invItem.IsEquipped)
                {
                    ConsoleHelper.Highlight("[E] ", ConsoleColor.Green);
                }

                Console.WriteLine($"{item.Name}| 슬롯: {item.Slot} | 공격력 +{item.Attack} | 방어력 +{item.Defense} | {item.Description}");
            }
        }
        private void PrintOption(string option) => ConsoleHelper.PrintOption(option);
        private void PrintPrompt() => ConsoleHelper.PrintPrompt();
        private string? GetInput() => ConsoleHelper.GetInput();

        public class RtanItem
        {
            public RtanItemDB ItemData { get; }// 르탄 데이터베이스에서 아이템데이터를 읽을수만 있음
            public bool IsEquipped { get; set; } //장착값을 어디서나 읽고 쓸수잇음
            public RtanItem(RtanItemDB itemData)
            {
                ItemData = itemData;
                IsEquipped = false;
            }
        }
    }
}


