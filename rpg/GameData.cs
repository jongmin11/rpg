namespace rpg
{
    public static class GameData
    {
        public static RtanStatus Player { get; } = new(); //C# 싱글톤역할
        public static List<RtanInven.RtanItem> _inventory = new List<RtanInven.RtanItem>() //아이템 배열 0번 낡은 검 장착한채로 시작
        {
          new RtanInven.RtanItem(ItemDB.Items[0]) { IsEquipped = true }  
        };
        public static IReadOnlyList<RtanInven.RtanItem> Inventory => _inventory;//안전하게 인벤토리 읽기전용
        public static bool AddItem(RtanItemDB item) // 어떤아이템을 얻으면 RtanItemDB 여기로옴
        {
            if (_inventory.Any(x => x.ItemData == item)) // 인벤토리내에 이미 같은 아이템있나 검사
            return false; //이미 아이템이 존재하면 추가하지못함

            _inventory.Add(new RtanInven.RtanItem(item)); // 중복 없으면 RtanInven.RtanItem인스턴스를 만들어서 인벤토리에 추가
            return true; // 추가 성공시 true반환
        }

        public static void RemoveItem(RtanInven.RtanItem item) //인벤토리에 존재하는 RtanInven.RtanItem 객체를 제거한다.
        {
            _inventory.Remove(item);
        }
    } 
}


