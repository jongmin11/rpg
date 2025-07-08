namespace rpg
{
    public static class GameData
    {
        public static RtanStatus Player = new RtanStatus();
        public static List<RtanInven.RtanItem> Inventory = new List<RtanInven.RtanItem>()
            {
                new RtanInven.RtanItem(ItemDB.Items[2]) { IsEquipped = true } //인덱스[2] 낡은 검 기본 지급 + 장착 
            };
       } 


}


