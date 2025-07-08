namespace rpg
{
    public static class GameData
    {
        public static RtanStatus Player = new RtanStatus();
        public static List<RtanInven.RtanItem> Inventory = new List<RtanInven.RtanItem>()
            {
                new RtanInven.RtanItem(ItemDB.Items[0]) { IsEquipped = true } //인덱스[0] 낡은 검 기본 지급 + 장착 
            };
       } 


}


