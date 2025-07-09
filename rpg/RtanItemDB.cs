using System.Security.Cryptography;
namespace rpg
{
    public class RtanItemDB
    {
        public int Price { get; }
        public string Name { get; }
        public string Description { get; }
        public int Attack { get; }
        public int Defense { get; }
        public EquipmentSlot Slot { get; }
        public RtanItemDB(string name, string desc, int atk, int def, int price, EquipmentSlot slot)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = desc ?? throw new ArgumentNullException(nameof(desc));
            Attack = atk;
            Defense = def;
            Price = price;
            Slot = slot;
        }

     }
    public static class ItemDB
    {
        public static IReadOnlyList<RtanItemDB> Items { get; } = new List<RtanItemDB>
        {
            new ("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다 기본 지급 장비입니다.", 2, 0, 0, EquipmentSlot.무기),
            new ("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 9, 900, EquipmentSlot.방어구),
            new ("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, 0, 2500, EquipmentSlot.무기),
            new ("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다", 0, 15, 3500, EquipmentSlot.방어구),
            new ("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 0, 5, 1000, EquipmentSlot.방어구),
            new ("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", 5, 0, 1500, EquipmentSlot.무기)
        };
    }

    public enum EquipmentSlot
    {
        무기,
        방어구
    }
}


