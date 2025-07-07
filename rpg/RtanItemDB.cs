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
}


