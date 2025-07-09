namespace rpg
{
    public static class GameData
    {
        public static RtanStatus Player { get; } = new();
        public static List<RtanInven.RtanItem> Inventory = new List<RtanInven.RtanItem>()
        {
          new RtanInven.RtanItem(ItemDB.Items[0]) { IsEquipped = true }  
        };
    } 
}


