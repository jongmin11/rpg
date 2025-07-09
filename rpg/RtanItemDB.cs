using System.Security.Cryptography;
namespace rpg
{
    public class RtanItemDB
    {
        public string Name { get; }
        public string Description { get; }
        public int Attack { get; }
        public int Defense { get; }
        public RtanItemDB(string name, string desc, int atk, int def)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = desc ?? throw new ArgumentNullException(nameof(desc));
            Attack = atk;
            Defense = def;
        }
        
    }
    public static class ItemDB
    {
        public static IReadOnlyList<RtanItemDB> Items { get; } = new List<RtanItemDB>
        {
            new ("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다 기본 지급 장비입니다.", 2, 0),
            new ("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 5),
            new ("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, 0)
            
        };
    }
}


