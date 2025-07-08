using System.Security.Cryptography;
namespace rpg
{
    public class RtanItemDB
    {
        public string Name;
        public string Description;
        public int Attack;
        public int Defense;
        public RtanItemDB(string name, string desc, int atk, int def) 
        {
                Name = name;
                Description = desc;
                Attack = atk;
                Defense = def;
        }
    }
    public static class ItemDB
    {
        public static List<RtanItemDB> Items = new List<RtanItemDB>()
        {
            new RtanItemDB("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 5),
            new RtanItemDB("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, 0),
            new RtanItemDB("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 2, 0)
        };
    }
}


