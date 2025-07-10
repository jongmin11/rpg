namespace rpg
{
    public static class GameData
    {
        public static RtanStatus Player { get; } = new(); //C# 싱글톤역할
        public static List<RtanInven.RtanItem> _inventory = new List<RtanInven.RtanItem>(); //어디서든지 불러올수잇는 인벤토리 리스트 빈상태로 초기화 
        
        public static IReadOnlyList<RtanInven.RtanItem> Inventory => _inventory;//안전하게 인벤토리 읽기전용
        public static bool AddItem(RtanItemDB item) // 어떤아이템을 얻으면 RtanItemDB 여기로옴
        {
            if (_inventory.Any(x => x.ItemData == item)) // 인벤토리내에 이미 같은 아이템있나 검사
            return false; 

            _inventory.Add(new RtanInven.RtanItem(item)); // 중복 없으면 RtanInven.RtanItem인스턴스를 만들어서 인벤토리에 추가
            return true; 
        }

        public static void RemoveItem(RtanInven.RtanItem item) //인벤토리에 존재하는 RtanInven.RtanItem 객체를 제거한다.
        {
            _inventory.Remove(item);
        }
    } 
}


