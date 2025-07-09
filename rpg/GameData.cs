namespace rpg
{
    public static class GameData
    {
        public static RtanStatus Player { get; } = new(); //C# 싱글톤역할
        public static List<RtanInven.RtanItem> _inventory = new List<RtanInven.RtanItem>()
        {
          new RtanInven.RtanItem(ItemDB.Items[0]) { IsEquipped = true }  
        };

        public static IReadOnlyList<RtanInven.RtanItem> Inventory => _inventory;

        public static bool AddItem(RtanItemDB item)
        {
            if (_inventory.Any(x => x.ItemData == item))
            return false;

            _inventory.Add(new RtanInven.RtanItem(item));
            return true;
        }

        public static void RemoveItem(RtanInven.RtanItem item)
        {
            _inventory.Remove(item);
        }
    } 
}


